using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace UniversalAITranslator
{
    public partial class Form_TranslateDataset : Form
    {
        public event Extensions.TextDelegate ErrorLogged;
        public event Extensions.BoolDelegate TranslationCompleted;

        private ModelConfiguration currentConfiguration;
        private BindingList<TypedTranslationData> typedDataSet;
        private AiTranslator translator = null;
        private bool showNameAndGender = false;
        private StructuredTranslationManager translationManager = null;
        private bool translatedWithError = false;
        private bool runTransAfterLoad = false;
        private bool needShowTrayNotify = true;
        private int splitUntranslatedBlockCount = 0;
        private int splitUntranslatedBlockMinSize = 0;
        public Form_TranslateDataset()
        {
            InitializeComponent();
            typedDataSet = new BindingList<TypedTranslationData>();
            if (!Directory.Exists(Constants.UserPromptsDir))
                Directory.CreateDirectory(Constants.UserPromptsDir);
            string[] files = Directory.GetFiles(Constants.UserPromptsDir, "*.txt", SearchOption.TopDirectoryOnly);
            if (files.Length > 0)
                listBoxPrompts.Items.AddRange(files.Select(a => Path.GetFileNameWithoutExtension(a)).ToArray());

            string[] textTypeStrings = Enum.GetNames(typeof(TextType));
            int index = 1;
            foreach (string textTypeString in textTypeStrings)
            {
                ToolStripMenuItem allItem = new ToolStripMenuItem(textTypeString);
                allItem.Name = textTypeString + "_allItem";
                allItem.Click += AllItem_Click;
                типТекстаДляВсегоToolStripMenuItem.DropDownItems.Add(allItem);

                ToolStripMenuItem selItem = new ToolStripMenuItem(textTypeString);
                selItem.ShowShortcutKeys = true;
                selItem.ShortcutKeys = CalcFullKeyData((Keys)char.ToUpper(index.ToString()[0]), true, false, false);
                selItem.Name = textTypeString + "_selItem";
                selItem.Click += SelItem_Click;
                типТекстаДляВыделенногоToolStripMenuItem.DropDownItems.Add(selItem);
                index++;
            }
            typedDataSet.AllowEdit = true;
            dataGridViewDS.DataSource = typedDataSet;
            dataGridViewDS.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDS.Columns["TranslatedText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (translator == null)
                SetStatus("Подключение не настроено!");
        }

        /// <summary>
        /// Вызывает форму основных настроек ИИ.
        /// </summary>
        /// <returns></returns>
        public bool InitAiServer()
        {
            ConfigManager config = new ConfigManager();
            Form_AiServerConfig aiServerConfig = new Form_AiServerConfig();
            aiServerConfig.SetConfiguration(config.ServerConfiguration);
            if (aiServerConfig.ShowDialog() != DialogResult.OK)
            {
                aiServerConfig.Close();
                return false;
            }
            config.ServerConfiguration = aiServerConfig.GetConfiguration();
            config.Save();
            currentConfiguration = config.ServerConfiguration;
            listBoxPrompts.SelectedItem = config.LastPromptFile;
            return true;
        }

        private void ShowBalloonTip(string title, string text, int timeInSeconds)
        {
            if (needShowTrayNotify)
            {
                notifyIconTray.BalloonTipTitle = title;
                notifyIconTray.BalloonTipText = text;
                notifyIconTray.ShowBalloonTip(timeInSeconds * 1000);
            }
        }
        /// <summary>
        /// Показывать сообщения в трее о завершении перевода (по умолчанию true)
        /// </summary>
        /// <param name="show"></param>
        public void ShowTrayNotify(bool show)
        {
            needShowTrayNotify = show;
        }

        public void SetTranslationManager(StructuredTranslationManager manager)
        {
            translationManager = manager;
        }
        /// <summary>
        /// Устанавливает режим перевода Н-сцен для перевода диалогов
        /// </summary>
        /// <param name="ero"></param>
        public void SetEroMode(bool ero)
        {
            checkBoxEro.Checked = ero;
        }
        /// <summary>
        /// Позволяет автоматически запустить перевод сразу после открытия окна (аналогично F1)
        /// </summary>
        /// <param name="run"></param>
        public void RunStructuredTranslationAfterOpenWindow(bool run)
        {
            runTransAfterLoad = run;
        }
        /// <summary>
        /// Завершает перевод, возвращая DialogResult.OK
        /// </summary>
        public void FinishTranslation()
        {
            DialogResult = DialogResult.OK;
        }

        public void SetStatus(string status)
        {
            statusLabel.Text = status;
        }

        public void SetAutoResplitUntranslatedText(int splitBlockCount, int minBlockSize)
        {
            splitUntranslatedBlockCount = splitBlockCount;
            splitUntranslatedBlockMinSize = minBlockSize;
        }
        /// <summary>
        /// Установка текста для перевода в набор данных
        /// </summary>
        /// <param name="indexedText"></param>
        public void SetDataToDataset(Dictionary<int, string> indexedText)
        {
            typedDataSet.Clear();
            foreach (var item in indexedText)
            {
                typedDataSet.Add(new TypedTranslationData() { Id = item.Key, Text = item.Value, TranslatedText = item.Value });
            }
            //UpdateIdColumn();
            dataGridViewDS.Refresh();
        }

        /// <summary>
        /// Установка текста для перевода в набор данных
        /// </summary>
        /// <param name="indexedText"></param>
        public void SetDataToDataset(Dictionary<int, KeyValuePair<string, string>> indexedText)
        {
            typedDataSet.Clear();
            foreach (var item in indexedText)
            {
                typedDataSet.Add(new TypedTranslationData() { Id = item.Key, Text = item.Value.Key, TranslatedText = item.Value.Value });
            }
            //UpdateIdColumn();
            dataGridViewDS.Refresh();
        }

        /// <summary>
        /// Установка уже подготовленного набора данных
        /// </summary>
        /// <param name="data"></param>
        public void SetDataToDataset(List<TypedTranslationData> data)
        {
            typedDataSet.Clear();
            data.ForEach(a => typedDataSet.Add(a));
            //UpdateIdColumn();
            dataGridViewDS.Refresh();
        }
        /// <summary>
        /// Возвращает весь набор данных
        /// </summary>
        /// <returns></returns>
        public List<TypedTranslationData> GetData()
        {
            return typedDataSet.Where(a => a.Type != TextType.Splitter).ToList();
        }
        /// <summary>
        /// Добавляет в список слов для замены/перевода новую запись
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="trans"></param>
        public void AddReplacementToDict(string orig, string trans)
        {
            dataGridViewReplacment.Rows.Add(orig, trans);
        }

        /// <summary>
        /// Разбивает непереведенные блоки текст (между сплиттерами и с Enable=true) еще на N блоков.
        /// </summary>
        /// <param name="splitCount">Количество блоков</param>
        public bool SplitUntranslatedData(int splitCount, int minBlockSize)
        {
            if (splitCount < 2)
                return false;
            bool openBlock = false;
            int blockStartIndex = -1;
            int blockEndIndex = -1;
            bool untranslatedBlockFound = false;
            for (int i = 0; i < typedDataSet.Count; i++)
            {
                if (!openBlock && typedDataSet[i].Enabled && typedDataSet[i].Type != TextType.Splitter)
                {
                    openBlock = true;
                    blockStartIndex = i;
                    untranslatedBlockFound = true;
                }
                else if (openBlock && (!typedDataSet[i].Enabled || typedDataSet[i].Type == TextType.Splitter))
                {
                    openBlock = false;
                    blockEndIndex = i - 1;
                    int lineCount = blockEndIndex - blockStartIndex;
                    int lineToSplit = lineCount / splitCount;
                    if (lineToSplit <= minBlockSize)
                        return false;
                    for (int sp = 1; sp < splitCount; sp++)
                    {
                        TypedTranslationData splitter = new TypedTranslationData() { Type = TextType.Splitter, Id = -1 };
                        typedDataSet.Insert(blockStartIndex + sp * lineToSplit, splitter);
                        i++;
                    }
                }
            }
            if (openBlock)
            {
                openBlock = false;
                blockEndIndex = typedDataSet.Count - 1;
                int lineCount = blockEndIndex - blockStartIndex;
                int lineToSplit = lineCount / splitCount;
                if (lineToSplit <= 6)
                    return false;
                for (int sp = 1; sp < splitCount; sp++)
                {
                    TypedTranslationData splitter = new TypedTranslationData() { Type = TextType.Splitter, Id = -1 };
                    typedDataSet.Insert(blockStartIndex + sp * lineToSplit, splitter);
                }
            }
            if (untranslatedBlockFound)
                return true;
            return false;
        }

        private void ShowNameAndGenderFields(bool show)
        {
            dataGridViewDS.Columns["Name"].Visible = show;
            //dataGridViewDS.Columns["Gender"].Visible = show;
        }

        private void SelItem_Click(object? sender, EventArgs e)
        {
            if (sender == null)
                return;
            string name = ((ToolStripMenuItem)sender).Name;
            TextType type = (TextType)Enum.Parse(typeof(TextType), name.Split('_')[0]);
            SetTypeTextForSelected(type);
        }

        private void AllItem_Click(object? sender, EventArgs e)
        {
            if (sender == null)
                return;
            string name = ((ToolStripMenuItem)sender).Name;
            TextType type = (TextType)Enum.Parse(typeof(TextType), name.Split('_')[0]);
            SetTypeTextForAll(type);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxPrompt.Clear();
            textBoxFileName.Clear();
            listBoxPrompts.SelectedIndex = -1;
        }

        private void Form_PrepareDataset_Load(object sender, EventArgs e)
        {
            //var config = new ConfigManager(true);
            //if (listBoxPrompts.Items.Contains(config.LastPromptFile))
            //{
            //    listBoxPrompts.SelectedItem = config.LastPromptFile;
            //}
            //Меню временами не отрисовывается... почему?
            menuStrip1.Invalidate();
            menuStrip1.Refresh();
            if (translator != null)
            {
                translator.ChatManager.ClearHistory();
                translator.SetReserveChatMode(false);
                использоватьРезервноеПодключениеToolStripMenuItem.Checked = false;
            }
            if (runTransAfterLoad)
            {
                переводДиалоговToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void listBoxPrompts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPrompts.SelectedIndex != -1)
            {
                textBoxFileName.Text = (string)listBoxPrompts.SelectedItem;
                string promptText = File.ReadAllText(Path.Combine(Constants.UserPromptsDir, textBoxFileName.Text + ".txt"));
                textBoxPrompt.Text = promptText;
                ConfigManager config = new ConfigManager();
                config.LastPromptFile = textBoxFileName.Text;
                config.Save();
            }
            else
            {
                textBoxFileName.Text = "";
            }
        }

        private void buttonSavePrompt_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Constants.UserPromptsDir, textBoxFileName.Text + ".txt"), textBoxPrompt.Text);
        }

        private void buttonRemovePrompt_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Constants.UserPromptsDir, textBoxFileName.Text + ".txt");
            File.Delete(filePath);
            listBoxPrompts.Items.Remove(listBoxPrompts.SelectedItem);
        }

        private void настроитьПодключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InitAiServer())
            {
                translator = new AiTranslator(currentConfiguration);
                SetStatus("Подключение настроено, можно работать!");
            }
        }



        private void показатьскрытьНастройкиСистемногоПромптаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private async void перевестиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatus("Идет перевод...");
            SetControlsEnabled(false);
            var listToTranslate = typedDataSet.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();

            var result = await TranslateData(listToTranslate);

            foreach (var item in result)
            {
                var foundedItem = typedDataSet.FirstOrDefault(a => a.Id == item.Id);
                if (foundedItem == null)
                {
                    ErrorLogged?.Invoke("При переводе произошла рассинхронизация, возвращенный Id не найдет в оригинальных данных");
                    continue;
                }
                foundedItem.TranslatedText = item.Text;
                foundedItem.Enabled = false;
            }
            dataGridViewDS.Refresh();
            SetControlsEnabled(true);
            SetStatus("Перевод завершен!");
            ShowBalloonTip("Перевод завершен", "Перевод успешно завершен!", 5);
        }

        private async void перевестиСПредварительнымОбъединениемСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatus("Идет перевод...");
            SetControlsEnabled(false);
            var listToTranslate = typedDataSet.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();
            Dictionary<int, List<int>> dataToRestoreList = new Dictionary<int, List<int>>();

            List<TypedTranslationData> nList = new List<TypedTranslationData>();
            int curIndex = 0;
            bool needNewItem = false;
            for (int i = 0; i < listToTranslate.Count; i++)
            {
                if (listToTranslate[i].Type != TextType.Description)
                {
                    curIndex++;
                    dataToRestoreList[curIndex] = [i];
                    var nItem = listToTranslate[i].Clone();
                    nItem.Id = curIndex;
                    nList.Add(nItem);
                    needNewItem = true;
                }
                else
                {
                    if (needNewItem)
                    {
                        needNewItem = false;
                        curIndex++;
                        if (dataToRestoreList.ContainsKey(curIndex))
                            throw new Exception("Ошибка реализации?");
                        dataToRestoreList[curIndex] = [i];
                        var nItem = listToTranslate[i].Clone();
                        nItem.Id = curIndex;
                        nList.Add(nItem);
                    }
                    else
                    {
                        dataToRestoreList[curIndex].Add(i);
                        nList[nList.Count - 1].Text += listToTranslate[i].Text;
                    }
                }
            }


            var result = await TranslateData(nList);

            if (result != null)
            {
                foreach (var item in result)
                {
                    if (dataToRestoreList[item.Id].Count == 1)
                    {
                        listToTranslate[dataToRestoreList[item.Id][0]].TranslatedText = item.Text;
                        listToTranslate[dataToRestoreList[item.Id][0]].Enabled = false;
                    }
                    else
                    {
                        string[] lines = TextSplitter.SplitTextIntoLines(item.Text, dataToRestoreList[item.Id].Count);
                        for (int i = 0; i < dataToRestoreList[item.Id].Count; i++)
                        {
                            listToTranslate[dataToRestoreList[item.Id][i]].TranslatedText = lines[i];
                            listToTranslate[dataToRestoreList[item.Id][i]].Enabled = false;
                        }
                    }
                }
            }

            dataGridViewDS.Refresh();


            //foreach (var item in result)
            //{
            //    var foundedItem = typedDataSet.FirstOrDefault(a => a.Id == item.Id);
            //    if (foundedItem == null)
            //    {
            //        ErrorLogged?.Invoke("При переводе произошла рассинхронизация, возвращенный Id не найдет в оригинальных данных");
            //        continue;
            //    }
            //    foundedItem.TranslatedText = item.Text;
            //    foundedItem.Enabled = false;
            //}
            SetControlsEnabled(true);
            SetStatus("Перевод завершен!");
            ShowBalloonTip("Перевод завершен", "Перевод успешно завершен!", 5);
        }

        //private async void перевестиToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetStatus("Идет перевод...");
        //    var listToTranslate = typedDataSet.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();

        //    List<List<TypedTranslationData>> blocksToTranslate = new List<List<TypedTranslationData>>();
        //    List<TypedTranslationData> block = new List<TypedTranslationData>();
        //    int curIndex = 0;
        //    foreach (var item in listToTranslate)
        //    {
        //        if (item.Type != TextType.Splitter)
        //            block.Add(item);
        //        else
        //        {
        //            blocksToTranslate.Add(block);
        //            block = new List<TypedTranslationData>();
        //            continue;
        //        }

        //        if (curIndex > currentConfiguration.MaxLinesInQuery && item.Type == TextType.Name)
        //        {
        //            curIndex = 0;
        //            blocksToTranslate.Add(block);
        //            block = new List<TypedTranslationData>();
        //            block.Add(item);
        //            continue;
        //        }
        //        curIndex++;
        //    }
        //    if(block.Count > 0)
        //        blocksToTranslate.Add(block);
        //    //Установка системного промпта
        //    if (dataGridViewReplacment.RowCount > 0 && textBoxPrompt.Text.Contains("{0}"))
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i < dataGridViewReplacment.Rows.Count; i++)
        //        {
        //            sb.AppendLine($"- {dataGridViewReplacment["scrText", i].Value} -> {dataGridViewReplacment["destText", i].Value}");
        //        }
        //        translator.SetSystemPrompt(string.Format(textBoxPrompt.Text, sb.ToString()));

        //    }
        //    else
        //    {
        //        translator.SetSystemPrompt(textBoxPrompt.Text);
        //    }
        //    //Цикл перевода
        //    foreach (var currentBlock in blocksToTranslate)
        //    {
        //        var translationResult = await translator.TranslateTypedText(currentBlock);
        //        if (translationResult.data != null)
        //        {
        //            foreach (var item in translationResult.data)
        //            {
        //                var foundedItem = typedDataSet.FirstOrDefault(a => a.Id == item.Id);
        //                if (foundedItem == null)
        //                {
        //                    ErrorLogged?.Invoke("При переводе произошла рассинхронизация, возвращенный Id не найдет в оригинальных данных");
        //                    break;
        //                }
        //                foundedItem.TranslatedText = item.Text;
        //                foundedItem.Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            //SetStatus("Перевод завершен c ошибками!");
        //            ErrorLogged?.Invoke("Перевод завершен c ошибками:\n" + translationResult.errText);
        //        }
        //    }
        //    SetStatus("Перевод завершен!");
        //}


        private async Task<List<TypedTranslationData>> TranslateData(List<TypedTranslationData> translationData)
        {
            List<TypedTranslationData> result = new List<TypedTranslationData>();
            var listToTranslate = translationData.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();

            List<List<TypedTranslationData>> blocksToTranslate = new List<List<TypedTranslationData>>();
            List<TypedTranslationData> block = new List<TypedTranslationData>();
            int curIndex = 0;
            foreach (var item in listToTranslate)
            {
                if (item.Type != TextType.Splitter)
                    block.Add(item);
                else
                {
                    blocksToTranslate.Add(block);
                    block = new List<TypedTranslationData>();
                    continue;
                }

                if (curIndex > currentConfiguration.MaxLinesInQuery && item.Type == TextType.Name)
                {
                    curIndex = 0;
                    blocksToTranslate.Add(block);
                    block = new List<TypedTranslationData>();
                    block.Add(item);
                    continue;
                }
                curIndex++;
            }
            if (block.Count > 0)
                blocksToTranslate.Add(block);

            //Цикл перевода
            foreach (var currentBlock in blocksToTranslate)
            {
                //Установка системного промпта (повторение в цикле, т.к. нужно уменьшить словарь переводимых слов)
                if (textBoxPrompt.Text.Contains("{0}"))
                {
                    if (dataGridViewReplacment.RowCount > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("5. **Translation:**\r\n   - Use the following translation of names and titles if they appear in the text:");
                        for (int i = 0; i < dataGridViewReplacment.Rows.Count; i++)
                        {
                            string origText = (string)dataGridViewReplacment["scrText", i].Value;
                            if (currentBlock.Any(a => a.Text.Contains(origText)))
                                sb.AppendLine($"      - {origText} -> {dataGridViewReplacment["destText", i].Value}");
                        }
                        translator.SetSystemPrompt(textBoxPrompt.Text.Replace("{0}", sb.ToString()));
                    }
                    else
                    {
                        translator.SetSystemPrompt(textBoxPrompt.Text.Replace("{0}", ""));
                    }

                }
                else
                {
                    translator.SetSystemPrompt(textBoxPrompt.Text);
                }

                var translationResult = await translator.TranslateTypedText(currentBlock, checkBoxSaveContext.Checked);
                if (translationResult.data != null)
                {
                    result.AddRange(translationResult.data);
                }
                else
                {
                    //SetStatus("Перевод завершен c ошибками!");
                    ErrorLogged?.Invoke("Перевод завершен c ошибками:\n" + translationResult.errText);
                }
            }
            return result;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            dataGridViewReplacment.Rows.Add();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridViewReplacment.Rows.Count == 0 || dataGridViewReplacment.SelectedCells.Count == 0)
                return;
            dataGridViewReplacment.Rows.RemoveAt(dataGridViewReplacment.SelectedCells[0].RowIndex);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text))
                return;
            string[] subStr = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < subStr.Length; i++)
            {
                string[] items = subStr[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                dataGridViewReplacment.Rows.Add(items[0], items[1]);
            }
        }

        private void сохранитьТекущийНаборДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "aids files|*.aids";
            saveFileDialog.DefaultExt = ".aids";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8);
                writer.Write(typedDataSet.Count);
                foreach (var item in typedDataSet)
                {
                    writer.Write(item.Id);
                    writer.Write(item.Enabled);
                    writer.Write((int)item.Type);
                    writer.Write(item.Text);
                    writer.Write(item.TranslatedText);
                }
                writer.Close();
                SetStatus("Набор данных сохранен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("При сохранении возникла ошибка: " + ex.Message);
            }
        }

        private void загрузитьНаборДанныхИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "aids files|*.aids";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryReader reader = new BinaryReader(fs, Encoding.UTF8);
                int count = reader.ReadInt32();
                List<TypedTranslationData> loadedData = new List<TypedTranslationData>();
                for (int i = 0; i < count; i++)
                {
                    TypedTranslationData item = new TypedTranslationData();
                    item.Id = reader.ReadInt32();
                    item.Enabled = reader.ReadBoolean();
                    item.Type = (TextType)reader.ReadInt32();
                    item.Text = reader.ReadString();
                    item.TranslatedText = reader.ReadString();
                    loadedData.Add(item);
                }
                typedDataSet.Clear();
                loadedData.ForEach(a => typedDataSet.Add(a));
                dataGridViewDS.Refresh();
                SetStatus("Данные успешно загружены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("При загрузке возникла ошибка: " + ex.Message);
            }
        }
        private void EnableAllLines(bool enabled)
        {
            foreach (var item in typedDataSet)
            {
                item.Enabled = enabled;
            }
            dataGridViewDS.Refresh();
        }

        private void EnableSelectedLines(bool enabled)
        {
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                typedDataSet[dataGridViewDS.SelectedCells[i].RowIndex].Enabled = enabled;
            }
            dataGridViewDS.Refresh();
        }

        private bool CheckIsAllSelectedLines()
        {
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                if (!typedDataSet[dataGridViewDS.SelectedCells[i].RowIndex].Enabled)
                {
                    return false;
                }
            }
            return true;
        }

        private void EnableLinesByText(bool enabled)
        {
            Form_input fInput = new Form_input();
            if (dataGridViewDS.SelectedCells.Count > 0)
            {
                fInput.textBoxInput.Text = dataGridViewDS["Text", dataGridViewDS.SelectedCells[0].RowIndex].Value.ToString();
            }
            if (fInput.ShowDialog() != DialogResult.OK)
            {
                fInput.Close();
                return;
            }
            for (int i = 0; i < typedDataSet.Count; i++)
            {

                if (typedDataSet[i].Text == fInput.textBoxInput.Text)
                {
                    typedDataSet[i].Enabled = enabled;
                }
            }
            dataGridViewDS.Refresh();
            fInput.Close();
        }

        private void SetTypeTextForAll(TextType type)
        {
            foreach (var item in typedDataSet)
            {
                item.Type = type;
            }
            dataGridViewDS.Refresh();
        }

        private void SetTypeTextForSelected(TextType type)
        {
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                typedDataSet[dataGridViewDS.SelectedCells[i].RowIndex].Type = type;
            }
            dataGridViewDS.Refresh();
        }

        private void выбратьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAllLines(true);
        }

        private void ничегоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAllLines(false);
        }

        private void выбратьВыделенноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableSelectedLines(true);
        }

        private void отменитьВыделенноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableSelectedLines(false);
        }

        private void завершитьПереводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishTranslation();
        }

        private void установитьВыделениеПоСовпадениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableLinesByText(true);
        }

        private void снятьВыделениеПоСовпадениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableLinesByText(false);
        }

        private void выделитьПомеченныеСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < typedDataSet.Count; i++)
            {
                if (typedDataSet[i].Enabled)
                {
                    dataGridViewDS["Text", i].Selected = true;
                }
                else
                    dataGridViewDS["Text", i].Selected = false;

            }
        }

        private void добавитьСплиттерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            int currentIndex = dataGridViewDS.SelectedCells[0].RowIndex;
            TypedTranslationData splitter = new TypedTranslationData() { Type = TextType.Splitter, Id = -1 };
            typedDataSet.Insert(currentIndex, splitter);
            dataGridViewDS.Refresh();
            dataGridViewDS.PerformLayout();
        }

        private void удалитьВыделенныйСплиттерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            List<TypedTranslationData> itemsToDelete = new List<TypedTranslationData>();
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                if (typedDataSet[dataGridViewDS.SelectedCells[i].RowIndex].Type == TextType.Splitter)
                    itemsToDelete.Add(typedDataSet[dataGridViewDS.SelectedCells[i].RowIndex]);
            }
            itemsToDelete.ForEach(a => typedDataSet.Remove(a));
        }

        private void показатьскрытьПоляИмениИПолаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNameAndGenderFields(showNameAndGender);
            showNameAndGender = !showNameAndGender;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == CalcFullKeyData(Keys.S, true, false, false))
            {
                if (CheckIsAllSelectedLines())
                    EnableSelectedLines(false);
                else
                    EnableSelectedLines(true);
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private Keys CalcFullKeyData(Keys keyData, bool isCtrl, bool isShift, bool isAlt)
        {
            Keys res = keyData;
            if (isCtrl)
                res |= Keys.Control;
            if (isShift)
                res |= Keys.Shift;
            if (isAlt)
                res |= Keys.Alt;
            return res;
        }

        private async void переводДиалоговToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (translationManager == null)
                return;
            SetControlsEnabled(false);
            SetStatus("Идет перевод...");
            var listToTranslate = typedDataSet.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();

            var result = await TranslateStructuredData(listToTranslate, checkBoxIndexedQuery.Checked, checkBoxEro.Checked, checkBoxUseCustomDict.Checked);

            foreach (var item in result)
            {
                var foundedItem = typedDataSet.FirstOrDefault(a => a.Id == item.Id);
                if (foundedItem == null)
                {
                    ErrorLogged?.Invoke("При переводе произошла рассинхронизация, возвращенный Id не найдет в оригинальных данных");
                    continue;
                }
                foundedItem.TranslatedText = item.Text;
                foundedItem.Enabled = false;
            }
            dataGridViewDS.Refresh();
            SetControlsEnabled(true);
            SetStatus("Перевод завершен!");
            ShowBalloonTip("Перевод завершен", translatedWithError ? "Перевод завершен с ошибками" : "Перевод успешно завершен!", 5);
            if (runTransAfterLoad && translatedWithError && splitUntranslatedBlockCount > 1)
            {
                if (SplitUntranslatedData(splitUntranslatedBlockCount, splitUntranslatedBlockMinSize))
                {
                    translator.ChatManager.ClearHistory();
                    переводДиалоговToolStripMenuItem_Click(sender, e);
                }
                else
                    TranslationCompleted?.Invoke(!translatedWithError);
            }
            else
                TranslationCompleted?.Invoke(!translatedWithError);
        }

        private void SetControlsEnabled(bool enabled)
        {
            dataGridViewDS.Enabled = enabled;
            menuStrip1.Enabled = enabled;
            splitContainer1.Panel1.Enabled = enabled;
        }


        private async Task<List<TypedTranslationData>> TranslateStructuredData(List<TypedTranslationData> translationData, bool indexedQuery, bool eroMode, bool charaTranslationFromDict)
        {
            translatedWithError = false;
            List<TypedTranslationData> result = new List<TypedTranslationData>();
            var listToTranslate = translationData.Where(a => a.Enabled && a.Type != TextType.Ignore).ToList();

            List<List<TypedTranslationData>> blocksToTranslate = new List<List<TypedTranslationData>>();
            List<TypedTranslationData> block = new List<TypedTranslationData>();
            int curIndex = 0;
            foreach (var item in listToTranslate)
            {
                if (item.Type != TextType.Splitter)
                    block.Add(item.Clone());
                else
                {
                    if (block.Count > 0)
                        blocksToTranslate.Add(block);
                    block = new List<TypedTranslationData>();
                    continue;
                }

                if (curIndex > currentConfiguration.MaxLinesInQuery && item.Type == TextType.Name)
                {
                    curIndex = 0;
                    if (block.Count > 0)
                        blocksToTranslate.Add(block);
                    block = new List<TypedTranslationData>();
                    block.Add(item.Clone());
                    continue;
                }
                curIndex++;
            }
            if (block.Count > 0)
                blocksToTranslate.Add(block);

            //Цикл перевода
            foreach (var currentBlock in blocksToTranslate)
            {

                StructuredTranslationData tData = null;
                if (charaTranslationFromDict)
                {
                    Dictionary<string, string> customDict = new Dictionary<string, string>();
                    for (int i = 0; i < dataGridViewReplacment.Rows.Count; i++)
                    {
                        string origText = (string)dataGridViewReplacment["scrText", i].Value;
                        string transText = (string)dataGridViewReplacment["destText", i].Value;
                        customDict[origText] = transText;
                    }
                    tData = translationManager.CreateTranslationData(customDict);
                }
                else
                    tData = translationManager.CreateTranslationData();
                foreach (var item in currentBlock)
                {
                    StructuredTranslationData.TextType tType = StructuredTranslationData.TextType.FirstPerson;
                    switch (item.Type)
                    {
                        case TextType.Text:
                            tType = StructuredTranslationData.TextType.FirstPerson;
                            break;
                        case TextType.Description:
                            tType = StructuredTranslationData.TextType.Description;
                            break;
                        case TextType.Selection:
                            tType = StructuredTranslationData.TextType.Selection;
                            break;
                        default:
                            continue;
                    }
                    tData.TextData.Add(new StructuredTranslationData.TextDataItem() { Name = item.Name, Text = item.Text, Type = tType });
                }
                translationManager.SetGender(tData);
                translationManager.RemoveUnusedNames(tData);

                string[] structuredTranslatorResult = null;
                if (tData.Names.Count == 0 && tData.TextData.All(a => a.Name == string.Empty))
                {
                    structuredTranslatorResult = await translator.TranslateNonStructuredText(tData, checkBoxSaveContext.Checked);
                }
                else
                {
                    structuredTranslatorResult = await translator.TranslateStructuredText(tData, indexedQuery, eroMode, checkBoxSaveContext.Checked);
                }
                if (structuredTranslatorResult == null || (structuredTranslatorResult.Length == 0 && currentBlock.Count > 0))
                {
                    ErrorLogged?.Invoke("Перевод завершен c ошибками");
                    translatedWithError = true;
                    //return result;
                    continue;
                }
                try
                {
                    int index = 0;
                    foreach (var item in currentBlock)
                    {
                        StructuredTranslationData.TextType tType = StructuredTranslationData.TextType.FirstPerson;
                        switch (item.Type)
                        {
                            case TextType.Text:
                                tType = StructuredTranslationData.TextType.FirstPerson;
                                break;
                            case TextType.Description:
                                tType = StructuredTranslationData.TextType.Description;
                                break;
                            case TextType.Selection:
                                tType = StructuredTranslationData.TextType.Selection;
                                break;
                            default:
                                continue;
                        }
                        if (currentConfiguration.NeedFixDirectSpeech && tType == StructuredTranslationData.TextType.FirstPerson)
                        {
                            if (!item.Text.Contains('「') && !item.Text.Contains('」'))
                            {
                                item.Text = structuredTranslatorResult[index];
                            }
                            else
                                item.Text = DirectSpeechFixer.FixText(structuredTranslatorResult[index], currentConfiguration.DirectSpeechFixType);
                        }
                        else
                            item.Text = structuredTranslatorResult[index];
                        index++;
                    }
                    result.AddRange(currentBlock);
                }
                catch (Exception ex)
                {
                    ErrorLogged?.Invoke(ex.Message);
                    translatedWithError = true;
                    return result;
                }
                //var translationResult = await translator.TranslateTypedText(currentBlock);
                //if (translationResult.data != null)
                //{
                //    result.AddRange(translationResult.data);
                //}
                //else
                //{
                //    //SetStatus("Перевод завершен c ошибками!");
                //    ErrorLogged?.Invoke("Перевод завершен c ошибками:\n" + translationResult.errText);
                //}
            }
            return result;
        }

        private void перевестиИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            translator.SetSystemPrompt(textBoxPrompt.Text);
            Form_ImageTranslator imgTranslator = new Form_ImageTranslator(translator);
            imgTranslator.ErrorLogged += ImgTranslator_ErrorLogged;
            imgTranslator.TranslationCompleted += ImgTranslator_TranslationCompleted;
            imgTranslator.ShowDialog();
            imgTranslator.Close();
        }

        private void ImgTranslator_TranslationCompleted(bool value)
        {
            TranslationCompleted?.Invoke(value);
        }

        private void ImgTranslator_ErrorLogged(string text)
        {
            ErrorLogged?.Invoke(text);
        }

        private void разбитьПоКоличествуСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_input fInput = new Form_input();
            fInput.textBoxInput.Text = 100.ToString();
            if (fInput.ShowDialog() != DialogResult.OK)
                return;
            SplitOnLineCount(Convert.ToInt32(fInput.textBoxInput.Text));
        }
        /// <summary>
        /// Добавляет разделители в набор данных по указанному количеству строк.
        /// </summary>
        /// <param name="lineCount"></param>
        public void SplitOnLineCount(int lineCount)
        {
            int splitLineCount = lineCount;
            int splitCount = typedDataSet.Count / splitLineCount;
            if (typedDataSet.Count % splitLineCount > 0)
                splitCount++;
            splitLineCount = typedDataSet.Count / splitCount;
            for (int i = 1; i < splitCount; i++)
            {
                TypedTranslationData splitter = new TypedTranslationData() { Type = TextType.Splitter, Id = -1 };
                typedDataSet.Insert(splitLineCount * i, splitter);
            }
            dataGridViewDS.Refresh();
            dataGridViewDS.PerformLayout();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void dataGridViewDS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridViewDS.Rows[e.RowIndex].HeaderCell.Value == null
    || !dataGridViewDS.Rows[e.RowIndex].HeaderCell.Value.Equals((e.RowIndex + 1).ToString()))
                dataGridViewDS.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void отчиститьКонтекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (translator != null)
                translator.ChatManager.ClearHistory();
        }

        private void подсветитьНезакрытыеДиалогиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDS.RowCount; i++)
            {
                if (typedDataSet[i].Type == TextType.Text)
                {
                    if (!typedDataSet[i].Text.StartsWith("「") || !typedDataSet[i].Text.EndsWith("」"))
                    {
                        dataGridViewDS.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
        }

        private void удалитьВсеСплиттерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = typedDataSet.Count - 1; i >= 0; i--)
            {
                if (typedDataSet[i].Type == TextType.Splitter)
                {
                    typedDataSet.RemoveAt(i);
                }
            }
            dataGridViewDS.Refresh();
            dataGridViewDS.PerformLayout();
        }

        private void разбитьНепереведенноеНаNБлоковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_input fInput = new Form_input();
            fInput.textBoxInput.Text = 3.ToString();
            if (fInput.ShowDialog() != DialogResult.OK)
                return;
            SplitUntranslatedData(Convert.ToInt32(fInput.textBoxInput.Text), 4);
        }

        private void использоватьРезервноеПодключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (translator == null)
                return;
            использоватьРезервноеПодключениеToolStripMenuItem.Checked = !использоватьРезервноеПодключениеToolStripMenuItem.Checked;
            translator.SetReserveChatMode(использоватьРезервноеПодключениеToolStripMenuItem.Checked);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalAITranslator.Utils;

namespace UniversalAITranslator
{
    public partial class Form_ImageTranslator : Form
    {
        private Dictionary<string, List<BindingImageTranslationData>> dataSet;
        private BindingList<BindingImageTranslationData> translationDatas;
        //private BindingImageTranslationData currentTranslationData;
        private Image currentImage;
        private string imgPath;
        private AiTranslator translator;
        public event Extensions.TextDelegate ErrorLogged;
        public event Extensions.BoolDelegate TranslationCompleted;
        private bool selectionChanging = false;
        public Form_ImageTranslator(AiTranslator aiTranslator)
        {
            InitializeComponent();
            dataSet = new Dictionary<string, List<BindingImageTranslationData>>();
            translator = aiTranslator;
            translationDatas = new BindingList<BindingImageTranslationData>();
            dataGridViewTranslationData.DataSource = translationDatas;
            dataGridViewTranslationData.Refresh();
            dataGridViewTranslationData.Columns["OriginalText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTranslationData.Columns["TranslatedText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTranslationData.Columns["X"].Width = 50;
            dataGridViewTranslationData.Columns["Y"].Width = 50;
            dataGridViewTranslationData.Columns["Width"].Width = 50;
            dataGridViewTranslationData.Columns["Height"].Width = 50;
            RegisterFontSettingsChangedEvents();
            RegisterRectangleSettingsChangedEvents();
            comboBoxGradientAngle.SelectedIndex = 0;
        }

        private void RegisterFontSettingsChangedEvents()
        {
            textBoxFont.TextChanged += FontSettingsChanged;
            numericUpDownFontSize.ValueChanged += FontSettingsChanged;
            buttonFontColor.BackColorChanged += FontSettingsChanged;
            comboBoxAlign.SelectedValueChanged += FontSettingsChanged;
            numericUpDownLeading.ValueChanged += FontSettingsChanged;
            checkBoxIsStroke.CheckedChanged += FontSettingsChanged;
            numericUpDownStrokeSize.ValueChanged += FontSettingsChanged;
            buttonStrokeColor.BackColorChanged += FontSettingsChanged;
            numericUpDownOpacity.ValueChanged += FontSettingsChanged;
            checkBoxImageCenterX.CheckedChanged += FontSettingsChanged;
            checkBoxImageCenterY.CheckedChanged += FontSettingsChanged;
        }

        private void RegisterRectangleSettingsChangedEvents()
        {
            checkBoxIsRect.CheckedChanged += RectangleSettingsChanged;
            buttonRectColor.BackColorChanged += RectangleSettingsChanged;
        }

        private void FontSettingsChanged(object? sender, EventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0 || selectionChanging)
                return;
            for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
            {
                int rowIndex = dataGridViewTranslationData.SelectedCells[i].RowIndex;
                translationDatas[rowIndex].FontSettings.Update(GetTextFontDataFromControls());
            }

        }

        private void RectangleSettingsChanged(object? sender, EventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0 || selectionChanging)
                return;
            for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
            {
                int rowIndex = dataGridViewTranslationData.SelectedCells[i].RowIndex;
                translationDatas[rowIndex].RectangleSettings.Update(GetRectangleDataFromControls());
            }
        }

        private void Form_ImageTranslator_Load(object sender, EventArgs e)
        {
            comboBoxAlign.SelectedIndex = 1;
        }

        private void Form_ImageTranslator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBoxImage.Image != null)
                pictureBoxImage.Image.Dispose();
            pictureBoxImage.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = new Font(textBoxFont.Text, (float)numericUpDownFontSize.Value, FontStyle.Regular);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFont.Text = fontDialog.Font.Name;
                numericUpDownFontSize.Value = (int)fontDialog.Font.Size;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonFontColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonFontColor.BackColor = colorDialog.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonStrokeColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonStrokeColor.BackColor = colorDialog.Color;
        }

        private void SetTranslationData(string imagePath)
        {
            imgPath = imagePath;
            if (!dataSet.ContainsKey(imgPath) || dataSet[imgPath] == null)
            {
                translationDatas.Clear();
                dataGridViewTranslationData.Refresh();
                return;
            }
            currentImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(imgPath)));
            pictureBoxImage.Image = currentImage;
            translationDatas.Clear();
            //translationDatas = new BindingList<BindingImageTranslationData>(dataSet[imagePath]);
            //dataSet[imagePath].ForEach(a => translationDatas.Add(a.CreateBinding(pictureBoxImage.Image.Size.Width, pictureBoxImage.Image.Size.Height)));
            foreach (var item in dataSet[imagePath])
            {
                translationDatas.Add(item);
            }
            dataGridViewTranslationData.Refresh();

        }

        private void сохранитьСкриптДляPhotoshopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (translationDatas == null || translationDatas.Count == 0 || comboBoxAlign.SelectedIndex == -1)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "jsx files|*.jsx";
            saveFileDialog.DefaultExt = ".jsx";
            saveFileDialog.FileName = Path.Combine(Path.GetDirectoryName(imgPath), Path.GetFileNameWithoutExtension(imgPath) + ".jsx");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            SaveScript(imgPath, saveFileDialog.FileName);
            MessageBox.Show("Завершено");
        }

        public static void RunJsxWithoutWarning(string jsxFilePath)
        {
            try
            {
                // Получаем запущенный Photoshop или запускаем его
                Type psType = Type.GetTypeFromProgID("Photoshop.Application");
                if (psType == null) throw new Exception("Photoshop не установлен.");

                dynamic psApp = Activator.CreateInstance(psType);

                // Передаем скрипт на выполнение
                // Этот метод игнорирует окно "Trusted Source"
                psApp.DoJavaScriptFile(jsxFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке скрипта: " + ex.Message);
            }
        }

        private bool SaveScript(string imagePath, string savePath)
        {
            try
            {
                List<TextLayer> layers = new List<TextLayer>();
                List<RectangleLayer> rects = new List<RectangleLayer>();
                foreach (var item in dataSet[imagePath])
                {
                    TextLayer layer = new TextLayer();
                    layer.Text = item.TranslatedText;

                    float x = item.X;
                    float y = item.Y;

                    switch (item.FontSettings.Justification)
                    {
                        case "left":
                            layer.X = x;
                            break;
                        case "center":
                            layer.X = x + item.Width / 2f;
                            break;
                        case "right":
                            layer.X = x + item.Width;
                            break;
                    }
                    int fontSize = item.FontSettings.FontSize;
                    layer.Y = y + (item.Height / 2f);
                    if (item.FontSettings.CenterOnX)
                    {
                        var imgSize = item.GetImageSize();
                        layer.X = imgSize.Width / 2f;
                    }
                    if (item.FontSettings.CenterOnY)
                    {
                        var imgSize = item.GetImageSize();
                        layer.Y = imgSize.Height / 2f;
                    }
                    layer.FontName = item.FontSettings.FontName;
                    layer.FontSize = fontSize;
                    layer.Color = item.FontSettings.Color.ToHex();
                    layer.StrokeEnabled = item.FontSettings.StrokeEnabled;
                    layer.StrokePosition = item.FontSettings.StrokePosition;
                    layer.StrokeColor = item.FontSettings.StrokeColor.ToHex();
                    layer.StrokeSize = item.FontSettings.StrokeSize;
                    layer.Justification = item.FontSettings.Justification;
                    layer.StrokeOpacity = item.FontSettings.StrokeOpacity;
                    layer.Leading = item.FontSettings.Leading;
                    layers.Add(layer);

                    if (item.RectangleSettings.Visible)
                    {
                        RectangleLayer rectLayer = new RectangleLayer();
                        rectLayer.X = item.X;
                        rectLayer.Y = item.Y;
                        rectLayer.Width = item.Width;
                        rectLayer.Height = item.Height;
                        rectLayer.Color = item.RectangleSettings.Color.ToHex();
                        rectLayer.UseGradient = item.RectangleSettings.UseGradient;
                        rectLayer.GradientStartColor = item.RectangleSettings.GradientStartColor.ToHex();
                        rectLayer.GradientEndColor = item.RectangleSettings.GradientEndColor.ToHex();
                        rectLayer.GradientAngle = item.RectangleSettings.GradientAngle;
                        rects.Add(rectLayer);
                    }
                }
                ScriptGenerator.GenerateJSX(imagePath, layers, rects, savePath, checkBoxSaveBMP.Checked, checkBoxSavePSD.Checked);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void dataGridViewTranslationData_SelectionChanged(object sender, EventArgs e)
        {
            selectionChanging = true;
            UpdateImagePreview();
            selectionChanging = false;
        }

        private void UpdateImagePreview()
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            int rowIndex = dataGridViewTranslationData.SelectedCells[0].RowIndex;
            var currentTranslationData = translationDatas[rowIndex];
            SetTextFontDataToControls(currentTranslationData.FontSettings);
            SetRectangleDataToControls(currentTranslationData.RectangleSettings);
            var tempImage = (Image)currentImage.Clone();
            using (Graphics g = Graphics.FromImage(tempImage))
            {
                int x = (int)(currentTranslationData.X - 1);
                int y = (int)(currentTranslationData.Y - 1);
                int w = (int)(currentTranslationData.Width + 1);
                int h = (int)(currentTranslationData.Height + 1);
                g.DrawRectangle(new Pen(Color.Yellow, 2), x, y, w, h);
            }
            pictureBoxImage.Image = tempImage;
        }



        private void сохранитьСкриптИВыполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (translationDatas == null || translationDatas.Count == 0 || comboBoxAlign.SelectedIndex == -1)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "jsx files|*.jsx";
            saveFileDialog.DefaultExt = ".jsx";
            saveFileDialog.FileName = Path.Combine(Path.GetDirectoryName(imgPath), Path.GetFileNameWithoutExtension(imgPath) + ".jsx");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if (!SaveScript(imgPath, saveFileDialog.FileName))
            {
                MessageBox.Show("Завершено с ошибками");
                return;
            }

            RunJsxWithoutWarning(saveFileDialog.FileName.Replace('\\', '/'));
            //string[] estkPathes = ["C:\\Program Files (x86)\\Adobe\\Adobe ExtendScript Toolkit CC\\ExtendScript Toolkit.exe"];
            //foreach (var item in estkPathes)
            //{
            //    if (File.Exists(item))
            //    {
            //        Process.Start(item, $" -run {saveFileDialog.FileName.Replace('\\', '/')}");
            //        return;
            //    }
            //}
            //MessageBox.Show("Завершено");
        }


        private async void перевестиИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Выберите изображения для перевода";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if (translator == null)
                return;
            SetStatus("Идет перевод...");
            pictureBoxImage.Image = null;
            translationDatas.Clear();
            imgPath = "";
            if (currentImage != null)
                currentImage.Dispose();
            dataSet.Clear();
            dataGridViewImages.Rows.Clear();
            var defFont = GetTextFontDataFromControls();
            var defRect = GetRectangleDataFromControls();
            foreach (var item in openFileDialog.FileNames)
            {
                await TranslateImage(item, defFont, defRect);
                dataGridViewImages.Rows.Add(item);
            }

            SetStatus("Завершено!");
        }

        private async Task TranslateImage(string imagePath, TextFontData defFont, RectangleData defRect)
        {
            try
            {
                var result = await translator.TranslateImage(imagePath);
                if (result.data != null)
                {
                    List<BindingImageTranslationData> resLst = new List<BindingImageTranslationData>();
                    foreach (var item in result.data)
                    {
                        var data = item.CreateBinding(imagePath);
                        data.FontSettings = defFont.Clone();
                        data.RectangleSettings = defRect.Clone();
                        resLst.Add(data);
                    }
                    dataSet[imagePath] = resLst;
                }
                else
                {
                    ErrorLogged?.Invoke("Перевод завершен c ошибками:\n" + result.errText);
                    SetStatus("Перевод завершен c ошибками:\n" + result.errText);
                }
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
        }

        private void SetStatus(string status)
        {
            StatusLabel.Text = status;
        }

        private void dataGridViewImages_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            SetTranslationData(img);
        }

        private void сохранитьСкриптыДляВсехИзображенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataSet.Count == 0 || comboBoxAlign.SelectedIndex == -1)
                return;
            MessageBox.Show("Идет сохранение...");
            foreach (var item in dataSet)
            {
                string fName = Path.Combine(Path.GetDirectoryName(item.Key), Path.GetFileNameWithoutExtension(item.Key) + ".jsx");
                SaveScript(item.Key, fName);
            }
            MessageBox.Show("Завершено");
        }

        private async void повторитьПереводДляИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            MessageBox.Show("Идет перевод...");
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            var defFont = GetTextFontDataFromControls();
            var defRect = GetRectangleDataFromControls();
            await TranslateImage(img, defFont, defRect);
            SetTranslationData(img);
            MessageBox.Show("Завершено");
        }

        private Point startCoordinates;
        private bool startMove = false;
        private BindingImageTranslationData currentTransData;
        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            int rowIndex = dataGridViewTranslationData.SelectedCells[0].RowIndex;
            currentTransData = translationDatas[rowIndex];
            startCoordinates = e.Location;
            startMove = true;
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            startMove = false;
            if (currentTransData == null)
                return;
            Point subData = new Point(startCoordinates.X - e.Location.X, startCoordinates.Y - e.Location.Y);
            if (checkBoxChangeSize.Checked)
            {
                currentTransData.Width -= subData.X;
                currentTransData.Height -= subData.Y;
            }
            else
            {
                currentTransData.X -= subData.X;
                currentTransData.Y -= subData.Y;
            }
            dataGridViewTranslationData.Refresh();
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (startMove)
            {
                var tempImage = (Image)currentImage.Clone();
                Point subData = new Point(startCoordinates.X - e.Location.X, startCoordinates.Y - e.Location.Y);
                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    if (checkBoxChangeSize.Checked)
                    {
                        int x = (int)(currentTransData.X - 1);
                        int y = (int)(currentTransData.Y - 1);
                        int w = (int)(currentTransData.Width + 1) - subData.X;
                        int h = (int)(currentTransData.Height + 1) - subData.Y;
                        g.DrawRectangle(new Pen(Color.Yellow, 2), x, y, w, h);
                    }
                    else
                    {
                        int x = (int)(currentTransData.X - 1) - subData.X;
                        int y = (int)(currentTransData.Y - 1) - subData.Y;
                        int w = (int)(currentTransData.Width + 1);
                        int h = (int)(currentTransData.Height + 1);
                        g.DrawRectangle(new Pen(Color.Yellow, 2), x, y, w, h);
                    }
                }
                pictureBoxImage.Image = tempImage;
            }
        }

        private void Form_ImageTranslator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.ControlKey | Keys.Control))
                checkBoxChangeSize.Checked = true;
        }

        private void Form_ImageTranslator_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.ControlKey)
                checkBoxChangeSize.Checked = false;
        }

        private void сохранитьИВыполнитьВсеСкриптыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataSet.Count == 0 || comboBoxAlign.SelectedIndex == -1)
                return;
            SetStatus("Идет сохранение...");
            foreach (var item in dataSet)
            {
                string fName = Path.Combine(Path.GetDirectoryName(item.Key), Path.GetFileNameWithoutExtension(item.Key) + ".jsx");
                if (SaveScript(item.Key, fName))
                {
                    RunJsxWithoutWarning(fName.Replace('\\', '/'));
                }
            }
            SetStatus("Завершено");
        }

        public TextFontData GetTextFontDataFromControls()
        {
            TextFontData data = new TextFontData();
            data.FontName = textBoxFont.Text;
            data.FontSize = Convert.ToInt32(numericUpDownFontSize.Value);
            data.Color = buttonFontColor.BackColor;
            data.StrokeEnabled = checkBoxIsStroke.Checked;
            data.StrokePosition = "outside";
            data.StrokeColor = buttonStrokeColor.BackColor;
            data.StrokeSize = Convert.ToInt32(numericUpDownStrokeSize.Value);
            data.Justification = comboBoxAlign.SelectedItem.ToString();
            data.StrokeOpacity = Convert.ToInt32(numericUpDownOpacity.Value);
            data.Leading = numericUpDownLeading.Value == 0 ? null : (double)numericUpDownLeading.Value;
            data.CenterOnX = checkBoxImageCenterX.Checked;
            data.CenterOnY = checkBoxImageCenterY.Checked;
            return data;
        }

        public void SetTextFontDataToControls(TextFontData data)
        {
            textBoxFont.Text = data.FontName;
            numericUpDownFontSize.Value = data.FontSize;
            buttonFontColor.BackColor = data.Color;
            checkBoxIsStroke.Checked = data.StrokeEnabled;
            buttonStrokeColor.BackColor = buttonStrokeColor.BackColor;
            numericUpDownStrokeSize.Value = data.StrokeSize;
            comboBoxAlign.SelectedItem = data.Justification;
            numericUpDownOpacity.Value = data.StrokeOpacity;
            numericUpDownLeading.Value = data.Leading == null ? 0 : (decimal)data.Leading.Value;
            checkBoxImageCenterX.Checked = data.CenterOnX;
            checkBoxImageCenterY.Checked = data.CenterOnY;
        }

        public RectangleData GetRectangleDataFromControls()
        {
            RectangleData data = new RectangleData();
            data.Visible = checkBoxIsRect.Checked;
            data.Color = buttonRectColor.BackColor;
            data.UseGradient = checkBoxUseGradient.Checked;
            data.GradientStartColor = buttonGrStartColor.BackColor;
            data.GradientEndColor = buttonGrEndColor.BackColor;
            data.GradientAngle = Convert.ToDouble(comboBoxGradientAngle.SelectedItem);
            return data;
        }

        public void SetRectangleDataToControls(RectangleData data)
        {
            checkBoxIsRect.Checked = data.Visible;
            buttonRectColor.BackColor = data.Color;
            checkBoxUseGradient.Checked = data.UseGradient;
            buttonGrStartColor.BackColor = data.GradientStartColor;
            buttonGrEndColor.BackColor = data.GradientEndColor;
            comboBoxGradientAngle.SelectedItem = (int)data.GradientAngle;
        }

        private void buttonRectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonRectColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonRectColor.BackColor = colorDialog.Color;
        }

        private void автоматическиОбнаружитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatus("Идет определение цвета фона...");
            foreach (var imageData in dataSet)
            {
                using (Image img = Image.FromFile(imageData.Key))
                {
                    foreach (var textData in imageData.Value)
                    {
                        bool isGradient = BackgroundColorDetector.CheckIfGradientAndGetColors((Bitmap)img,
                            new Rectangle((int)textData.X, (int)textData.Y, (int)textData.Width, (int)textData.Height),
                            out Color topBg,
                            out Color bottomBg,
                            3,
                            20,
                            35);
                        if (isGradient)
                        {
                            textData.RectangleSettings.UseGradient = true;
                            textData.RectangleSettings.GradientStartColor = topBg;
                            textData.RectangleSettings.GradientEndColor = bottomBg;
                        }
                        else
                        {
                            textData.RectangleSettings.UseGradient = false;
                            textData.RectangleSettings.Color = topBg;
                        }
                        textData.RectangleSettings.Visible = true;
                    }
                }
            }
            SetStatus("Завершено!");
        }

        private void удалитьВыделенноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            List<BindingImageTranslationData> toDelete = new List<BindingImageTranslationData>();
            for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
            {
                toDelete.Add(translationDatas[dataGridViewTranslationData.SelectedCells[i].RowIndex]);
            }
            toDelete = toDelete.Distinct().ToList();
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            foreach (var item in toDelete)
            {
                translationDatas.Remove(item);
                dataSet[img].Remove(item);
            }
        }

        private void buttonGrStartColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonGrStartColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonGrStartColor.BackColor = colorDialog.Color;
        }

        private void buttonGrEndColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonGrEndColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonGrEndColor.BackColor = colorDialog.Color;
        }

        private PkmColorType GetCurrentPkmControl()
        {
            if (radioButtonRect.Checked)
                return PkmColorType.RectangleColor;
            else if (radioButtonRectGrTop.Checked)
                return PkmColorType.RectangleGradStart;
            else if (radioButtonRectGrDown.Checked)
                return PkmColorType.RectangleGradEnd;
            else if (radioButtonFont.Checked)
                return PkmColorType.FontColor;
            else
                return PkmColorType.FontStrokeColor;
        }

        private void SetColorByPkmColorType(Color c, PkmColorType type)
        {
            switch (type)
            {
                case PkmColorType.RectangleColor:
                    buttonRectColor.BackColor = c;
                    RectangleSettingsChanged(this, EventArgs.Empty);
                    break;
                case PkmColorType.RectangleGradStart:
                    buttonGrStartColor.BackColor = c;
                    RectangleSettingsChanged(this, EventArgs.Empty);
                    break;
                case PkmColorType.RectangleGradEnd:
                    buttonGrEndColor.BackColor = c;
                    RectangleSettingsChanged(this, EventArgs.Empty);
                    break;
                case PkmColorType.FontColor:
                    buttonFontColor.BackColor = c;
                    FontSettingsChanged(this, EventArgs.Empty);
                    break;
                case PkmColorType.FontStrokeColor:
                    buttonStrokeColor.BackColor = c;
                    FontSettingsChanged(this, EventArgs.Empty);
                    break;
                default:
                    throw new Exception("Тип не реализован!");
            }
        }

        private void SetRadioCheckedByPkmColorType(PkmColorType type)
        {
            radioButtonFont.Checked = false;
            radioButtonFontContur.Checked = false;
            radioButtonRect.Checked = false;
            radioButtonRectGrDown.Checked = false;
            radioButtonRectGrTop.Checked = false;
            switch (type)
            {
                case PkmColorType.RectangleColor:
                    radioButtonRect.Checked = true;
                    break;
                case PkmColorType.RectangleGradStart:
                    radioButtonRectGrTop.Checked = true;
                    break;
                case PkmColorType.RectangleGradEnd:
                    radioButtonRectGrDown.Checked = true;
                    break;
                case PkmColorType.FontColor:
                    radioButtonFont.Checked = true;
                    break;
                case PkmColorType.FontStrokeColor:
                    radioButtonFontContur.Checked = true;
                    break;
                default:
                    throw new Exception("Тип не реализован!");
            }
        }

        /// <summary>
        /// Вычисляет реальные координаты пикселя на изображении для PictureBox с режимом Zoom
        /// </summary>
        private Point? GetImageCoordinates(PictureBox picBox, Point mouseLocation)
        {
            Image img = picBox.Image;

            // Используем ClientSize, так как Width/Height могут включать рамки (BorderStyle)
            int controlWidth = picBox.ClientSize.Width;
            int controlHeight = picBox.ClientSize.Height;

            int imageWidth = img.Width;
            int imageHeight = img.Height;

            // Вычисляем коэффициенты масштабирования по осям
            float ratioX = (float)controlWidth / imageWidth;
            float ratioY = (float)controlHeight / imageHeight;

            // В режиме Zoom используется минимальный коэффициент, чтобы картинка влезла целиком
            float scale = Math.Min(ratioX, ratioY);

            // Вычисляем реальные размеры отображаемой картинки на экране
            float displayWidth = imageWidth * scale;
            float displayHeight = imageHeight * scale;

            // Вычисляем отступы (пустые области), так как картинка центрируется
            float offsetX = (controlWidth - displayWidth) / 2f;
            float offsetY = (controlHeight - displayHeight) / 2f;

            // Вычисляем координаты клика относительно самой картинки (убираем отступы)
            float relativeX = mouseLocation.X - offsetX;
            float relativeY = mouseLocation.Y - offsetY;

            // Проверяем, не кликнул ли пользователь по пустой области вокруг картинки
            if (relativeX < 0 || relativeX >= displayWidth ||
                relativeY < 0 || relativeY >= displayHeight)
            {
                return null; // Клик за пределами изображения
            }

            // Переводим экранные координаты в координаты оригинального изображения
            int actualX = (int)(relativeX / scale);
            int actualY = (int)(relativeY / scale);

            // Защита от выхода за границы массива (из-за округления)
            actualX = Math.Max(0, Math.Min(actualX, imageWidth - 1));
            actualY = Math.Max(0, Math.Min(actualY, imageHeight - 1));

            return new Point(actualX, actualY);
        }

        private void pictureBoxImage_MouseClick(object sender, MouseEventArgs e)
        {
            // Проверяем, что нажата именно правая кнопка мыши
            if (e.Button != MouseButtons.Right)
                return;

            // Проверяем, есть ли вообще картинка
            if (pictureBoxImage.Image == null || currentImage == null)
                return;

            // Получаем координаты пикселя
            Point? imagePoint = GetImageCoordinates(pictureBoxImage, e.Location);

            if (imagePoint.HasValue)
            {
                int x = imagePoint.Value.X;
                int y = imagePoint.Value.Y;
                Color pixelColor = ((Bitmap)currentImage).GetPixel(x, y);
                SetColorByPkmColorType(pixelColor, GetCurrentPkmControl());
            }
        }

        private void пКМЦветПрямоугольникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRadioCheckedByPkmColorType(PkmColorType.RectangleColor);
        }

        private void пКМЦветНачалаГрадиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRadioCheckedByPkmColorType(PkmColorType.RectangleGradStart);
        }

        private void пКМЦветКонцаГрадиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRadioCheckedByPkmColorType(PkmColorType.RectangleGradEnd);
        }

        private void пКМЦветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRadioCheckedByPkmColorType(PkmColorType.FontColor);
        }

        private void пКМЦветОбводкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRadioCheckedByPkmColorType(PkmColorType.FontStrokeColor);
        }

        private enum PkmColorType
        {
            RectangleColor,
            RectangleGradStart,
            RectangleGradEnd,
            FontColor,
            FontStrokeColor
        }
    }
}

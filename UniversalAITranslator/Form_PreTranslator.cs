using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalAITranslator
{
    public partial class Form_PreTranslator : Form
    {
        public BindingList<TranslationData> DataSet;
        private StructuredTranslationManager translationManager = null;
        private Form_TranslateDataset datasetTranslator = null;
        private List<KeyValuePair<string, string>> replacementDictonary;
        public Form_PreTranslator(List<KeyValuePair<string, string>> dictToReplace)
        {
            InitializeComponent();
            replacementDictonary = dictToReplace;
            DataSet = new BindingList<TranslationData>();
            dataGridViewDS.DataSource = DataSet;
            ApplyGridViewStyle();
        }



        private void RecreateTranslationManager()
        {
            if (datasetTranslator == null || datasetTranslator.IsDisposed)
            {
                datasetTranslator = new Form_TranslateDataset();
                replacementDictonary.ForEach(a => datasetTranslator.AddReplacementToDict(a.Key, a.Value));
                datasetTranslator.ErrorLogged += DatasetTranslator_ErrorLogged;
            }
        }

        private void DatasetTranslator_ErrorLogged(string text)
        {
            //Program.AddToLog(text);
        }

        private void TranslationTypedData(bool inPreviewColumn = false)
        {
            RecreateTranslationManager();


            Dictionary<int, KeyValuePair<string, string>> translationData = new Dictionary<int, KeyValuePair<string, string>>();
            for (int i = 0; i < DataSet.Count; i++)
            {
                translationData.Add(DataSet[i].Index, new KeyValuePair<string, string>(DataSet[i].OriginalText, DataSet[i].TranslatedText));
            }
            //Form_TranslateDataset translateDataset = new Form_TranslateDataset();
            datasetTranslator.SetDataToDataset(translationData);
            var fRes = datasetTranslator.ShowDialog();
            if (fRes == DialogResult.OK)
            {
                var result = datasetTranslator.GetData();
                foreach (var item in result)
                {
                    for (int i = 0; i < DataSet.Count; i++)
                    {
                        if (item.Id == DataSet[i].Index)
                        {
                            DataSet[i].PreviewText = item.TranslatedText;
                            if (inPreviewColumn)
                            {
                                DataSet[i].PreviewText = item.TranslatedText;
                            }
                            else
                            {
                                DataSet[i].TranslatedText = item.TranslatedText;
                            }
                            break;
                        }
                    }
                }
            }
            else if (fRes == DialogResult.Abort)
            {
                datasetTranslator.Close();
                datasetTranslator.Dispose();
            }
        }

        private void ApplyGridViewStyle()
        {
            dataGridViewDS.Columns["Index"].Width = 50;
            dataGridViewDS.Columns["OriginalText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDS.Columns["TranslatedText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDS.Columns["PreviewText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Form_PreTranslator_Load(object sender, EventArgs e)
        {

        }

        public List<TranslationData> GetData()
        {
            return DataSet.ToList();
        }


        public void AddDataItem(int index, string origText, string transText, string previewText = "")
        {
            var nItem = DataSet.AddNew();
            nItem.Index = index;
            nItem.OriginalText = origText;
            nItem.TranslatedText = transText;
            nItem.PreviewText = previewText;
        }


        public class TranslationData
        {
            public int Index { get; set; }
            public string OriginalText { get; set; } = "";
            public string TranslatedText { get; set; } = "";
            public string PreviewText { get; set; } = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDS.Columns["PreviewText"].Index)
                ReplaceTranslatedOnPreview();
        }

        private void ReplaceTranslatedOnPreview()
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                dataGridViewDS["TranslatedText", dataGridViewDS.SelectedCells[i].RowIndex].Value = dataGridViewDS["PreviewText", dataGridViewDS.SelectedCells[i].RowIndex].Value;
            }
        }

        private void ReplaceTranslatedOnOriginal()
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            for (int i = 0; i < dataGridViewDS.SelectedCells.Count; i++)
            {
                dataGridViewDS["TranslatedText", dataGridViewDS.SelectedCells[i].RowIndex].Value = dataGridViewDS["OriginalText", dataGridViewDS.SelectedCells[i].RowIndex].Value;
            }
        }

        private void заменитьВыделенныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceTranslatedOnPreview();
        }

        private void перевестиВСтолбецПереводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslationTypedData(false);
        }

        private void перевестиВСтолбецПредпросмотраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslationTypedData(true);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void восстановитьВыделенныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceTranslatedOnOriginal();
        }

        private void вставитьВВыделенныйСтолбецИзБуфераОбменаСНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int colIndex = dataGridViewDS.Columns["OriginalText"].Index;
            if (dataGridViewDS.SelectedCells.Count != 0)
                colIndex = dataGridViewDS.SelectedCells[0].ColumnIndex;
            PasteDataFromBufferInExistData(colIndex, 0);
        }

        private void PasteDataFromBufferInExistData(int columnIndex, int startIndex)
        {
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data))
                return;
            string sp1 = "\r\n";
            string sp2 = "\n";
            string[] lines = data.Split(data.Contains(sp1) ? sp1 : sp2);
            int lineIndex = 0;
            for (int i = startIndex; i < dataGridViewDS.RowCount; i++)
            {
                dataGridViewDS[columnIndex, i].Value = lines[lineIndex++];
            }
        }

        private void PasteOriginalDataFromBufferNewData()
        {
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data))
                return;
            data = data.Trim();
            string sp1 = "\r\n";
            string sp2 = "\n";
            string[] lines = data.Split(data.Contains(sp1) ? sp1 : sp2);
            int lineIndex = 0;
            DataSet.Clear();
            foreach (var line in lines)
            {
                DataSet.Add(new TranslationData() { Index = lineIndex++, OriginalText = line });
            }
        }

        private void PasteTwoPairDataFromBufferNewData()
        {
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data))
                return;
            string sp1 = "\r\n";
            string sp2 = "\n";
            string[] lines = data.Split(data.Contains(sp1) ? sp1 : sp2);
            int lineIndex = 0;
            DataSet.Clear();
            foreach (var line in lines)
            {
                if (line.Contains('=') || line.Contains('|') || line.Contains('\t'))
                {
                    string[] blocks = line.Split(['=', '|', '\t']);
                    if (blocks.Length != 2)
                    {
                        statusStrip1.Text = "Вставляемая строка содержит более 2 блоков!";
                        continue;
                    }
                    DataSet.Add(new TranslationData() { Index = lineIndex++, OriginalText = line });

                }
                else
                    continue;
            }
        }

        private void PasteTwoPairFromBuffer(int startIndex)
        {
            string data = Clipboard.GetText();
            if (string.IsNullOrEmpty(data))
                return;
            string sp1 = "\r\n";
            string sp2 = "\n";
            string[] lines = data.Split(data.Contains(sp1) ? sp1 : sp2);
            int lineIndex = 0;
            for (int i = startIndex; i < dataGridViewDS.RowCount; i++)
            {
                string line = lines[lineIndex++];
                if (line.Contains('=') || line.Contains('|'))
                {
                    string[] blocks = line.Split(['=', '|']);
                    if (blocks.Length != 2)
                    {
                        statusStrip1.Text = "Вставляемая строка содержит более 2 блоков!";
                        continue;
                    }
                    dataGridViewDS["OriginalText", i].Value = line[0];
                    dataGridViewDS["TranslatedText", i].Value = line[1];

                }
                else
                    continue;
            }
        }

        private void вставитьВВыделенныйСтолбецИзБуфераОбменаСВыделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            PasteDataFromBufferInExistData(dataGridViewDS.SelectedCells[0].ColumnIndex, dataGridViewDS.SelectedCells[0].RowIndex);
        }

        private void вставитьДанныеСРазделителемСВыделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDS.SelectedCells.Count == 0)
                return;
            PasteTwoPairFromBuffer(dataGridViewDS.SelectedCells[0].RowIndex);
        }

        private void вставитьВОригиналДанныеИзБуфераОбменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteOriginalDataFromBufferNewData();
        }

        private void вставитьДанныеСРазделителемСВыделенияНовыеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteTwoPairDataFromBufferNewData();
        }
    }
}

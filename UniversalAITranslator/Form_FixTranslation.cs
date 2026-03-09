using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalAITranslator
{
    public partial class Form_FixTranslation : Form
    {
        private GoogleTranslator translator;
        public int OriginalCount = 0;
        public int TranslatedCount = 0;
        private int currentRowIndex = -1;
        public Form_FixTranslation()
        {
            InitializeComponent();
            translator = new GoogleTranslator();
        }

        private async void buttonTranslate_Click(object sender, EventArgs e)
        {
            if (dataGridViewData.SelectedCells.Count == 0)
                return;
            string text = (string)dataGridViewData.SelectedCells[0].Value;
            textBoxTranslation.Text = await translator.TranslateAsync(text, "ja", "ru");
        }

        private void dataGridViewData_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewData.SelectedCells.Count != 1 || dataGridViewData.Columns[dataGridViewData.SelectedCells[0].ColumnIndex].Name != "TransText")
            {
                buttonSplitOnCaret.Enabled = false;
                currentRowIndex = -1;
                textBoxSelectedText.Text = "";
            }
            else
            {
                buttonSplitOnCaret.Enabled = true;
                textBoxSelectedText.Text = (string)dataGridViewData.SelectedCells[0].Value;
                currentRowIndex = dataGridViewData.SelectedCells[0].RowIndex;
            }
        }

        private void buttonSplitOnCaret_Click(object sender, EventArgs e)
        {
            if (OriginalCount <= TranslatedCount)
            {
                MessageBox.Show("Количество переведенных строк больше оригинала");
                return;
            }
            if (currentRowIndex == -1)
            {
                MessageBox.Show("Выделена ошибочная ячейка");
                return;
            }
            int caretPos = textBoxSelectedText.SelectionStart;
            string s1 = textBoxSelectedText.Text.Substring(0, caretPos);
            string s2 = textBoxSelectedText.Text.Substring(caretPos);
            bool first = true;
            string tempText = "";
            string tempName = "";
            dataGridViewData.SuspendLayout();
            for (int i = currentRowIndex; i < dataGridViewData.Rows.Count; i++)
            {
                if (first)
                {
                    tempText = (string)dataGridViewData["TransText", i + 1].Value;
                    tempName = (string)dataGridViewData["TransName", i + 1].Value;
                    first = false;
                    dataGridViewData["TransText", i].Value = s1;
                    dataGridViewData["TransText", i + 1].Value = s2;
                    dataGridViewData["TransName", i + 1].Value = dataGridViewData["TransName", i].Value;
                    i++;
                }
                else
                {
                    string tempText2 = (string)dataGridViewData["TransText", i].Value;
                    string tempName2 = (string)dataGridViewData["TransName", i].Value;
                    dataGridViewData["TransText", i].Value = tempText;
                    dataGridViewData["TransName", i].Value = tempName;
                    tempName = tempName2;
                    tempText = tempText2;
                }
            }
            dataGridViewData.ResumeLayout();
            TranslatedCount++;
            CheckCorrectData();
        }

        private void CheckCorrectData()
        {
            if (OriginalCount != TranslatedCount)
            {
                buttonSave.Enabled = false;
                toolStripStatusLabelStatus.Text = "ERROR";
                toolStripStatusLabelStatus.ForeColor = Color.Red;
            }
            else
            {
                buttonSave.Enabled = true;
                toolStripStatusLabelStatus.Text = "CLEAR";
                toolStripStatusLabelStatus.ForeColor = Color.Green;
            }
            TryFindBadString();
        }

        private void TryFindBadString()
        {
            try
            {
                for (int i = 0; i < dataGridViewData.RowCount; i++)
                {
                    string orig = dataGridViewData["OrigText", i].Value?.ToString();
                    string trans = dataGridViewData["TransText", i].Value?.ToString();
                    bool origQuoted = false;
                    if (orig.StartsWith('「'))
                        origQuoted = true;
                    bool transQuoted = false;
                    if (trans.StartsWith('「') || trans.StartsWith('«'))
                        transQuoted = true;
                    if (origQuoted != transQuoted)
                    {
                        dataGridViewData.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
            catch { }
        }

        private void Form_FixTranslation_Load(object sender, EventArgs e)
        {
            CheckCorrectData();
        }

        private void buttonJoinStrings_Click(object sender, EventArgs e)
        {
            if (OriginalCount >= TranslatedCount)
            {
                MessageBox.Show("Количество переведенных строк меньше оригинала");
                return;
            }
            if (dataGridViewData.SelectedCells.Count < 1)
            {
                MessageBox.Show("Не выделины ячейки");
                return;
            }
            List<int> selectedRowsIndexes = new List<int>();
            for (int i = 0; i < dataGridViewData.SelectedCells.Count; i++)
            {
                selectedRowsIndexes.Add(dataGridViewData.SelectedCells[i].RowIndex);
            }
            selectedRowsIndexes.Sort((a, b) => a.CompareTo(b));
            if (selectedRowsIndexes.Count != 2 || selectedRowsIndexes[1] - selectedRowsIndexes[0] != 1)
            {
                MessageBox.Show("Выделено больше двух ячеек или ячейки не являются смежными.");
                return;
            }
            string s1 = (string)dataGridViewData["TransText", selectedRowsIndexes[0]].Value;
            string s2 = (string)dataGridViewData["TransText", selectedRowsIndexes[1]].Value;

            dataGridViewData["TransText", selectedRowsIndexes[0]].Value = s1 + " " + s2;

            for (int i = selectedRowsIndexes[1]; i < dataGridViewData.Rows.Count - 1; i++)
            {
                dataGridViewData["TransText", i].Value = dataGridViewData["TransText", i + 1].Value;
                dataGridViewData["TransName", i].Value = dataGridViewData["TransName", i + 1].Value;
                dataGridViewData["TransText", i + 1].Value = "";
                dataGridViewData["TransName", i + 1].Value = "";
            }
            TranslatedCount--;
            CheckCorrectData();
        }

        public string[] GetTranslation()
        {
            List<string> translation = new List<string>();
            for (int i = 0; i < TranslatedCount; i++)
            {
                translation.Add((string)dataGridViewData["TransText", i].Value);
            }
            return translation.ToArray();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TranslatedCount++;
            CheckCorrectData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TranslatedCount--;
            CheckCorrectData();
        }
    }
}

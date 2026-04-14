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
    public partial class Form_AiCharaDictEditor : Form
    {
        private StructuredTranslationManager translationManager;
        public Form_AiCharaDictEditor()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            translationManager = new StructuredTranslationManager();
            //translationManager.LoadFromNamesDict();
            dataGridView1.DataSource = translationManager.Characters;
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files|*.json";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            dataGridView1.DataSource = null;
            translationManager = new StructuredTranslationManager();
            translationManager.Load(openFileDialog.FileName);
            dataGridView1.DataSource = translationManager.Characters;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json files|*.json";
            saveFileDialog.DefaultExt = ".json";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            translationManager.Save(saveFileDialog.FileName);
        }

        private void мужскойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGenderForSelected(StructuredTranslationManager.GenderCode.Male);
        }

        private void SetGenderForSelected(StructuredTranslationManager.GenderCode gender)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int rowIndex = dataGridView1.SelectedRows[i].Index;
                translationManager.Characters[rowIndex].Gender = gender;
            }
            dataGridView1.Refresh();
        }

        private void женскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGenderForSelected(StructuredTranslationManager.GenderCode.Female);
        }

        private void загрузитьИзТекстовогоСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "text  files|*.txt";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            dataGridView1.DataSource = null;
            translationManager = new StructuredTranslationManager();
            string[] lines = File.ReadAllLines(openFileDialog.FileName);

            foreach (string line in lines)
            {
                int firstIndex = line.IndexOf("=");
                if (firstIndex == -1)
                    continue;
                string orig = line.Substring(0, firstIndex);
                string trans = line.Substring(firstIndex + 1);
                translationManager.AddCharaInfo(orig, trans);
            }
            dataGridView1.DataSource = translationManager.Characters;
            dataGridView1.Refresh();
        }

        private void загрузитьЗначенияПолаИзДругогоСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files|*.json";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StructuredTranslationManager oldManager = new StructuredTranslationManager();
            oldManager.Load(openFileDialog.FileName);
            foreach (var item in translationManager.Characters)
            {
                var foundItem = oldManager.Characters.Find(a=>a.OriginalName == item.OriginalName);
                if (foundItem != null)
                {
                    item.Gender = foundItem.Gender;
                }
            }
            dataGridView1.Refresh();
        }
    }
}

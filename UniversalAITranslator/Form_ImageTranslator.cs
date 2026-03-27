using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalAITranslator.Utils;

namespace UniversalAITranslator
{
    public partial class Form_ImageTranslator : Form
    {
        private Dictionary<string, List<ImageTranslationData>> dataSet;
        private BindingList<BindingImageTranslationData> translationDatas;
        private Image currentImage;
        private string imgPath;
        private AiTranslator translator;
        public event Extensions.TextDelegate ErrorLogged;
        public event Extensions.BoolDelegate TranslationCompleted;
        public Form_ImageTranslator(AiTranslator aiTranslator)
        {
            InitializeComponent();
            dataSet = new Dictionary<string, List<ImageTranslationData>>();
            translator = aiTranslator;
            translationDatas = new BindingList<BindingImageTranslationData>();
            dataGridViewTranslationData.DataSource = translationDatas;
            dataGridViewTranslationData.Refresh();
            translationDatas.ListChanged += TranslationDatas_ListChanged;
            dataGridViewTranslationData.Columns["OriginalText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTranslationData.Columns["TranslatedText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTranslationData.Columns["X"].Width = 50;
            dataGridViewTranslationData.Columns["Y"].Width = 50;
            dataGridViewTranslationData.Columns["Width"].Width = 50;
            dataGridViewTranslationData.Columns["Height"].Width = 50;
        }

        private void TranslationDatas_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                translationDatas[e.OldIndex].UpdateOriginal();
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
            dataSet[imagePath].ForEach(a => translationDatas.Add(a.CreateBinding(pictureBoxImage.Image.Size.Width, pictureBoxImage.Image.Size.Height)));
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

        private bool SaveScript(string imagePath, string savePath)
        {
            try
            {
                List<TextLayer> layers = new List<TextLayer>();
                var modData = GetModifyData();
                foreach (var item in dataSet[imagePath].Select(a => a.CreateBinding(imagePath)))
                {
                    TextLayer layer = new TextLayer();
                    layer.Text = item.TranslatedText;

                    int x = (int)(item.X * modData.X_Multiply + modData.X_Addition);
                    int y = (int)(item.Y * modData.Y_Multiply + modData.Y_Addition);

                    switch (comboBoxAlign.SelectedItem.ToString())
                    {
                        case "left":
                            layer.X = x;
                            break;
                        case "center":
                            layer.X = x + (item.Width * modData.X_Multiply) / 2;
                            break;
                        case "right":
                            layer.X = x + (item.Width * modData.X_Multiply);
                            break;
                    }
                    //layer.X = item.X;
                    int fontSize = Convert.ToInt32(numericUpDownFontSize.Value);
                    layer.Y = y + ((item.Height * modData.Y_Multiply) / 2f + fontSize / 3f);
                    layer.FontName = textBoxFont.Text;
                    layer.FontSize = Convert.ToInt32(numericUpDownFontSize.Value);
                    layer.Color = buttonFontColor.BackColor.ToHex();
                    layer.StrokeEnabled = checkBoxIsStroke.Checked;
                    layer.StrokePosition = "outside";
                    layer.StrokeColor = buttonStrokeColor.BackColor.ToHex();
                    layer.StrokeSize = Convert.ToInt32(numericUpDownStrokeSize.Value);
                    layer.Justification = comboBoxAlign.SelectedItem.ToString();
                    layer.StrokeOpacity = Convert.ToInt32(numericUpDownOpacity.Value);
                    layers.Add(layer);
                }
                ScriptGenerator.GenerateJSX(imgPath, layers, savePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void dataGridViewTranslationData_SelectionChanged(object sender, EventArgs e)
        {
            UpdateImagePreview();
        }

        private void UpdateImagePreview()
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            int rowIndex = dataGridViewTranslationData.SelectedCells[0].RowIndex;
            var selectedData = translationDatas[rowIndex];

            var tempImage = (Image)currentImage.Clone();
            using (Graphics g = Graphics.FromImage(tempImage))
            {
                var modData = GetModifyData();
                int x = (int)(selectedData.X * modData.X_Multiply + modData.X_Addition - 1);
                int y = (int)(selectedData.Y * modData.Y_Multiply + modData.Y_Addition - 1);
                int w = (int)(selectedData.Width * modData.X_Multiply + 1);
                int h = (int)(selectedData.Height * modData.Y_Multiply + 1);
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
            string[] estkPathes = ["C:\\Program Files (x86)\\Adobe\\Adobe ExtendScript Toolkit CC\\ExtendScript Toolkit.exe"];
            foreach (var item in estkPathes)
            {
                if (File.Exists(item))
                {
                    Process.Start(item, $" -run {saveFileDialog.FileName.Replace('\\', '/')}");
                    return;
                }
            }
            //MessageBox.Show("Завершено");
        }

        private CoordinateModifyData GetModifyData()
        {
            CoordinateModifyData data = new CoordinateModifyData();
            data.X_Addition = (int)numericUpDownAdd_X.Value;
            data.Y_Addition = (int)numericUpDownAdd_Y.Value;
            data.X_Multiply = (float)numericUpDownMul_X.Value;
            data.Y_Multiply = (float)numericUpDownMul_Y.Value;
            return data;
        }

        private class CoordinateModifyData
        {
            public int X_Addition;
            public int Y_Addition;
            public float X_Multiply;
            public float Y_Multiply;
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
            foreach (var item in openFileDialog.FileNames)
            {
                await TranslateImage(item);
                dataGridViewImages.Rows.Add(item);
            }

            SetStatus("Завершено!");
        }

        private async Task TranslateImage(string imagePath)
        {
            try
            {
                var result = await translator.TranslateImage(imagePath);
                if (result.data != null)
                {
                    dataSet[imagePath] = result.data;
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
            await TranslateImage(img); SetTranslationData(img);
            MessageBox.Show("Завершено");
        }

        private void dataGridViewTranslationData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var item in translationDatas)
            {
                item.UpdateOriginal();
            }
        }
        private Point startCoordinates;
        private bool startMove = false;
        private BindingImageTranslationData currentTransData;
        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            int rowIndex = dataGridViewTranslationData.SelectedCells[0].RowIndex;
            currentTransData = translationDatas[rowIndex];
            startCoordinates = e.Location;
            startMove = true;
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            startMove = false;
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
                currentTransData.UpdateOriginal();
            dataGridViewTranslationData.Refresh();
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (startMove)
            {
                var tempImage = (Image)currentImage.Clone();
                Point subData = new Point(startCoordinates.X - e.Location.X, startCoordinates.Y - e.Location.Y);
                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    var modData = GetModifyData();
                    if (checkBoxChangeSize.Checked)
                    {
                        int x = (int)(currentTransData.X * modData.X_Multiply + modData.X_Addition - 1);
                        int y = (int)(currentTransData.Y * modData.Y_Multiply + modData.Y_Addition - 1);
                        int w = (int)(currentTransData.Width * modData.X_Multiply + 1) - subData.X;
                        int h = (int)(currentTransData.Height * modData.Y_Multiply + 1) - subData.Y;
                        g.DrawRectangle(new Pen(Color.Yellow, 2), x, y, w, h);
                    }
                    else
                    {
                        int x = (int)(currentTransData.X * modData.X_Multiply + modData.X_Addition - 1) - subData.X;
                        int y = (int)(currentTransData.Y * modData.Y_Multiply + modData.Y_Addition - 1) - subData.Y;
                        int w = (int)(currentTransData.Width * modData.X_Multiply + 1);
                        int h = (int)(currentTransData.Height * modData.Y_Multiply + 1);
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
    }
}

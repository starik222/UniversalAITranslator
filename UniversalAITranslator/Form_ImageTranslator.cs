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
        private Dictionary<int, PresetData> presets;
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
            presets = new Dictionary<int, PresetData>();
            toolStripStatusLabelMode.Text = GetCurrentPkmControl().ToString();
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
            checkBoxFontDrawOnAlpha.CheckedChanged += FontSettingsChanged;
        }

        private void RegisterRectangleSettingsChangedEvents()
        {
            checkBoxIsRect.CheckedChanged += RectangleSettingsChanged;
            buttonRectColor.BackColorChanged += RectangleSettingsChanged;
            checkBoxUseGradient.CheckedChanged += RectangleSettingsChanged;
            buttonGrStartColor.BackColorChanged += RectangleSettingsChanged;
            buttonGrEndColor.BackColorChanged += RectangleSettingsChanged;
            checkBoxRectDrawOnAlpha.CheckedChanged += RectangleSettingsChanged;
            comboBoxGradientAngle.SelectedIndexChanged += RectangleSettingsChanged;
        }

        private void FontSettingsChanged(object? sender, EventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0 || selectionChanging)
                return;
            if (dataGridViewImages.SelectedCells.Count == 1)
            {
                for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
                {
                    int rowIndex = dataGridViewTranslationData.SelectedCells[i].RowIndex;
                    translationDatas[rowIndex].FontSettings.Update(GetTextFontDataFromControls());
                }
            }
            else
            {
                for (int imgIndex = 0; imgIndex < dataGridViewImages.SelectedCells.Count; imgIndex++)
                {
                    string imgPath = (string)dataGridViewImages.SelectedCells[imgIndex].Value;
                    for (int i = 0; i < dataSet[imgPath].Count; i++)
                    {
                        dataSet[imgPath][i].FontSettings.Update(GetTextFontDataFromControls());
                    }
                }
            }

        }

        private void RectangleSettingsChanged(object? sender, EventArgs e)
        {
            if (dataGridViewTranslationData.SelectedCells.Count == 0 || selectionChanging)
                return;
            if (dataGridViewImages.SelectedCells.Count == 1)
            {
                for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
                {
                    int rowIndex = dataGridViewTranslationData.SelectedCells[i].RowIndex;
                    translationDatas[rowIndex].RectangleSettings.Update(GetRectangleDataFromControls());
                }
            }
            else
            {
                for (int imgIndex = 0; imgIndex < dataGridViewImages.SelectedCells.Count; imgIndex++)
                {
                    string imgPath = (string)dataGridViewImages.SelectedCells[imgIndex].Value;
                    for (int i = 0; i < dataSet[imgPath].Count; i++)
                    {
                        dataSet[imgPath][i].RectangleSettings.Update(GetRectangleDataFromControls());
                    }
                }
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
                    layer.DrawOnAlpha = item.FontSettings.DrawOnAlpha;
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
                        rectLayer.DrawOnAlpha = item.RectangleSettings.DrawOnAlpha;
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
            var tempImage = (Image)currentImage.Clone();
            for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
            {
                int rowIndex = dataGridViewTranslationData.SelectedCells[i].RowIndex;
                var currentTranslationData = translationDatas[rowIndex];
                SetTextFontDataToControls(currentTranslationData.FontSettings);
                SetRectangleDataToControls(currentTranslationData.RectangleSettings);
                int penWidth = 1;
                if (tempImage.Width > 300 || tempImage.Height > 300)
                    penWidth = 2;
                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    int x = (int)(currentTranslationData.X - 1);
                    int y = (int)(currentTranslationData.Y - 1);
                    int w = (int)(currentTranslationData.Width + 1);
                    int h = (int)(currentTranslationData.Height + 1);
                    g.DrawRectangle(new Pen(Color.Yellow, penWidth), x, y, w, h);
                }

            }
            Image oldImage = pictureBoxImage.Image;
            pictureBoxImage.Image = tempImage;
            if (oldImage != null && oldImage != currentImage)
            {
                oldImage.Dispose();
            }
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
            SetStatus("Идет сохранение...");
            foreach (var item in dataSet)
            {
                string fName = Path.Combine(Path.GetDirectoryName(item.Key), Path.GetFileNameWithoutExtension(item.Key) + ".jsx");
                SaveScript(item.Key, fName);
            }
            SetStatus("Завершено");
        }

        private async void повторитьПереводДляИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            SetStatus("Идет перевод...");
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            var defFont = GetTextFontDataFromControls();
            var defRect = GetRectangleDataFromControls();
            await TranslateImage(img, defFont, defRect);
            SetTranslationData(img);
            SetStatus("Завершено");
        }

        private Point startCoordinates;
        private bool startMove = false;
        private List<BindingImageTranslationData> currentTransDatas;
        private PointF GetScaleRatios()
        {
            // Если картинки нет или размеры нулевые, масштаб 1:1
            if (currentImage == null || currentImage.Width == 0 || currentImage.Height == 0)
                return new PointF(1f, 1f);

            float ratioX = 1f;
            float ratioY = 1f;

            // Расчет для режима Zoom (сохранение пропорций)
            if (pictureBoxImage.SizeMode == PictureBoxSizeMode.Zoom)
            {
                float ratio = Math.Min(
                    (float)pictureBoxImage.Width / currentImage.Width,
                    (float)pictureBoxImage.Height / currentImage.Height);
                ratioX = ratio;
                ratioY = ratio;
            }
            // Расчет для режима StretchImage (растягивание без сохранения пропорций)
            else if (pictureBoxImage.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                ratioX = (float)pictureBoxImage.Width / currentImage.Width;
                ratioY = (float)pictureBoxImage.Height / currentImage.Height;
            }

            return new PointF(ratioX, ratioY);
        }
        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (dataGridViewTranslationData.SelectedCells.Count == 0)
                return;
            currentTransDatas = new List<BindingImageTranslationData>();
            for (int i = 0; i < dataGridViewTranslationData.SelectedCells.Count; i++)
            {
                currentTransDatas.Add(translationDatas[dataGridViewTranslationData.SelectedCells[i].RowIndex]);
            }
            startCoordinates = e.Location;
            startMove = true;
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            startMove = false;
            if (currentTransDatas == null || currentTransDatas.Count == 0)
                return;

            // Получаем коэффициенты масштаба
            PointF scale = GetScaleRatios();

            // Переводим смещение мыши в смещение по координатам самого изображения
            int subX = (int)Math.Round((startCoordinates.X - e.Location.X) / scale.X);
            int subY = (int)Math.Round((startCoordinates.Y - e.Location.Y) / scale.Y);

            foreach (var item in currentTransDatas)
            {
                if (checkBoxChangeSize.Checked)
                {
                    item.Width -= subX;
                    item.Height -= subY;
                }
                else
                {
                    item.X -= subX;
                    item.Y -= subY;
                }
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

                // Получаем коэффициенты масштаба
                PointF scale = GetScaleRatios();

                // Переводим смещение мыши в смещение по координатам самого изображения
                int subX = (int)Math.Round((startCoordinates.X - e.Location.X) / scale.X);
                int subY = (int)Math.Round((startCoordinates.Y - e.Location.Y) / scale.Y);
                int penWidth = 1;
                if (tempImage.Width > 300 || tempImage.Height > 300)
                    penWidth = 2;
                using (Graphics g = Graphics.FromImage(tempImage))
                {
                    foreach (var item in currentTransDatas)
                    {
                        if (checkBoxChangeSize.Checked)
                        {
                            int x = (int)(item.X - 1);
                            int y = (int)(item.Y - 1);
                            int w = (int)(item.Width + 1) - subX;
                            int h = (int)(item.Height + 1) - subY;
                            g.DrawRectangle(new Pen(Color.Yellow, penWidth), x, y, w, h);
                        }
                        else
                        {
                            int x = (int)(item.X - 1) - subX;
                            int y = (int)(item.Y - 1) - subY;
                            int w = (int)(item.Width + 1);
                            int h = (int)(item.Height + 1);
                            g.DrawRectangle(new Pen(Color.Yellow, penWidth), x, y, w, h);
                        }
                    }
                }

                // ВАЖНО: Освобождаем старое изображение, чтобы избежать утечки памяти (OutOfMemoryException)
                Image oldImage = pictureBoxImage.Image;
                pictureBoxImage.Image = tempImage;
                if (oldImage != null && oldImage != currentImage)
                {
                    oldImage.Dispose();
                }
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
            data.DrawOnAlpha = checkBoxFontDrawOnAlpha.Checked;
            return data;
        }

        public void SetTextFontDataToControls(TextFontData data)
        {
            textBoxFont.Text = data.FontName;
            numericUpDownFontSize.Value = data.FontSize;
            buttonFontColor.BackColor = data.Color;
            checkBoxIsStroke.Checked = data.StrokeEnabled;
            buttonStrokeColor.BackColor = data.StrokeColor;
            numericUpDownStrokeSize.Value = data.StrokeSize;
            comboBoxAlign.SelectedItem = data.Justification;
            numericUpDownOpacity.Value = data.StrokeOpacity;
            numericUpDownLeading.Value = data.Leading == null ? 0 : (decimal)data.Leading.Value;
            checkBoxImageCenterX.Checked = data.CenterOnX;
            checkBoxImageCenterY.Checked = data.CenterOnY;
            checkBoxFontDrawOnAlpha.Checked = data.DrawOnAlpha;
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
            data.DrawOnAlpha = checkBoxRectDrawOnAlpha.Checked;
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
            checkBoxRectDrawOnAlpha.Checked = data.DrawOnAlpha;
        }

        private void buttonRectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = buttonRectColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            buttonRectColor.BackColor = colorDialog.Color;
            checkBoxIsRect.Checked = true;
        }

        private void автоматическиОбнаружитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatus("Идет определение цвета фона...");
            foreach (var imageData in dataSet)
            {
                DetectRectangleFillColor(imageData.Key);
            }
            SetStatus("Завершено!");
        }

        private void DetectRectangleFillColor(string image)
        {
            using (Image img = Image.FromFile(image))
            {
                foreach (var textData in dataSet[image])
                {
                    bool isGradient = BackgroundColorDetector.CheckIfGradientAndGetColors((Bitmap)img,
                        new Rectangle((int)textData.X, (int)textData.Y, (int)textData.Width, (int)textData.Height),
                        out Color topBg,
                        out Color bottomBg,
                        2,
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
                        textData.RectangleSettings.Color = BackgroundColorDetector.GetBackgroundColor((Bitmap)img,
                        new Rectangle((int)textData.X, (int)textData.Y, (int)textData.Width, (int)textData.Height), 2);
                    }
                    textData.RectangleSettings.Visible = true;
                }
            }
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
                    checkBoxIsRect.Checked = true;
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
            toolStripStatusLabelMode.Text = GetCurrentPkmControl().ToString();
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
                toolStripStatusLabelColor.BackColor = pixelColor;
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

        private void toolStripButtonAddPreset_Click(object sender, EventArgs e)
        {
            int curIndex = presets.Count == 0 ? 0 : presets.Max(a => a.Key) + 1;
            PresetData preset = new PresetData();
            preset.GradientStartColor = buttonGrStartColor.BackColor;
            preset.GradientEndColor = buttonGrEndColor.BackColor;
            preset.FontColor = buttonFontColor.BackColor;
            preset.FontStrokeColor = buttonStrokeColor.BackColor;
            preset.RectangleColor = buttonRectColor.BackColor;
            preset.IsGradient = checkBoxUseGradient.Checked;
            preset.DrawRectangle = checkBoxIsRect.Checked;
            presets[curIndex] = preset;
            dataGridViewPresets.Rows.Add(curIndex, preset.FontColor.ToHex(), preset.FontStrokeColor.ToHex(),
                preset.IsGradient ? "-" : preset.RectangleColor.ToHex(),
                preset.IsGradient ? preset.GradientStartColor.ToHex() : "-", preset.IsGradient ? preset.GradientEndColor.ToHex() : "-",
                preset.DrawRectangle, preset.IsGradient);
            int dataIndex = dataGridViewPresets.Rows.Count - 1;
            dataGridViewPresets["ColFontColor", dataIndex].Style.BackColor = preset.FontColor;
            dataGridViewPresets["ColFontStrokeColor", dataIndex].Style.BackColor = preset.FontStrokeColor;
            dataGridViewPresets["ColRectangleColor", dataIndex].Style.BackColor = preset.RectangleColor;
            dataGridViewPresets["ColGradStart", dataIndex].Style.BackColor = preset.GradientStartColor;
            dataGridViewPresets["ColGradEnd", dataIndex].Style.BackColor = preset.GradientEndColor;
        }
        private void toolStripButtonRemovePreset_Click(object sender, EventArgs e)
        {
            if (dataGridViewPresets.SelectedCells.Count == 0)
                return;
            int index = (int)dataGridViewPresets["ColIndex", dataGridViewPresets.SelectedCells[0].RowIndex].Value;
            dataGridViewPresets.Rows.RemoveAt(dataGridViewPresets.SelectedCells[0].RowIndex);
            presets.Remove(index);
        }

        private enum PkmColorType
        {
            RectangleColor,
            RectangleGradStart,
            RectangleGradEnd,
            FontColor,
            FontStrokeColor
        }
        private class PresetData
        {
            public Color FontColor { get; set; }
            public Color FontStrokeColor { get; set; }
            public bool DrawRectangle { get; set; }
            public bool IsGradient { get; set; }
            public Color RectangleColor { get; set; }
            public Color GradientStartColor { get; set; }
            public Color GradientEndColor { get; set; }
        }

        private void dataGridViewPresets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            int index = (int)dataGridViewPresets["ColIndex", e.RowIndex].Value;
            var preset = presets[index];
            buttonGrStartColor.BackColor = preset.GradientStartColor;
            buttonGrEndColor.BackColor = preset.GradientEndColor;
            buttonFontColor.BackColor = preset.FontColor;
            buttonStrokeColor.BackColor = preset.FontStrokeColor;
            buttonRectColor.BackColor = preset.RectangleColor;
            checkBoxIsRect.Checked = preset.DrawRectangle;
            checkBoxUseGradient.Checked = preset.IsGradient;
            RectangleSettingsChanged(this, EventArgs.Empty);
            FontSettingsChanged(this, EventArgs.Empty);
        }

        private void создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataSet)
            {
                sb.AppendLine($"{item.Value.First().OriginalText}\t{item.Value.First().TranslatedText}\t{item.Key}");
            }
            NotepadHelper.ShowMessage(sb.ToString());
        }

        private void применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyCurrentCoordinatesToOther();
        }

        private void ApplyCurrentCoordinatesToOther()
        {
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            var curTransData = dataSet[img];
            foreach (var item in dataSet)
            {
                if (item.Value == curTransData || item.Value.Count != curTransData.Count)
                    continue;
                for (int j = 0; j < curTransData.Count; j++)
                {
                    item.Value[j].X = curTransData[j].X;
                    item.Value[j].Y = curTransData[j].Y;
                    item.Value[j].Width = curTransData[j].Width;
                    item.Value[j].Height = curTransData[j].Height;
                }
            }
        }

        private void ApplyCurrentFontSettingsToOther()
        {
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            var curTransData = dataSet[img];
            foreach (var item in dataSet)
            {
                if (item.Value == curTransData || item.Value.Count != curTransData.Count)
                    continue;
                for (int j = 0; j < curTransData.Count; j++)
                {
                    item.Value[j].FontSettings.Update(curTransData[j].FontSettings);
                }
            }
        }

        private void ApplyCurrentRectSettingsToOther()
        {
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            var curTransData = dataSet[img];
            foreach (var item in dataSet)
            {
                if (item.Value == curTransData || item.Value.Count != curTransData.Count)
                    continue;
                for (int j = 0; j < curTransData.Count; j++)
                {
                    item.Value[j].RectangleSettings.Update(curTransData[j].RectangleSettings);
                }
            }
        }

        private void применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyCurrentCoordinatesToOther();
            ApplyCurrentFontSettingsToOther();
            ApplyCurrentRectSettingsToOther();
        }

        private void автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string img = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[0].RowIndex].Value;
            DetectRectangleFillColor(img);
        }

        private void применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curFontSettings = GetTextFontDataFromControls();
            foreach (var item in dataSet)
            {
                foreach (var transData in item.Value)
                {
                    transData.FontSettings.FontName = curFontSettings.FontName;
                    transData.FontSettings.FontSize = curFontSettings.FontSize;
                    transData.FontSettings.Leading = curFontSettings.Leading;
                    transData.FontSettings.StrokeSize = curFontSettings.StrokeSize;
                    transData.FontSettings.StrokeEnabled = curFontSettings.StrokeEnabled;
                }
            }
        }

        private void применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyCurrentRectSettingsToOther();
        }

        private void применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyCurrentFontSettingsToOther();
        }

        private void добавитьИзображенияБезПереводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Выберите изображения для перевода";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            foreach (var item in openFileDialog.FileNames)
            {
                dataSet[item] = new List<BindingImageTranslationData>();
                dataGridViewImages.Rows.Add(item);
            }
        }
        private SortedDictionary<int, string> copiedData = new SortedDictionary<int, string>();
        private void копироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            copiedData.Clear();
            for (int i = 0; i < dataGridViewImages.SelectedCells.Count; i++)
            {
                copiedData[dataGridViewImages.SelectedCells[i].RowIndex] = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[i].RowIndex].Value;
            }
        }

        private void вставитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            if (dataGridViewImages.SelectedCells.Count != copiedData.Count)
            {
                MessageBox.Show("Количество скопированных записей не совпадает с количеством выделенных");
                return;
            }
            SortedDictionary<int, string> pastingData = new SortedDictionary<int, string>();
            for (int i = 0; i < dataGridViewImages.SelectedCells.Count; i++)
            {
                pastingData[dataGridViewImages.SelectedCells[i].RowIndex] = (string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[i].RowIndex].Value;
            }
            List<string> sortedCopiedData = copiedData.Values.ToList();
            int index = 0;
            foreach (string data in pastingData.Values)
            {
                int height = 0;
                int width = 0;
                using (var fileStream = new FileStream(data, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var image = Image.FromStream(fileStream, false, false))
                    {
                        height = image.Height;
                        width = image.Width;
                    }
                }
                dataSet[data].Clear();

                dataSet[data].AddRange(dataSet[sortedCopiedData[index]].Select(a => a.Clone(width, height)));
                index++;
            }
        }

        private void автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatus("Идет определение цвета фона...");
            if (dataGridViewImages.SelectedCells.Count == 0)
                return;
            copiedData.Clear();
            for (int i = 0; i < dataGridViewImages.SelectedCells.Count; i++)
            {
                DetectRectangleFillColor((string)dataGridViewImages["ImagePath", dataGridViewImages.SelectedCells[i].RowIndex].Value);
            }
            SetStatus("Завершено!");
        }

        private void изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in dataSet.Keys)
            {
                ChangeCoordinatesByImageSize(item, 1);
            }
            dataGridViewTranslationData.Refresh();
        }

        private void ChangeCoordinatesByImageSize(string imgPath, int padding)
        {
            foreach (var item in dataSet[imgPath])
            {
                item.ChangeCoordinatesByImageSize(padding);
            }
        }
    }
}

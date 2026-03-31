namespace UniversalAITranslator
{
    partial class Form_ImageTranslator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            перевестиИзображенияToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            сохранитьСкриптДляPhotoshopToolStripMenuItem = new ToolStripMenuItem();
            сохранитьСкриптИВыполнитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem = new ToolStripMenuItem();
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            повторитьПереводДляИзображенияToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            автоматическиОбнаружитьЦветФонаToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPageFont = new TabPage();
            checkBoxImageCenterY = new CheckBox();
            checkBoxImageCenterX = new CheckBox();
            button1 = new Button();
            numericUpDownOpacity = new NumericUpDown();
            numericUpDownLeading = new NumericUpDown();
            label7 = new Label();
            textBoxFont = new TextBox();
            numericUpDownStrokeSize = new NumericUpDown();
            label14 = new Label();
            buttonStrokeColor = new Button();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            checkBoxIsStroke = new CheckBox();
            label5 = new Label();
            numericUpDownFontSize = new NumericUpDown();
            comboBoxAlign = new ComboBox();
            buttonFontColor = new Button();
            label6 = new Label();
            label3 = new Label();
            tabPageRectangle = new TabPage();
            checkBoxIsRect = new CheckBox();
            buttonRectColor = new Button();
            tabPageGeneral = new TabPage();
            checkBoxChangeSize = new CheckBox();
            checkBoxSavePSD = new CheckBox();
            checkBoxSaveBMP = new CheckBox();
            dataGridViewImages = new DataGridView();
            ImagePath = new DataGridViewTextBoxColumn();
            dataGridViewTranslationData = new DataGridView();
            pictureBoxImage = new PictureBox();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            текстовыеДанныеToolStripMenuItem = new ToolStripMenuItem();
            удалитьВыделенноеToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrokeSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).BeginInit();
            tabPageRectangle.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTranslationData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, операцииToolStripMenuItem, текстовыеДанныеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1080, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { перевестиИзображенияToolStripMenuItem, toolStripSeparator1, сохранитьСкриптДляPhotoshopToolStripMenuItem, сохранитьСкриптИВыполнитьToolStripMenuItem, toolStripSeparator2, сохранитьСкриптыДляВсехИзображенийToolStripMenuItem, сохранитьИВыполнитьВсеСкриптыToolStripMenuItem, toolStripSeparator3, повторитьПереводДляИзображенияToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // перевестиИзображенияToolStripMenuItem
            // 
            перевестиИзображенияToolStripMenuItem.Name = "перевестиИзображенияToolStripMenuItem";
            перевестиИзображенияToolStripMenuItem.Size = new Size(310, 22);
            перевестиИзображенияToolStripMenuItem.Text = "Перевести изображения...";
            перевестиИзображенияToolStripMenuItem.Click += перевестиИзображенияToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(307, 6);
            // 
            // сохранитьСкриптДляPhotoshopToolStripMenuItem
            // 
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Name = "сохранитьСкриптДляPhotoshopToolStripMenuItem";
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Size = new Size(310, 22);
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Text = "Сохранить скрипт для Photoshop";
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Click += сохранитьСкриптДляPhotoshopToolStripMenuItem_Click;
            // 
            // сохранитьСкриптИВыполнитьToolStripMenuItem
            // 
            сохранитьСкриптИВыполнитьToolStripMenuItem.Name = "сохранитьСкриптИВыполнитьToolStripMenuItem";
            сохранитьСкриптИВыполнитьToolStripMenuItem.Size = new Size(310, 22);
            сохранитьСкриптИВыполнитьToolStripMenuItem.Text = "Сохранить скрипт и выполнить";
            сохранитьСкриптИВыполнитьToolStripMenuItem.Click += сохранитьСкриптИВыполнитьToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(307, 6);
            // 
            // сохранитьСкриптыДляВсехИзображенийToolStripMenuItem
            // 
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Name = "сохранитьСкриптыДляВсехИзображенийToolStripMenuItem";
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Size = new Size(310, 22);
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Text = "Сохранить скрипты для всех изображений";
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Click += сохранитьСкриптыДляВсехИзображенийToolStripMenuItem_Click;
            // 
            // сохранитьИВыполнитьВсеСкриптыToolStripMenuItem
            // 
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Name = "сохранитьИВыполнитьВсеСкриптыToolStripMenuItem";
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Size = new Size(310, 22);
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Text = "Сохранить и выполнить все скрипты";
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Click += сохранитьИВыполнитьВсеСкриптыToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(307, 6);
            // 
            // повторитьПереводДляИзображенияToolStripMenuItem
            // 
            повторитьПереводДляИзображенияToolStripMenuItem.Name = "повторитьПереводДляИзображенияToolStripMenuItem";
            повторитьПереводДляИзображенияToolStripMenuItem.Size = new Size(310, 22);
            повторитьПереводДляИзображенияToolStripMenuItem.Text = "Повторить перевод для изображения";
            повторитьПереводДляИзображенияToolStripMenuItem.Click += повторитьПереводДляИзображенияToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { автоматическиОбнаружитьЦветФонаToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // автоматическиОбнаружитьЦветФонаToolStripMenuItem
            // 
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Name = "автоматическиОбнаружитьЦветФонаToolStripMenuItem";
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Size = new Size(288, 22);
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Text = "Автоматически обнаружить цвет фона";
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Click += автоматическиОбнаружитьЦветФонаToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            splitContainer1.Panel1.Controls.Add(dataGridViewImages);
            splitContainer1.Panel1.Controls.Add(dataGridViewTranslationData);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBoxImage);
            splitContainer1.Size = new Size(1080, 725);
            splitContainer1.SplitterDistance = 501;
            splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tabControl1.Controls.Add(tabPageFont);
            tabControl1.Controls.Add(tabPageRectangle);
            tabControl1.Controls.Add(tabPageGeneral);
            tabControl1.Location = new Point(3, 475);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(495, 247);
            tabControl1.TabIndex = 17;
            // 
            // tabPageFont
            // 
            tabPageFont.Controls.Add(checkBoxImageCenterY);
            tabPageFont.Controls.Add(checkBoxImageCenterX);
            tabPageFont.Controls.Add(button1);
            tabPageFont.Controls.Add(numericUpDownOpacity);
            tabPageFont.Controls.Add(numericUpDownLeading);
            tabPageFont.Controls.Add(label7);
            tabPageFont.Controls.Add(textBoxFont);
            tabPageFont.Controls.Add(numericUpDownStrokeSize);
            tabPageFont.Controls.Add(label14);
            tabPageFont.Controls.Add(buttonStrokeColor);
            tabPageFont.Controls.Add(label1);
            tabPageFont.Controls.Add(label4);
            tabPageFont.Controls.Add(label2);
            tabPageFont.Controls.Add(checkBoxIsStroke);
            tabPageFont.Controls.Add(label5);
            tabPageFont.Controls.Add(numericUpDownFontSize);
            tabPageFont.Controls.Add(comboBoxAlign);
            tabPageFont.Controls.Add(buttonFontColor);
            tabPageFont.Controls.Add(label6);
            tabPageFont.Controls.Add(label3);
            tabPageFont.Location = new Point(4, 24);
            tabPageFont.Name = "tabPageFont";
            tabPageFont.Padding = new Padding(3);
            tabPageFont.Size = new Size(487, 219);
            tabPageFont.TabIndex = 0;
            tabPageFont.Text = "Шрифт";
            tabPageFont.UseVisualStyleBackColor = true;
            // 
            // checkBoxImageCenterY
            // 
            checkBoxImageCenterY.AutoSize = true;
            checkBoxImageCenterY.Location = new Point(241, 115);
            checkBoxImageCenterY.Name = "checkBoxImageCenterY";
            checkBoxImageCenterY.Size = new Size(229, 19);
            checkBoxImageCenterY.TabIndex = 21;
            checkBoxImageCenterY.Text = "Центрировать по изображению по Y";
            checkBoxImageCenterY.UseVisualStyleBackColor = true;
            // 
            // checkBoxImageCenterX
            // 
            checkBoxImageCenterX.AutoSize = true;
            checkBoxImageCenterX.Location = new Point(6, 115);
            checkBoxImageCenterX.Name = "checkBoxImageCenterX";
            checkBoxImageCenterX.Size = new Size(229, 19);
            checkBoxImageCenterX.TabIndex = 21;
            checkBoxImageCenterX.Text = "Центрировать по изображению по X";
            checkBoxImageCenterX.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(218, 7);
            button1.Name = "button1";
            button1.Size = new Size(27, 23);
            button1.TabIndex = 3;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDownOpacity
            // 
            numericUpDownOpacity.Location = new Point(387, 79);
            numericUpDownOpacity.Name = "numericUpDownOpacity";
            numericUpDownOpacity.Size = new Size(79, 23);
            numericUpDownOpacity.TabIndex = 16;
            numericUpDownOpacity.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numericUpDownLeading
            // 
            numericUpDownLeading.DecimalPlaces = 1;
            numericUpDownLeading.Location = new Point(384, 43);
            numericUpDownLeading.Name = "numericUpDownLeading";
            numericUpDownLeading.Size = new Size(75, 23);
            numericUpDownLeading.TabIndex = 18;
            numericUpDownLeading.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(314, 82);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 15;
            label7.Text = "Видимость";
            // 
            // textBoxFont
            // 
            textBoxFont.Location = new Point(42, 7);
            textBoxFont.Name = "textBoxFont";
            textBoxFont.Size = new Size(175, 23);
            textBoxFont.TabIndex = 2;
            textBoxFont.Text = "Franklin Gothic Medium Cond";
            // 
            // numericUpDownStrokeSize
            // 
            numericUpDownStrokeSize.Location = new Point(118, 79);
            numericUpDownStrokeSize.Name = "numericUpDownStrokeSize";
            numericUpDownStrokeSize.Size = new Size(57, 23);
            numericUpDownStrokeSize.TabIndex = 11;
            numericUpDownStrokeSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(223, 46);
            label14.Name = "label14";
            label14.Size = new Size(151, 15);
            label14.TabIndex = 17;
            label14.Text = "Межстрочное расстояние";
            // 
            // buttonStrokeColor
            // 
            buttonStrokeColor.BackColor = Color.Black;
            buttonStrokeColor.Location = new Point(224, 79);
            buttonStrokeColor.Name = "buttonStrokeColor";
            buttonStrokeColor.Size = new Size(75, 23);
            buttonStrokeColor.TabIndex = 10;
            buttonStrokeColor.UseVisualStyleBackColor = false;
            buttonStrokeColor.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 10);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Font";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 82);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 9;
            label4.Text = "Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 10);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Size";
            // 
            // checkBoxIsStroke
            // 
            checkBoxIsStroke.AutoSize = true;
            checkBoxIsStroke.Checked = true;
            checkBoxIsStroke.CheckState = CheckState.Checked;
            checkBoxIsStroke.Location = new Point(6, 81);
            checkBoxIsStroke.Name = "checkBoxIsStroke";
            checkBoxIsStroke.Size = new Size(73, 19);
            checkBoxIsStroke.TabIndex = 6;
            checkBoxIsStroke.Text = "Обводка";
            checkBoxIsStroke.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(185, 82);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 8;
            label5.Text = "Цвет";
            // 
            // numericUpDownFontSize
            // 
            numericUpDownFontSize.Location = new Point(284, 8);
            numericUpDownFontSize.Name = "numericUpDownFontSize";
            numericUpDownFontSize.Size = new Size(55, 23);
            numericUpDownFontSize.TabIndex = 12;
            numericUpDownFontSize.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // comboBoxAlign
            // 
            comboBoxAlign.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlign.FormattingEnabled = true;
            comboBoxAlign.Items.AddRange(new object[] { "left", "center", "right" });
            comboBoxAlign.Location = new Point(96, 43);
            comboBoxAlign.Name = "comboBoxAlign";
            comboBoxAlign.Size = new Size(121, 23);
            comboBoxAlign.TabIndex = 14;
            // 
            // buttonFontColor
            // 
            buttonFontColor.BackColor = Color.White;
            buttonFontColor.Location = new Point(384, 7);
            buttonFontColor.Name = "buttonFontColor";
            buttonFontColor.Size = new Size(75, 23);
            buttonFontColor.TabIndex = 7;
            buttonFontColor.UseVisualStyleBackColor = false;
            buttonFontColor.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(2, 46);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 13;
            label6.Text = "Выравнивание";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 10);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 8;
            label3.Text = "Цвет";
            // 
            // tabPageRectangle
            // 
            tabPageRectangle.Controls.Add(checkBoxIsRect);
            tabPageRectangle.Controls.Add(buttonRectColor);
            tabPageRectangle.Location = new Point(4, 24);
            tabPageRectangle.Name = "tabPageRectangle";
            tabPageRectangle.Padding = new Padding(3);
            tabPageRectangle.Size = new Size(487, 219);
            tabPageRectangle.TabIndex = 1;
            tabPageRectangle.Text = "Прямоугольник";
            tabPageRectangle.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsRect
            // 
            checkBoxIsRect.AutoSize = true;
            checkBoxIsRect.Location = new Point(6, 10);
            checkBoxIsRect.Name = "checkBoxIsRect";
            checkBoxIsRect.Size = new Size(166, 19);
            checkBoxIsRect.TabIndex = 2;
            checkBoxIsRect.Text = "Рисовать прямоугольник";
            checkBoxIsRect.UseVisualStyleBackColor = true;
            // 
            // buttonRectColor
            // 
            buttonRectColor.BackColor = Color.Black;
            buttonRectColor.Location = new Point(172, 7);
            buttonRectColor.Name = "buttonRectColor";
            buttonRectColor.Size = new Size(75, 23);
            buttonRectColor.TabIndex = 1;
            buttonRectColor.UseVisualStyleBackColor = false;
            buttonRectColor.Click += buttonRectColor_Click;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.Controls.Add(checkBoxChangeSize);
            tabPageGeneral.Controls.Add(checkBoxSavePSD);
            tabPageGeneral.Controls.Add(checkBoxSaveBMP);
            tabPageGeneral.Location = new Point(4, 24);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Size = new Size(487, 219);
            tabPageGeneral.TabIndex = 2;
            tabPageGeneral.Text = "Общее";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxChangeSize
            // 
            checkBoxChangeSize.AutoSize = true;
            checkBoxChangeSize.Location = new Point(340, 3);
            checkBoxChangeSize.Name = "checkBoxChangeSize";
            checkBoxChangeSize.Size = new Size(144, 19);
            checkBoxChangeSize.TabIndex = 4;
            checkBoxChangeSize.Text = "Изменение размеров";
            checkBoxChangeSize.UseVisualStyleBackColor = true;
            // 
            // checkBoxSavePSD
            // 
            checkBoxSavePSD.AutoSize = true;
            checkBoxSavePSD.Location = new Point(5, 15);
            checkBoxSavePSD.Name = "checkBoxSavePSD";
            checkBoxSavePSD.Size = new Size(108, 19);
            checkBoxSavePSD.TabIndex = 20;
            checkBoxSavePSD.Text = "Сохранять PSD";
            checkBoxSavePSD.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveBMP
            // 
            checkBoxSaveBMP.AutoSize = true;
            checkBoxSaveBMP.Location = new Point(5, 40);
            checkBoxSaveBMP.Name = "checkBoxSaveBMP";
            checkBoxSaveBMP.Size = new Size(112, 19);
            checkBoxSaveBMP.TabIndex = 19;
            checkBoxSaveBMP.Text = "Сохранять BMP";
            checkBoxSaveBMP.UseVisualStyleBackColor = true;
            // 
            // dataGridViewImages
            // 
            dataGridViewImages.AllowUserToAddRows = false;
            dataGridViewImages.AllowUserToDeleteRows = false;
            dataGridViewImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewImages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewImages.Columns.AddRange(new DataGridViewColumn[] { ImagePath });
            dataGridViewImages.Location = new Point(3, 293);
            dataGridViewImages.Name = "dataGridViewImages";
            dataGridViewImages.ReadOnly = true;
            dataGridViewImages.Size = new Size(495, 176);
            dataGridViewImages.TabIndex = 16;
            dataGridViewImages.SelectionChanged += dataGridViewImages_SelectionChanged;
            // 
            // ImagePath
            // 
            ImagePath.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ImagePath.HeaderText = "Image";
            ImagePath.Name = "ImagePath";
            ImagePath.ReadOnly = true;
            // 
            // dataGridViewTranslationData
            // 
            dataGridViewTranslationData.AllowUserToAddRows = false;
            dataGridViewTranslationData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTranslationData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTranslationData.Location = new Point(3, 3);
            dataGridViewTranslationData.Name = "dataGridViewTranslationData";
            dataGridViewTranslationData.Size = new Size(495, 284);
            dataGridViewTranslationData.TabIndex = 14;
            dataGridViewTranslationData.SelectionChanged += dataGridViewTranslationData_SelectionChanged;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Dock = DockStyle.Fill;
            pictureBoxImage.Location = new Point(0, 0);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(575, 725);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            pictureBoxImage.MouseDown += pictureBoxImage_MouseDown;
            pictureBoxImage.MouseMove += pictureBoxImage_MouseMove;
            pictureBoxImage.MouseUp += pictureBoxImage_MouseUp;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip1.Location = new Point(0, 749);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1080, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(12, 17);
            StatusLabel.Text = "-";
            // 
            // текстовыеДанныеToolStripMenuItem
            // 
            текстовыеДанныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { удалитьВыделенноеToolStripMenuItem });
            текстовыеДанныеToolStripMenuItem.Name = "текстовыеДанныеToolStripMenuItem";
            текстовыеДанныеToolStripMenuItem.Size = new Size(120, 20);
            текстовыеДанныеToolStripMenuItem.Text = "Текстовые данные";
            // 
            // удалитьВыделенноеToolStripMenuItem
            // 
            удалитьВыделенноеToolStripMenuItem.Name = "удалитьВыделенноеToolStripMenuItem";
            удалитьВыделенноеToolStripMenuItem.Size = new Size(188, 22);
            удалитьВыделенноеToolStripMenuItem.Text = "Удалить выделенное";
            удалитьВыделенноеToolStripMenuItem.Click += удалитьВыделенноеToolStripMenuItem_Click;
            // 
            // Form_ImageTranslator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 771);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Form_ImageTranslator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_ImageTranslator";
            FormClosing += Form_ImageTranslator_FormClosing;
            Load += Form_ImageTranslator_Load;
            KeyDown += Form_ImageTranslator_KeyDown;
            KeyUp += Form_ImageTranslator_KeyUp;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageFont.ResumeLayout(false);
            tabPageFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLeading).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrokeSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).EndInit();
            tabPageRectangle.ResumeLayout(false);
            tabPageRectangle.PerformLayout();
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTranslationData).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private SplitContainer splitContainer1;
        private PictureBox pictureBoxImage;
        private ToolStripMenuItem сохранитьСкриптДляPhotoshopToolStripMenuItem;
        private Label label2;
        private Button button1;
        private TextBox textBoxFont;
        private Label label1;
        private Label label3;
        private Button buttonFontColor;
        private CheckBox checkBoxIsStroke;
        private Button buttonStrokeColor;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDownFontSize;
        private NumericUpDown numericUpDownStrokeSize;
        private DataGridView dataGridViewTranslationData;
        private ComboBox comboBoxAlign;
        private Label label6;
        private ToolStripMenuItem сохранитьСкриптИВыполнитьToolStripMenuItem;
        private NumericUpDown numericUpDownOpacity;
        private Label label7;
        private DataGridView dataGridViewImages;
        private ToolStripMenuItem перевестиИзображенияToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
        private DataGridViewTextBoxColumn ImagePath;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem сохранитьСкриптыДляВсехИзображенийToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem повторитьПереводДляИзображенияToolStripMenuItem;
        private CheckBox checkBoxChangeSize;
        private NumericUpDown numericUpDownLeading;
        private Label label14;
        private CheckBox checkBoxSavePSD;
        private CheckBox checkBoxSaveBMP;
        private ToolStripMenuItem сохранитьИВыполнитьВсеСкриптыToolStripMenuItem;
        private CheckBox checkBoxImageCenterX;
        private TabControl tabControl1;
        private TabPage tabPageFont;
        private TabPage tabPageRectangle;
        private TabPage tabPageGeneral;
        private CheckBox checkBoxImageCenterY;
        private Button buttonRectColor;
        private CheckBox checkBoxIsRect;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem автоматическиОбнаружитьЦветФонаToolStripMenuItem;
        private ToolStripMenuItem текстовыеДанныеToolStripMenuItem;
        private ToolStripMenuItem удалитьВыделенноеToolStripMenuItem;
    }
}
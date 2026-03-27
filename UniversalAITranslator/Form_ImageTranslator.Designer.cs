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
            toolStripSeparator3 = new ToolStripSeparator();
            повторитьПереводДляИзображенияToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            dataGridViewImages = new DataGridView();
            ImagePath = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            checkBoxChangeSize = new CheckBox();
            numericUpDownMul_Y = new NumericUpDown();
            numericUpDownAdd_Y = new NumericUpDown();
            label13 = new Label();
            label11 = new Label();
            numericUpDownMul_X = new NumericUpDown();
            label12 = new Label();
            numericUpDownAdd_X = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            dataGridViewTranslationData = new DataGridView();
            groupBox1 = new GroupBox();
            numericUpDownOpacity = new NumericUpDown();
            label7 = new Label();
            comboBoxAlign = new ComboBox();
            label6 = new Label();
            label1 = new Label();
            numericUpDownFontSize = new NumericUpDown();
            textBoxFont = new TextBox();
            numericUpDownStrokeSize = new NumericUpDown();
            button1 = new Button();
            buttonStrokeColor = new Button();
            label2 = new Label();
            label4 = new Label();
            checkBoxIsStroke = new CheckBox();
            label5 = new Label();
            buttonFontColor = new Button();
            label3 = new Label();
            pictureBoxImage = new PictureBox();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMul_Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd_Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMul_X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd_X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTranslationData).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrokeSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1080, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { перевестиИзображенияToolStripMenuItem, toolStripSeparator1, сохранитьСкриптДляPhotoshopToolStripMenuItem, сохранитьСкриптИВыполнитьToolStripMenuItem, toolStripSeparator2, сохранитьСкриптыДляВсехИзображенийToolStripMenuItem, toolStripSeparator3, повторитьПереводДляИзображенияToolStripMenuItem });
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewImages);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(dataGridViewTranslationData);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBoxImage);
            splitContainer1.Size = new Size(1080, 683);
            splitContainer1.SplitterDistance = 501;
            splitContainer1.TabIndex = 1;
            // 
            // dataGridViewImages
            // 
            dataGridViewImages.AllowUserToAddRows = false;
            dataGridViewImages.AllowUserToDeleteRows = false;
            dataGridViewImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewImages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewImages.Columns.AddRange(new DataGridViewColumn[] { ImagePath });
            dataGridViewImages.Location = new Point(3, 288);
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
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(checkBoxChangeSize);
            groupBox2.Controls.Add(numericUpDownMul_Y);
            groupBox2.Controls.Add(numericUpDownAdd_Y);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(numericUpDownMul_X);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(numericUpDownAdd_X);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 470);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(486, 83);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Модификатор";
            // 
            // checkBoxChangeSize
            // 
            checkBoxChangeSize.AutoSize = true;
            checkBoxChangeSize.Location = new Point(336, 15);
            checkBoxChangeSize.Name = "checkBoxChangeSize";
            checkBoxChangeSize.Size = new Size(144, 19);
            checkBoxChangeSize.TabIndex = 4;
            checkBoxChangeSize.Text = "Изменение размеров";
            checkBoxChangeSize.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMul_Y
            // 
            numericUpDownMul_Y.DecimalPlaces = 2;
            numericUpDownMul_Y.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDownMul_Y.Location = new Point(152, 45);
            numericUpDownMul_Y.Name = "numericUpDownMul_Y";
            numericUpDownMul_Y.Size = new Size(62, 23);
            numericUpDownMul_Y.TabIndex = 3;
            numericUpDownMul_Y.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownAdd_Y
            // 
            numericUpDownAdd_Y.Location = new Point(50, 45);
            numericUpDownAdd_Y.Name = "numericUpDownAdd_Y";
            numericUpDownAdd_Y.Size = new Size(62, 23);
            numericUpDownAdd_Y.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(131, 47);
            label13.Name = "label13";
            label13.Size = new Size(12, 15);
            label13.TabIndex = 2;
            label13.Text = "*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 47);
            label11.Name = "label11";
            label11.Size = new Size(15, 15);
            label11.TabIndex = 2;
            label11.Text = "+";
            // 
            // numericUpDownMul_X
            // 
            numericUpDownMul_X.DecimalPlaces = 2;
            numericUpDownMul_X.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDownMul_X.Location = new Point(152, 17);
            numericUpDownMul_X.Name = "numericUpDownMul_X";
            numericUpDownMul_X.Size = new Size(62, 23);
            numericUpDownMul_X.TabIndex = 3;
            numericUpDownMul_X.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(131, 19);
            label12.Name = "label12";
            label12.Size = new Size(12, 15);
            label12.TabIndex = 2;
            label12.Text = "*";
            // 
            // numericUpDownAdd_X
            // 
            numericUpDownAdd_X.Location = new Point(50, 17);
            numericUpDownAdd_X.Name = "numericUpDownAdd_X";
            numericUpDownAdd_X.Size = new Size(62, 23);
            numericUpDownAdd_X.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 19);
            label10.Name = "label10";
            label10.Size = new Size(15, 15);
            label10.TabIndex = 2;
            label10.Text = "+";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 47);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 1;
            label9.Text = "Y:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 19);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 0;
            label8.Text = "X:";
            // 
            // dataGridViewTranslationData
            // 
            dataGridViewTranslationData.AllowUserToAddRows = false;
            dataGridViewTranslationData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTranslationData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTranslationData.Location = new Point(3, 3);
            dataGridViewTranslationData.Name = "dataGridViewTranslationData";
            dataGridViewTranslationData.Size = new Size(495, 279);
            dataGridViewTranslationData.TabIndex = 14;
            dataGridViewTranslationData.CellValueChanged += dataGridViewTranslationData_CellValueChanged;
            dataGridViewTranslationData.SelectionChanged += dataGridViewTranslationData_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(numericUpDownOpacity);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(comboBoxAlign);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDownFontSize);
            groupBox1.Controls.Add(textBoxFont);
            groupBox1.Controls.Add(numericUpDownStrokeSize);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(buttonStrokeColor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(checkBoxIsStroke);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(buttonFontColor);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 559);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(486, 112);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройка генерации";
            // 
            // numericUpDownOpacity
            // 
            numericUpDownOpacity.Location = new Point(387, 79);
            numericUpDownOpacity.Name = "numericUpDownOpacity";
            numericUpDownOpacity.Size = new Size(79, 23);
            numericUpDownOpacity.TabIndex = 16;
            numericUpDownOpacity.Value = new decimal(new int[] { 100, 0, 0, 0 });
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
            // comboBoxAlign
            // 
            comboBoxAlign.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlign.FormattingEnabled = true;
            comboBoxAlign.Items.AddRange(new object[] { "left", "center", "right" });
            comboBoxAlign.Location = new Point(314, 46);
            comboBoxAlign.Name = "comboBoxAlign";
            comboBoxAlign.Size = new Size(121, 23);
            comboBoxAlign.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(220, 49);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 13;
            label6.Text = "Выравнивание";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Font";
            // 
            // numericUpDownFontSize
            // 
            numericUpDownFontSize.Location = new Point(39, 46);
            numericUpDownFontSize.Name = "numericUpDownFontSize";
            numericUpDownFontSize.Size = new Size(55, 23);
            numericUpDownFontSize.TabIndex = 12;
            numericUpDownFontSize.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // textBoxFont
            // 
            textBoxFont.Location = new Point(43, 16);
            textBoxFont.Name = "textBoxFont";
            textBoxFont.Size = new Size(265, 23);
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
            // button1
            // 
            button1.Location = new Point(314, 15);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Выбрать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Size";
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
            // buttonFontColor
            // 
            buttonFontColor.BackColor = Color.White;
            buttonFontColor.Location = new Point(139, 45);
            buttonFontColor.Name = "buttonFontColor";
            buttonFontColor.Size = new Size(75, 23);
            buttonFontColor.TabIndex = 7;
            buttonFontColor.UseVisualStyleBackColor = false;
            buttonFontColor.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 48);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 8;
            label3.Text = "Цвет";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Dock = DockStyle.Fill;
            pictureBoxImage.Location = new Point(0, 0);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(575, 683);
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
            statusStrip1.Location = new Point(0, 707);
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
            // Form_ImageTranslator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 729);
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMul_Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd_Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMul_X).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAdd_X).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTranslationData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStrokeSize).EndInit();
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
        private GroupBox groupBox1;
        private DataGridView dataGridViewTranslationData;
        private ComboBox comboBoxAlign;
        private Label label6;
        private ToolStripMenuItem сохранитьСкриптИВыполнитьToolStripMenuItem;
        private NumericUpDown numericUpDownOpacity;
        private Label label7;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDownAdd_Y;
        private Label label11;
        private NumericUpDown numericUpDownAdd_X;
        private Label label10;
        private Label label9;
        private Label label8;
        private NumericUpDown numericUpDownMul_Y;
        private Label label13;
        private NumericUpDown numericUpDownMul_X;
        private Label label12;
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
    }
}
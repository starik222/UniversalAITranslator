namespace UniversalAITranslator
{
    partial class Form_AiServerConfig
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
            label1 = new Label();
            comboBoxModel = new ComboBox();
            label2 = new Label();
            textBoxServerUrl = new TextBox();
            buttonConnect = new Button();
            label3 = new Label();
            label4 = new Label();
            trackBarTemperature = new TrackBar();
            label5 = new Label();
            numericUpDownMaxTokens = new NumericUpDown();
            label6 = new Label();
            numericUpDownSeed = new NumericUpDown();
            checkBoxStoreSettings = new CheckBox();
            button2 = new Button();
            button3 = new Button();
            label7 = new Label();
            numericUpDownMaxLines = new NumericUpDown();
            label8 = new Label();
            textBoxKey = new TextBox();
            groupBox1 = new GroupBox();
            radioButtonRusQuote = new RadioButton();
            radioButtonCommonQuote = new RadioButton();
            radioButtonJapQuote = new RadioButton();
            radioButtonNonQuote = new RadioButton();
            checkBoxUseFixText = new CheckBox();
            checkBoxShrinkContext = new CheckBox();
            numericUpDownKeepContext = new NumericUpDown();
            label9 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label10 = new Label();
            label11 = new Label();
            comboBoxModelReserve = new ComboBox();
            textBoxServerUrlReserve = new TextBox();
            buttonConnectReserve = new Button();
            textBoxKeyReserve = new TextBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxLines).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKeepContext).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 92);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Модель";
            // 
            // comboBoxModel
            // 
            comboBoxModel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxModel.FormattingEnabled = true;
            comboBoxModel.Location = new Point(6, 110);
            comboBoxModel.Name = "comboBoxModel";
            comboBoxModel.Size = new Size(776, 23);
            comboBoxModel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 10);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 2;
            label2.Text = "Адрес сервера";
            // 
            // textBoxServerUrl
            // 
            textBoxServerUrl.AutoCompleteCustomSource.AddRange(new string[] { "http://localhost:1234/v1", "http://192.168.11.2:1234/v1", "https://openai.bothub.chat/v1", "https://openai.bothub.ru/v1", "https://generativelanguage.googleapis.com/v1beta/openai/" });
            textBoxServerUrl.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxServerUrl.Location = new Point(6, 28);
            textBoxServerUrl.Name = "textBoxServerUrl";
            textBoxServerUrl.Size = new Size(617, 23);
            textBoxServerUrl.TabIndex = 3;
            textBoxServerUrl.Text = "http://localhost:1234/v1";
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(629, 28);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(153, 23);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "Подключиться";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 207);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Temperature:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 207);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 6;
            label4.Text = "0.0";
            // 
            // trackBarTemperature
            // 
            trackBarTemperature.AutoSize = false;
            trackBarTemperature.Location = new Point(118, 205);
            trackBarTemperature.Maximum = 100;
            trackBarTemperature.Name = "trackBarTemperature";
            trackBarTemperature.Size = new Size(670, 21);
            trackBarTemperature.TabIndex = 7;
            trackBarTemperature.ValueChanged += trackBarTemperature_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 246);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 5;
            label5.Text = "Max tokens:";
            // 
            // numericUpDownMaxTokens
            // 
            numericUpDownMaxTokens.Location = new Point(89, 244);
            numericUpDownMaxTokens.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownMaxTokens.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDownMaxTokens.Name = "numericUpDownMaxTokens";
            numericUpDownMaxTokens.Size = new Size(89, 23);
            numericUpDownMaxTokens.TabIndex = 8;
            numericUpDownMaxTokens.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(192, 246);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 5;
            label6.Text = "Seed:";
            // 
            // numericUpDownSeed
            // 
            numericUpDownSeed.Location = new Point(233, 244);
            numericUpDownSeed.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownSeed.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDownSeed.Name = "numericUpDownSeed";
            numericUpDownSeed.Size = new Size(89, 23);
            numericUpDownSeed.TabIndex = 8;
            numericUpDownSeed.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // checkBoxStoreSettings
            // 
            checkBoxStoreSettings.AutoSize = true;
            checkBoxStoreSettings.Location = new Point(12, 273);
            checkBoxStoreSettings.Name = "checkBoxStoreSettings";
            checkBoxStoreSettings.Size = new Size(230, 19);
            checkBoxStoreSettings.TabIndex = 9;
            checkBoxStoreSettings.Text = "Запомнить до выхода из программы";
            checkBoxStoreSettings.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 316);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(93, 316);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Отмена";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(396, 246);
            label7.Name = "label7";
            label7.Size = new Size(157, 15);
            label7.TabIndex = 12;
            label7.Text = "Максимум строк в запросе";
            // 
            // numericUpDownMaxLines
            // 
            numericUpDownMaxLines.Location = new Point(559, 244);
            numericUpDownMaxLines.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMaxLines.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownMaxLines.Name = "numericUpDownMaxLines";
            numericUpDownMaxLines.Size = new Size(81, 23);
            numericUpDownMaxLines.TabIndex = 13;
            numericUpDownMaxLines.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 64);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 14;
            label8.Text = "Api key";
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(58, 61);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(724, 23);
            textBoxKey.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonRusQuote);
            groupBox1.Controls.Add(radioButtonCommonQuote);
            groupBox1.Controls.Add(radioButtonJapQuote);
            groupBox1.Controls.Add(radioButtonNonQuote);
            groupBox1.Controls.Add(checkBoxUseFixText);
            groupBox1.Location = new Point(396, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 93);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Исправление";
            // 
            // radioButtonRusQuote
            // 
            radioButtonRusQuote.AutoSize = true;
            radioButtonRusQuote.Location = new Point(206, 47);
            radioButtonRusQuote.Name = "radioButtonRusQuote";
            radioButtonRusQuote.Size = new Size(49, 19);
            radioButtonRusQuote.TabIndex = 4;
            radioButtonRusQuote.TabStop = true;
            radioButtonRusQuote.Text = "— …";
            radioButtonRusQuote.UseVisualStyleBackColor = true;
            // 
            // radioButtonCommonQuote
            // 
            radioButtonCommonQuote.AutoSize = true;
            radioButtonCommonQuote.Location = new Point(154, 47);
            radioButtonCommonQuote.Name = "radioButtonCommonQuote";
            radioButtonCommonQuote.Size = new Size(46, 19);
            radioButtonCommonQuote.TabIndex = 3;
            radioButtonCommonQuote.TabStop = true;
            radioButtonCommonQuote.Text = "«...»";
            radioButtonCommonQuote.UseVisualStyleBackColor = true;
            // 
            // radioButtonJapQuote
            // 
            radioButtonJapQuote.AutoSize = true;
            radioButtonJapQuote.Location = new Point(105, 47);
            radioButtonJapQuote.Name = "radioButtonJapQuote";
            radioButtonJapQuote.Size = new Size(48, 19);
            radioButtonJapQuote.TabIndex = 2;
            radioButtonJapQuote.TabStop = true;
            radioButtonJapQuote.Text = "「...」";
            radioButtonJapQuote.UseVisualStyleBackColor = true;
            // 
            // radioButtonNonQuote
            // 
            radioButtonNonQuote.AutoSize = true;
            radioButtonNonQuote.Location = new Point(6, 47);
            radioButtonNonQuote.Name = "radioButtonNonQuote";
            radioButtonNonQuote.Size = new Size(93, 19);
            radioButtonNonQuote.TabIndex = 1;
            radioButtonNonQuote.TabStop = true;
            radioButtonNonQuote.Text = "Без ковычек";
            radioButtonNonQuote.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseFixText
            // 
            checkBoxUseFixText.AutoSize = true;
            checkBoxUseFixText.Location = new Point(6, 22);
            checkBoxUseFixText.Name = "checkBoxUseFixText";
            checkBoxUseFixText.Size = new Size(242, 19);
            checkBoxUseFixText.TabIndex = 0;
            checkBoxUseFixText.Text = "Исправлять оформление прямой речи";
            checkBoxUseFixText.UseVisualStyleBackColor = true;
            // 
            // checkBoxShrinkContext
            // 
            checkBoxShrinkContext.AutoSize = true;
            checkBoxShrinkContext.Location = new Point(396, 372);
            checkBoxShrinkContext.Name = "checkBoxShrinkContext";
            checkBoxShrinkContext.Size = new Size(231, 19);
            checkBoxShrinkContext.TabIndex = 20;
            checkBoxShrinkContext.Text = "Использовать в контексте последние";
            checkBoxShrinkContext.UseVisualStyleBackColor = true;
            // 
            // numericUpDownKeepContext
            // 
            numericUpDownKeepContext.Location = new Point(633, 371);
            numericUpDownKeepContext.Name = "numericUpDownKeepContext";
            numericUpDownKeepContext.Size = new Size(52, 23);
            numericUpDownKeepContext.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(693, 373);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 22;
            label9.Text = "запросов";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(807, 187);
            tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(comboBoxModel);
            tabPage1.Controls.Add(textBoxServerUrl);
            tabPage1.Controls.Add(buttonConnect);
            tabPage1.Controls.Add(textBoxKey);
            tabPage1.Controls.Add(label8);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(799, 159);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Основное подключение";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(comboBoxModelReserve);
            tabPage2.Controls.Add(textBoxServerUrlReserve);
            tabPage2.Controls.Add(buttonConnectReserve);
            tabPage2.Controls.Add(textBoxKeyReserve);
            tabPage2.Controls.Add(label12);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(799, 159);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Резервное подключение";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 10);
            label10.Name = "label10";
            label10.Size = new Size(87, 15);
            label10.TabIndex = 18;
            label10.Text = "Адрес сервера";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 92);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 16;
            label11.Text = "Модель";
            // 
            // comboBoxModelReserve
            // 
            comboBoxModelReserve.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxModelReserve.FormattingEnabled = true;
            comboBoxModelReserve.Location = new Point(6, 110);
            comboBoxModelReserve.Name = "comboBoxModelReserve";
            comboBoxModelReserve.Size = new Size(776, 23);
            comboBoxModelReserve.TabIndex = 17;
            // 
            // textBoxServerUrlReserve
            // 
            textBoxServerUrlReserve.AutoCompleteCustomSource.AddRange(new string[] { "http://localhost:1234/v1", "http://192.168.11.2:1234/v1", "https://openai.bothub.chat/v1", "https://openai.bothub.ru/v1", "https://generativelanguage.googleapis.com/v1beta/openai/" });
            textBoxServerUrlReserve.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxServerUrlReserve.Location = new Point(6, 28);
            textBoxServerUrlReserve.Name = "textBoxServerUrlReserve";
            textBoxServerUrlReserve.Size = new Size(617, 23);
            textBoxServerUrlReserve.TabIndex = 19;
            textBoxServerUrlReserve.Text = "http://localhost:1234/v1";
            // 
            // buttonConnectReserve
            // 
            buttonConnectReserve.Location = new Point(629, 28);
            buttonConnectReserve.Name = "buttonConnectReserve";
            buttonConnectReserve.Size = new Size(153, 23);
            buttonConnectReserve.TabIndex = 20;
            buttonConnectReserve.Text = "Подключиться";
            buttonConnectReserve.UseVisualStyleBackColor = true;
            buttonConnectReserve.Click += buttonConnectReserve_Click;
            // 
            // textBoxKeyReserve
            // 
            textBoxKeyReserve.Location = new Point(58, 61);
            textBoxKeyReserve.Name = "textBoxKeyReserve";
            textBoxKeyReserve.Size = new Size(724, 23);
            textBoxKeyReserve.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 64);
            label12.Name = "label12";
            label12.Size = new Size(46, 15);
            label12.TabIndex = 21;
            label12.Text = "Api key";
            // 
            // Form_AiServerConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 436);
            Controls.Add(tabControl1);
            Controls.Add(label9);
            Controls.Add(numericUpDownKeepContext);
            Controls.Add(checkBoxShrinkContext);
            Controls.Add(groupBox1);
            Controls.Add(numericUpDownMaxLines);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(checkBoxStoreSettings);
            Controls.Add(numericUpDownSeed);
            Controls.Add(numericUpDownMaxTokens);
            Controls.Add(trackBarTemperature);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Name = "Form_AiServerConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_AiServerConfig";
            ((System.ComponentModel.ISupportInitialize)trackBarTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxLines).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKeepContext).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox comboBoxModel;
        public System.Windows.Forms.TextBox textBoxServerUrl;
        public System.Windows.Forms.TrackBar trackBarTemperature;
        public System.Windows.Forms.NumericUpDown numericUpDownMaxTokens;
        public System.Windows.Forms.NumericUpDown numericUpDownSeed;
        public System.Windows.Forms.CheckBox checkBoxStoreSettings;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown numericUpDownMaxLines;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonJapQuote;
        public System.Windows.Forms.RadioButton radioButtonNonQuote;
        public System.Windows.Forms.CheckBox checkBoxUseFixText;
        public System.Windows.Forms.RadioButton radioButtonRusQuote;
        public System.Windows.Forms.RadioButton radioButtonCommonQuote;
        private CheckBox checkBoxShrinkContext;
        private NumericUpDown numericUpDownKeepContext;
        private Label label9;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label10;
        private Label label11;
        public ComboBox comboBoxModelReserve;
        public TextBox textBoxServerUrlReserve;
        private Button buttonConnectReserve;
        public TextBox textBoxKeyReserve;
        private Label label12;
    }
}
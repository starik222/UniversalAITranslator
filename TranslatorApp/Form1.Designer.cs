namespace TranslatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxSystemPrompt = new TextBox();
            label7 = new Label();
            textBoxInput = new TextBox();
            textBoxOutput = new TextBox();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button3 = new Button();
            menuStrip1 = new MenuStrip();
            подключениеToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            открытьОкноТабличногоПереводаToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "System prompt";
            // 
            // textBoxSystemPrompt
            // 
            textBoxSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSystemPrompt.Location = new Point(12, 42);
            textBoxSystemPrompt.MaxLength = 327670;
            textBoxSystemPrompt.Multiline = true;
            textBoxSystemPrompt.Name = "textBoxSystemPrompt";
            textBoxSystemPrompt.ScrollBars = ScrollBars.Vertical;
            textBoxSystemPrompt.Size = new Size(776, 142);
            textBoxSystemPrompt.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 9;
            label7.Text = "User prompt";
            // 
            // textBoxInput
            // 
            textBoxInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInput.Location = new Point(3, 18);
            textBoxInput.MaxLength = 3276700;
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(770, 171);
            textBoxInput.TabIndex = 1;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxOutput.Location = new Point(3, 210);
            textBoxOutput.MaxLength = 3276700;
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(770, 172);
            textBoxOutput.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 192);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 9;
            label8.Text = "Output";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label7, 0, 0);
            tableLayoutPanel1.Controls.Add(label8, 0, 2);
            tableLayoutPanel1.Controls.Add(textBoxInput, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxOutput, 0, 3);
            tableLayoutPanel1.Location = new Point(12, 219);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 385);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(12, 190);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 11;
            button1.Text = "Перевести текст";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(713, 190);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "test";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { подключениеToolStripMenuItem, операцииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // подключениеToolStripMenuItem
            // 
            подключениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem });
            подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
            подключениеToolStripMenuItem.Size = new Size(97, 20);
            подключениеToolStripMenuItem.Text = "Подключение";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(180, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            настройкиToolStripMenuItem.Click += настройкиToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьОкноТабличногоПереводаToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // открытьОкноТабличногоПереводаToolStripMenuItem
            // 
            открытьОкноТабличногоПереводаToolStripMenuItem.Name = "открытьОкноТабличногоПереводаToolStripMenuItem";
            открытьОкноТабличногоПереводаToolStripMenuItem.Size = new Size(273, 22);
            открытьОкноТабличногоПереводаToolStripMenuItem.Text = "Открыть окно табличного перевода";
            открытьОкноТабличногоПереводаToolStripMenuItem.Click += открытьОкноТабличногоПереводаToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 606);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(textBoxSystemPrompt);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxSystemPrompt;
        private Label label7;
        private TextBox textBoxInput;
        private TextBox textBoxOutput;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem подключениеToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem открытьОкноТабличногоПереводаToolStripMenuItem;
    }
}

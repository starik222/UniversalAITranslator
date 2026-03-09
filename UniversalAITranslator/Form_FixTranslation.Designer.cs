namespace UniversalAITranslator
{
    partial class Form_FixTranslation
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
            splitContainer1 = new SplitContainer();
            dataGridViewData = new DataGridView();
            OrigName = new DataGridViewTextBoxColumn();
            OrigText = new DataGridViewTextBoxColumn();
            TransName = new DataGridViewTextBoxColumn();
            TransText = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button1 = new Button();
            buttonSave = new Button();
            buttonJoinStrings = new Button();
            buttonSplitOnCaret = new Button();
            label2 = new Label();
            textBoxSelectedText = new TextBox();
            buttonTranslate = new Button();
            textBoxTranslation = new TextBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelStatus = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewData);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(buttonSave);
            splitContainer1.Panel2.Controls.Add(buttonJoinStrings);
            splitContainer1.Panel2.Controls.Add(buttonSplitOnCaret);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(textBoxSelectedText);
            splitContainer1.Panel2.Controls.Add(buttonTranslate);
            splitContainer1.Panel2.Controls.Add(textBoxTranslation);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(statusStrip1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewData
            // 
            dataGridViewData.AllowUserToAddRows = false;
            dataGridViewData.AllowUserToDeleteRows = false;
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Columns.AddRange(new DataGridViewColumn[] { OrigName, OrigText, TransName, TransText });
            dataGridViewData.Dock = DockStyle.Fill;
            dataGridViewData.Location = new Point(0, 0);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.Size = new Size(800, 266);
            dataGridViewData.TabIndex = 0;
            dataGridViewData.SelectionChanged += dataGridViewData_SelectionChanged;
            // 
            // OrigName
            // 
            OrigName.HeaderText = "OrigName";
            OrigName.Name = "OrigName";
            OrigName.ReadOnly = true;
            // 
            // OrigText
            // 
            OrigText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OrigText.HeaderText = "OrigText";
            OrigText.Name = "OrigText";
            OrigText.ReadOnly = true;
            // 
            // TransName
            // 
            TransName.HeaderText = "TransName";
            TransName.Name = "TransName";
            TransName.ReadOnly = true;
            // 
            // TransText
            // 
            TransText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TransText.HeaderText = "TransText";
            TransText.Name = "TransText";
            // 
            // button2
            // 
            button2.Location = new Point(551, 63);
            button2.Name = "button2";
            button2.Size = new Size(51, 23);
            button2.TabIndex = 10;
            button2.Text = "Trans-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(608, 62);
            button1.Name = "button1";
            button1.Size = new Size(51, 23);
            button1.TabIndex = 9;
            button1.Text = "Trans+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(603, 132);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(185, 23);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonJoinStrings
            // 
            buttonJoinStrings.Location = new Point(322, 63);
            buttonJoinStrings.Name = "buttonJoinStrings";
            buttonJoinStrings.Size = new Size(223, 23);
            buttonJoinStrings.TabIndex = 7;
            buttonJoinStrings.Text = "Объединить выделенные строки";
            buttonJoinStrings.UseVisualStyleBackColor = true;
            buttonJoinStrings.Click += buttonJoinStrings_Click;
            // 
            // buttonSplitOnCaret
            // 
            buttonSplitOnCaret.Location = new Point(93, 63);
            buttonSplitOnCaret.Name = "buttonSplitOnCaret";
            buttonSplitOnCaret.Size = new Size(223, 23);
            buttonSplitOnCaret.TabIndex = 6;
            buttonSplitOnCaret.Text = "Разбить по курсору";
            buttonSplitOnCaret.UseVisualStyleBackColor = true;
            buttonSplitOnCaret.Click += buttonSplitOnCaret_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 5;
            label2.Text = "Выделенное";
            // 
            // textBoxSelectedText
            // 
            textBoxSelectedText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSelectedText.Location = new Point(93, 9);
            textBoxSelectedText.Multiline = true;
            textBoxSelectedText.Name = "textBoxSelectedText";
            textBoxSelectedText.Size = new Size(704, 48);
            textBoxSelectedText.TabIndex = 4;
            // 
            // buttonTranslate
            // 
            buttonTranslate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTranslate.Location = new Point(603, 91);
            buttonTranslate.Name = "buttonTranslate";
            buttonTranslate.Size = new Size(185, 23);
            buttonTranslate.TabIndex = 3;
            buttonTranslate.Text = "Перевести выделенное";
            buttonTranslate.UseVisualStyleBackColor = true;
            buttonTranslate.Click += buttonTranslate_Click;
            // 
            // textBoxTranslation
            // 
            textBoxTranslation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTranslation.Location = new Point(72, 91);
            textBoxTranslation.Multiline = true;
            textBoxTranslation.Name = "textBoxTranslation";
            textBoxTranslation.ScrollBars = ScrollBars.Vertical;
            textBoxTranslation.Size = new Size(525, 44);
            textBoxTranslation.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 94);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Перевод";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelStatus });
            statusStrip1.Location = new Point(0, 158);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            toolStripStatusLabelStatus.Size = new Size(43, 17);
            toolStripStatusLabelStatus.Text = "ERROR";
            // 
            // Form_FixTranslation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form_FixTranslation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_FixTranslation";
            WindowState = FormWindowState.Maximized;
            Load += Form_FixTranslation_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label2;
        private TextBox textBoxSelectedText;
        private Button buttonTranslate;
        private TextBox textBoxTranslation;
        private Label label1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelStatus;
        private Button buttonJoinStrings;
        private Button buttonSplitOnCaret;
        public DataGridView dataGridViewData;
        private Button buttonSave;
        private DataGridViewTextBoxColumn OrigName;
        private DataGridViewTextBoxColumn OrigText;
        private DataGridViewTextBoxColumn TransName;
        private DataGridViewTextBoxColumn TransText;
        private Button button2;
        private Button button1;
    }
}
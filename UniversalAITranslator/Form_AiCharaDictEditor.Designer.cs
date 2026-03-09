namespace UniversalAITranslator
{
    partial class Form_AiCharaDictEditor
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
            новыйToolStripMenuItem = new ToolStripMenuItem();
            загрузитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            загрузитьИзТекстовогоСловаряToolStripMenuItem = new ToolStripMenuItem();
            мужскойToolStripMenuItem = new ToolStripMenuItem();
            женскийToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            OriginalName = new DataGridViewTextBoxColumn();
            TranslatedName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, мужскойToolStripMenuItem, женскийToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(954, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйToolStripMenuItem, загрузитьToolStripMenuItem, сохранитьToolStripMenuItem, toolStripSeparator1, загрузитьИзТекстовогоСловаряToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            новыйToolStripMenuItem.Size = new Size(254, 22);
            новыйToolStripMenuItem.Text = "Новый";
            новыйToolStripMenuItem.Click += новыйToolStripMenuItem_Click;
            // 
            // загрузитьToolStripMenuItem
            // 
            загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            загрузитьToolStripMenuItem.Size = new Size(254, 22);
            загрузитьToolStripMenuItem.Text = "Загрузить";
            загрузитьToolStripMenuItem.Click += загрузитьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(254, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(251, 6);
            // 
            // загрузитьИзТекстовогоСловаряToolStripMenuItem
            // 
            загрузитьИзТекстовогоСловаряToolStripMenuItem.Name = "загрузитьИзТекстовогоСловаряToolStripMenuItem";
            загрузитьИзТекстовогоСловаряToolStripMenuItem.Size = new Size(254, 22);
            загрузитьИзТекстовогоСловаряToolStripMenuItem.Text = "Загрузить из текстового словаря";
            загрузитьИзТекстовогоСловаряToolStripMenuItem.Click += загрузитьИзТекстовогоСловаряToolStripMenuItem_Click;
            // 
            // мужскойToolStripMenuItem
            // 
            мужскойToolStripMenuItem.Name = "мужскойToolStripMenuItem";
            мужскойToolStripMenuItem.ShortcutKeys = Keys.F1;
            мужскойToolStripMenuItem.Size = new Size(71, 20);
            мужскойToolStripMenuItem.Text = "Мужской";
            мужскойToolStripMenuItem.Click += мужскойToolStripMenuItem_Click;
            // 
            // женскийToolStripMenuItem
            // 
            женскийToolStripMenuItem.Name = "женскийToolStripMenuItem";
            женскийToolStripMenuItem.ShortcutKeys = Keys.F2;
            женскийToolStripMenuItem.Size = new Size(69, 20);
            женскийToolStripMenuItem.Text = "Женский";
            женскийToolStripMenuItem.Click += женскийToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { OriginalName, TranslatedName, Gender });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(954, 514);
            dataGridView1.TabIndex = 1;
            // 
            // OriginalName
            // 
            OriginalName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            OriginalName.DataPropertyName = "OriginalName";
            OriginalName.HeaderText = "OriginalName";
            OriginalName.Name = "OriginalName";
            // 
            // TranslatedName
            // 
            TranslatedName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TranslatedName.DataPropertyName = "TranslatedName";
            TranslatedName.HeaderText = "TranslatedName";
            TranslatedName.Name = "TranslatedName";
            // 
            // Gender
            // 
            Gender.DataPropertyName = "Gender";
            Gender.HeaderText = "Gender";
            Gender.Name = "Gender";
            Gender.Resizable = DataGridViewTriState.True;
            Gender.SortMode = DataGridViewColumnSortMode.NotSortable;
            Gender.Width = 200;
            // 
            // Form_AiCharaDictEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 538);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form_AiCharaDictEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_AiCharaDictEditor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мужскойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem женскийToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranslatedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem загрузитьИзТекстовогоСловаряToolStripMenuItem;
    }
}
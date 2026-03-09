namespace UniversalAITranslator
{
    partial class Form_PreTranslator
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
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            заменитьВыделенныеToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            перевестиВСтолбецПереводаToolStripMenuItem = new ToolStripMenuItem();
            перевестиВСтолбецПредпросмотраToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            dataGridViewDS = new DataGridView();
            восстановитьВыделенныеToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDS).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, операцииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(180, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заменитьВыделенныеToolStripMenuItem, восстановитьВыделенныеToolStripMenuItem, toolStripSeparator1, перевестиВСтолбецПереводаToolStripMenuItem, перевестиВСтолбецПредпросмотраToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // заменитьВыделенныеToolStripMenuItem
            // 
            заменитьВыделенныеToolStripMenuItem.Name = "заменитьВыделенныеToolStripMenuItem";
            заменитьВыделенныеToolStripMenuItem.Size = new Size(279, 22);
            заменитьВыделенныеToolStripMenuItem.Text = "Заменить выделенные";
            заменитьВыделенныеToolStripMenuItem.Click += заменитьВыделенныеToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(276, 6);
            // 
            // перевестиВСтолбецПереводаToolStripMenuItem
            // 
            перевестиВСтолбецПереводаToolStripMenuItem.Name = "перевестиВСтолбецПереводаToolStripMenuItem";
            перевестиВСтолбецПереводаToolStripMenuItem.Size = new Size(279, 22);
            перевестиВСтолбецПереводаToolStripMenuItem.Text = "Перевести в столбец перевода";
            перевестиВСтолбецПереводаToolStripMenuItem.Click += перевестиВСтолбецПереводаToolStripMenuItem_Click;
            // 
            // перевестиВСтолбецПредпросмотраToolStripMenuItem
            // 
            перевестиВСтолбецПредпросмотраToolStripMenuItem.Name = "перевестиВСтолбецПредпросмотраToolStripMenuItem";
            перевестиВСтолбецПредпросмотраToolStripMenuItem.Size = new Size(279, 22);
            перевестиВСтолбецПредпросмотраToolStripMenuItem.Text = "Перевести в столбец предпросмотра";
            перевестиВСтолбецПредпросмотраToolStripMenuItem.Click += перевестиВСтолбецПредпросмотраToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // dataGridViewDS
            // 
            dataGridViewDS.AllowUserToAddRows = false;
            dataGridViewDS.AllowUserToDeleteRows = false;
            dataGridViewDS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDS.Dock = DockStyle.Fill;
            dataGridViewDS.Location = new Point(0, 24);
            dataGridViewDS.Name = "dataGridViewDS";
            dataGridViewDS.Size = new Size(800, 404);
            dataGridViewDS.TabIndex = 2;
            dataGridViewDS.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // восстановитьВыделенныеToolStripMenuItem
            // 
            восстановитьВыделенныеToolStripMenuItem.Name = "восстановитьВыделенныеToolStripMenuItem";
            восстановитьВыделенныеToolStripMenuItem.Size = new Size(279, 22);
            восстановитьВыделенныеToolStripMenuItem.Text = "Восстановить выделенные";
            восстановитьВыделенныеToolStripMenuItem.Click += восстановитьВыделенныеToolStripMenuItem_Click;
            // 
            // Form_PreTranslator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewDS);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form_PreTranslator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_PreTranslator";
            WindowState = FormWindowState.Maximized;
            Load += Form_PreTranslator_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private DataGridView dataGridViewDS;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem заменитьВыделенныеToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem перевестиВСтолбецПереводаToolStripMenuItem;
        private ToolStripMenuItem перевестиВСтолбецПредпросмотраToolStripMenuItem;
        private ToolStripMenuItem восстановитьВыделенныеToolStripMenuItem;
    }
}
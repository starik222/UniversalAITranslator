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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            перевестиИзображенияToolStripMenuItem = new ToolStripMenuItem();
            добавитьИзображенияБезПереводаToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            сохранитьСкриптДляPhotoshopToolStripMenuItem = new ToolStripMenuItem();
            сохранитьСкриптИВыполнитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem = new ToolStripMenuItem();
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            повторитьПереводДляИзображенияToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            автоматическиОбнаружитьЦветФонаToolStripMenuItem = new ToolStripMenuItem();
            автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem = new ToolStripMenuItem();
            автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem = new ToolStripMenuItem();
            применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem = new ToolStripMenuItem();
            применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem = new ToolStripMenuItem();
            применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            текстовыеДанныеToolStripMenuItem = new ToolStripMenuItem();
            удалитьВыделенноеToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            пКМЦветПрямоугольникаToolStripMenuItem = new ToolStripMenuItem();
            пКМЦветНачалаГрадиентаToolStripMenuItem = new ToolStripMenuItem();
            пКМЦветКонцаГрадиентаToolStripMenuItem = new ToolStripMenuItem();
            пКМЦветШрифтаToolStripMenuItem = new ToolStripMenuItem();
            пКМЦветОбводкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPageFont = new TabPage();
            checkBoxFontDrawOnAlpha = new CheckBox();
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
            checkBoxRectDrawOnAlpha = new CheckBox();
            comboBoxGradientAngle = new ComboBox();
            buttonGrEndColor = new Button();
            buttonGrStartColor = new Button();
            checkBoxUseGradient = new CheckBox();
            checkBoxIsRect = new CheckBox();
            buttonRectColor = new Button();
            tabPageGeneral = new TabPage();
            groupBox1 = new GroupBox();
            radioButtonFontContur = new RadioButton();
            radioButtonFont = new RadioButton();
            radioButtonRectGrDown = new RadioButton();
            radioButtonRectGrTop = new RadioButton();
            radioButtonRect = new RadioButton();
            checkBoxChangeSize = new CheckBox();
            checkBoxSavePSD = new CheckBox();
            checkBoxSaveBMP = new CheckBox();
            tabPagePresets = new TabPage();
            dataGridViewPresets = new DataGridView();
            ColIndex = new DataGridViewTextBoxColumn();
            ColFontColor = new DataGridViewTextBoxColumn();
            ColFontStrokeColor = new DataGridViewTextBoxColumn();
            ColRectangleColor = new DataGridViewTextBoxColumn();
            ColGradStart = new DataGridViewTextBoxColumn();
            ColGradEnd = new DataGridViewTextBoxColumn();
            ColDrawRect = new DataGridViewCheckBoxColumn();
            ColGrad = new DataGridViewCheckBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripButtonAddPreset = new ToolStripButton();
            toolStripButtonRemovePreset = new ToolStripButton();
            dataGridViewImages = new DataGridView();
            ImagePath = new DataGridViewTextBoxColumn();
            contextMenuStripImages = new ContextMenuStrip(components);
            копироватьДанныеToolStripMenuItem = new ToolStripMenuItem();
            вставитьДанныеToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewTranslationData = new DataGridView();
            contextMenuStripTranslation = new ContextMenuStrip(components);
            pictureBoxImage = new PictureBox();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabelColor = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabelMode = new ToolStripStatusLabel();
            изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem = new ToolStripMenuItem();
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
            groupBox1.SuspendLayout();
            tabPagePresets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPresets).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).BeginInit();
            contextMenuStripImages.SuspendLayout();
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
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { перевестиИзображенияToolStripMenuItem, добавитьИзображенияБезПереводаToolStripMenuItem, toolStripSeparator1, сохранитьСкриптДляPhotoshopToolStripMenuItem, сохранитьСкриптИВыполнитьToolStripMenuItem, toolStripSeparator2, сохранитьСкриптыДляВсехИзображенийToolStripMenuItem, сохранитьИВыполнитьВсеСкриптыToolStripMenuItem, toolStripSeparator3, повторитьПереводДляИзображенияToolStripMenuItem, toolStripSeparator6, создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // перевестиИзображенияToolStripMenuItem
            // 
            перевестиИзображенияToolStripMenuItem.Name = "перевестиИзображенияToolStripMenuItem";
            перевестиИзображенияToolStripMenuItem.Size = new Size(392, 22);
            перевестиИзображенияToolStripMenuItem.Text = "Перевести изображения...";
            перевестиИзображенияToolStripMenuItem.Click += перевестиИзображенияToolStripMenuItem_Click;
            // 
            // добавитьИзображенияБезПереводаToolStripMenuItem
            // 
            добавитьИзображенияБезПереводаToolStripMenuItem.Name = "добавитьИзображенияБезПереводаToolStripMenuItem";
            добавитьИзображенияБезПереводаToolStripMenuItem.Size = new Size(392, 22);
            добавитьИзображенияБезПереводаToolStripMenuItem.Text = "Добавить изображения без перевода...";
            добавитьИзображенияБезПереводаToolStripMenuItem.Click += добавитьИзображенияБезПереводаToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(389, 6);
            // 
            // сохранитьСкриптДляPhotoshopToolStripMenuItem
            // 
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Name = "сохранитьСкриптДляPhotoshopToolStripMenuItem";
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Size = new Size(392, 22);
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Text = "Сохранить скрипт для Photoshop";
            сохранитьСкриптДляPhotoshopToolStripMenuItem.Click += сохранитьСкриптДляPhotoshopToolStripMenuItem_Click;
            // 
            // сохранитьСкриптИВыполнитьToolStripMenuItem
            // 
            сохранитьСкриптИВыполнитьToolStripMenuItem.Name = "сохранитьСкриптИВыполнитьToolStripMenuItem";
            сохранитьСкриптИВыполнитьToolStripMenuItem.Size = new Size(392, 22);
            сохранитьСкриптИВыполнитьToolStripMenuItem.Text = "Сохранить скрипт и выполнить";
            сохранитьСкриптИВыполнитьToolStripMenuItem.Click += сохранитьСкриптИВыполнитьToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(389, 6);
            // 
            // сохранитьСкриптыДляВсехИзображенийToolStripMenuItem
            // 
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Name = "сохранитьСкриптыДляВсехИзображенийToolStripMenuItem";
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Size = new Size(392, 22);
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Text = "Сохранить скрипты для всех изображений";
            сохранитьСкриптыДляВсехИзображенийToolStripMenuItem.Click += сохранитьСкриптыДляВсехИзображенийToolStripMenuItem_Click;
            // 
            // сохранитьИВыполнитьВсеСкриптыToolStripMenuItem
            // 
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Name = "сохранитьИВыполнитьВсеСкриптыToolStripMenuItem";
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Size = new Size(392, 22);
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Text = "Сохранить и выполнить все скрипты";
            сохранитьИВыполнитьВсеСкриптыToolStripMenuItem.Click += сохранитьИВыполнитьВсеСкриптыToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(389, 6);
            // 
            // повторитьПереводДляИзображенияToolStripMenuItem
            // 
            повторитьПереводДляИзображенияToolStripMenuItem.Name = "повторитьПереводДляИзображенияToolStripMenuItem";
            повторитьПереводДляИзображенияToolStripMenuItem.Size = new Size(392, 22);
            повторитьПереводДляИзображенияToolStripMenuItem.Text = "Повторить перевод для изображения";
            повторитьПереводДляИзображенияToolStripMenuItem.Click += повторитьПереводДляИзображенияToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(389, 6);
            // 
            // создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem
            // 
            создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem.Name = "создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem";
            создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem.Size = new Size(392, 22);
            создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem.Text = "Создать список перевода (первый элемент изображения)";
            создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem.Click += создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { автоматическиОбнаружитьЦветФонаToolStripMenuItem, автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem, автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem, toolStripSeparator7, применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem, применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem, применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem, применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem, toolStripSeparator8, применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem, toolStripSeparator9, изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // автоматическиОбнаружитьЦветФонаToolStripMenuItem
            // 
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Name = "автоматическиОбнаружитьЦветФонаToolStripMenuItem";
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Size = new Size(523, 22);
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Text = "Автоматически обнаружить цвет фона для всех";
            автоматическиОбнаружитьЦветФонаToolStripMenuItem.Click += автоматическиОбнаружитьЦветФонаToolStripMenuItem_Click;
            // 
            // автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem
            // 
            автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem.Name = "автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem";
            автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem.Size = new Size(523, 22);
            автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem.Text = "Автоматически обнаружить цвет фона для текущего";
            автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem.Click += автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem_Click;
            // 
            // автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem
            // 
            автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem.Name = "автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem";
            автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem.Size = new Size(523, 22);
            автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem.Text = "Автоматически обнаружить цвет фона для выделенных";
            автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem.Click += автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(520, 6);
            // 
            // применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem
            // 
            применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem.Name = "применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem";
            применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem.Size = new Size(523, 22);
            применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem.Text = "Применить текущие координаты ко всем схожим изображениям";
            применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem.Click += применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem_Click;
            // 
            // применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem
            // 
            применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem.Name = "применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem";
            применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem.Size = new Size(523, 22);
            применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem.Text = "Применить текущие координаты и настройки ко всем схожим изображениям";
            применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem.Click += применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem_Click;
            // 
            // применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem
            // 
            применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem.Name = "применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem";
            применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem.Size = new Size(523, 22);
            применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem.Text = "Применить текущие настройки прямоугольника ко всем схожим изображениям";
            применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem.Click += применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem_Click;
            // 
            // применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem
            // 
            применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem.Name = "применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem";
            применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem.Size = new Size(523, 22);
            применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem.Text = "Применить текущие настройки шрифта ко всем схожим изображениям";
            применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem.Click += применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(520, 6);
            // 
            // применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem
            // 
            применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem.Name = "применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem";
            применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem.Size = new Size(523, 22);
            применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem.Text = "Применить текущие числовые настройки шрифта ко всем";
            применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem.Click += применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(520, 6);
            // 
            // текстовыеДанныеToolStripMenuItem
            // 
            текстовыеДанныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { удалитьВыделенноеToolStripMenuItem, toolStripSeparator4, пКМЦветПрямоугольникаToolStripMenuItem, пКМЦветНачалаГрадиентаToolStripMenuItem, пКМЦветКонцаГрадиентаToolStripMenuItem, пКМЦветШрифтаToolStripMenuItem, пКМЦветОбводкиToolStripMenuItem, toolStripSeparator5 });
            текстовыеДанныеToolStripMenuItem.Name = "текстовыеДанныеToolStripMenuItem";
            текстовыеДанныеToolStripMenuItem.Size = new Size(120, 20);
            текстовыеДанныеToolStripMenuItem.Text = "Текстовые данные";
            // 
            // удалитьВыделенноеToolStripMenuItem
            // 
            удалитьВыделенноеToolStripMenuItem.Name = "удалитьВыделенноеToolStripMenuItem";
            удалитьВыделенноеToolStripMenuItem.Size = new Size(272, 22);
            удалитьВыделенноеToolStripMenuItem.Text = "Удалить выделенное";
            удалитьВыделенноеToolStripMenuItem.Click += удалитьВыделенноеToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(269, 6);
            // 
            // пКМЦветПрямоугольникаToolStripMenuItem
            // 
            пКМЦветПрямоугольникаToolStripMenuItem.Name = "пКМЦветПрямоугольникаToolStripMenuItem";
            пКМЦветПрямоугольникаToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D1;
            пКМЦветПрямоугольникаToolStripMenuItem.Size = new Size(272, 22);
            пКМЦветПрямоугольникаToolStripMenuItem.Text = "ПКМ - цвет прямоугольника";
            пКМЦветПрямоугольникаToolStripMenuItem.Click += пКМЦветПрямоугольникаToolStripMenuItem_Click;
            // 
            // пКМЦветНачалаГрадиентаToolStripMenuItem
            // 
            пКМЦветНачалаГрадиентаToolStripMenuItem.Name = "пКМЦветНачалаГрадиентаToolStripMenuItem";
            пКМЦветНачалаГрадиентаToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            пКМЦветНачалаГрадиентаToolStripMenuItem.Size = new Size(272, 22);
            пКМЦветНачалаГрадиентаToolStripMenuItem.Text = "ПКМ - цвет начала градиента";
            пКМЦветНачалаГрадиентаToolStripMenuItem.Click += пКМЦветНачалаГрадиентаToolStripMenuItem_Click;
            // 
            // пКМЦветКонцаГрадиентаToolStripMenuItem
            // 
            пКМЦветКонцаГрадиентаToolStripMenuItem.Name = "пКМЦветКонцаГрадиентаToolStripMenuItem";
            пКМЦветКонцаГрадиентаToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D3;
            пКМЦветКонцаГрадиентаToolStripMenuItem.Size = new Size(272, 22);
            пКМЦветКонцаГрадиентаToolStripMenuItem.Text = "ПКМ - цвет конца градиента";
            пКМЦветКонцаГрадиентаToolStripMenuItem.Click += пКМЦветКонцаГрадиентаToolStripMenuItem_Click;
            // 
            // пКМЦветШрифтаToolStripMenuItem
            // 
            пКМЦветШрифтаToolStripMenuItem.Name = "пКМЦветШрифтаToolStripMenuItem";
            пКМЦветШрифтаToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D4;
            пКМЦветШрифтаToolStripMenuItem.Size = new Size(272, 22);
            пКМЦветШрифтаToolStripMenuItem.Text = "ПКМ - цвет шрифта";
            пКМЦветШрифтаToolStripMenuItem.Click += пКМЦветШрифтаToolStripMenuItem_Click;
            // 
            // пКМЦветОбводкиToolStripMenuItem
            // 
            пКМЦветОбводкиToolStripMenuItem.Name = "пКМЦветОбводкиToolStripMenuItem";
            пКМЦветОбводкиToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D5;
            пКМЦветОбводкиToolStripMenuItem.Size = new Size(272, 22);
            пКМЦветОбводкиToolStripMenuItem.Text = "ПКМ - цвет обводки";
            пКМЦветОбводкиToolStripMenuItem.Click += пКМЦветОбводкиToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(269, 6);
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
            tabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageFont);
            tabControl1.Controls.Add(tabPageRectangle);
            tabControl1.Controls.Add(tabPageGeneral);
            tabControl1.Controls.Add(tabPagePresets);
            tabControl1.Location = new Point(3, 475);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(495, 247);
            tabControl1.TabIndex = 17;
            // 
            // tabPageFont
            // 
            tabPageFont.Controls.Add(checkBoxFontDrawOnAlpha);
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
            // checkBoxFontDrawOnAlpha
            // 
            checkBoxFontDrawOnAlpha.AutoSize = true;
            checkBoxFontDrawOnAlpha.Location = new Point(6, 110);
            checkBoxFontDrawOnAlpha.Name = "checkBoxFontDrawOnAlpha";
            checkBoxFontDrawOnAlpha.Size = new Size(199, 19);
            checkBoxFontDrawOnAlpha.TabIndex = 22;
            checkBoxFontDrawOnAlpha.Text = "Отрисовывать на альфа канале";
            checkBoxFontDrawOnAlpha.UseVisualStyleBackColor = true;
            // 
            // checkBoxImageCenterY
            // 
            checkBoxImageCenterY.AutoSize = true;
            checkBoxImageCenterY.Location = new Point(241, 139);
            checkBoxImageCenterY.Name = "checkBoxImageCenterY";
            checkBoxImageCenterY.Size = new Size(229, 19);
            checkBoxImageCenterY.TabIndex = 21;
            checkBoxImageCenterY.Text = "Центрировать по изображению по Y";
            checkBoxImageCenterY.UseVisualStyleBackColor = true;
            // 
            // checkBoxImageCenterX
            // 
            checkBoxImageCenterX.AutoSize = true;
            checkBoxImageCenterX.Location = new Point(6, 139);
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
            tabPageRectangle.Controls.Add(checkBoxRectDrawOnAlpha);
            tabPageRectangle.Controls.Add(comboBoxGradientAngle);
            tabPageRectangle.Controls.Add(buttonGrEndColor);
            tabPageRectangle.Controls.Add(buttonGrStartColor);
            tabPageRectangle.Controls.Add(checkBoxUseGradient);
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
            // checkBoxRectDrawOnAlpha
            // 
            checkBoxRectDrawOnAlpha.AutoSize = true;
            checkBoxRectDrawOnAlpha.Location = new Point(5, 65);
            checkBoxRectDrawOnAlpha.Name = "checkBoxRectDrawOnAlpha";
            checkBoxRectDrawOnAlpha.Size = new Size(199, 19);
            checkBoxRectDrawOnAlpha.TabIndex = 23;
            checkBoxRectDrawOnAlpha.Text = "Отрисовывать на альфа канале";
            checkBoxRectDrawOnAlpha.UseVisualStyleBackColor = true;
            // 
            // comboBoxGradientAngle
            // 
            comboBoxGradientAngle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGradientAngle.FormattingEnabled = true;
            comboBoxGradientAngle.Items.AddRange(new object[] { "-90", "90", "-180", "180" });
            comboBoxGradientAngle.Location = new Point(334, 35);
            comboBoxGradientAngle.Name = "comboBoxGradientAngle";
            comboBoxGradientAngle.Size = new Size(121, 23);
            comboBoxGradientAngle.TabIndex = 6;
            // 
            // buttonGrEndColor
            // 
            buttonGrEndColor.BackColor = Color.Black;
            buttonGrEndColor.Location = new Point(253, 35);
            buttonGrEndColor.Name = "buttonGrEndColor";
            buttonGrEndColor.Size = new Size(75, 23);
            buttonGrEndColor.TabIndex = 5;
            buttonGrEndColor.UseVisualStyleBackColor = false;
            buttonGrEndColor.Click += buttonGrEndColor_Click;
            // 
            // buttonGrStartColor
            // 
            buttonGrStartColor.BackColor = Color.Black;
            buttonGrStartColor.Location = new Point(172, 35);
            buttonGrStartColor.Name = "buttonGrStartColor";
            buttonGrStartColor.Size = new Size(75, 23);
            buttonGrStartColor.TabIndex = 4;
            buttonGrStartColor.UseVisualStyleBackColor = false;
            buttonGrStartColor.Click += buttonGrStartColor_Click;
            // 
            // checkBoxUseGradient
            // 
            checkBoxUseGradient.AutoSize = true;
            checkBoxUseGradient.Location = new Point(5, 38);
            checkBoxUseGradient.Name = "checkBoxUseGradient";
            checkBoxUseGradient.Size = new Size(155, 19);
            checkBoxUseGradient.TabIndex = 3;
            checkBoxUseGradient.Text = "Использовать градиент";
            checkBoxUseGradient.UseVisualStyleBackColor = true;
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
            tabPageGeneral.Controls.Add(groupBox1);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonFontContur);
            groupBox1.Controls.Add(radioButtonFont);
            groupBox1.Controls.Add(radioButtonRectGrDown);
            groupBox1.Controls.Add(radioButtonRectGrTop);
            groupBox1.Controls.Add(radioButtonRect);
            groupBox1.Location = new Point(308, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 165);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Быстрый цвет ПКМ";
            // 
            // radioButtonFontContur
            // 
            radioButtonFontContur.AutoSize = true;
            radioButtonFontContur.Location = new Point(6, 122);
            radioButtonFontContur.Name = "radioButtonFontContur";
            radioButtonFontContur.Size = new Size(100, 19);
            radioButtonFontContur.TabIndex = 4;
            radioButtonFontContur.Text = "Цвет обводки";
            radioButtonFontContur.UseVisualStyleBackColor = true;
            // 
            // radioButtonFont
            // 
            radioButtonFont.AutoSize = true;
            radioButtonFont.Location = new Point(6, 97);
            radioButtonFont.Name = "radioButtonFont";
            radioButtonFont.Size = new Size(99, 19);
            radioButtonFont.TabIndex = 3;
            radioButtonFont.TabStop = true;
            radioButtonFont.Text = "Цвет шрифта";
            radioButtonFont.UseVisualStyleBackColor = true;
            // 
            // radioButtonRectGrDown
            // 
            radioButtonRectGrDown.AutoSize = true;
            radioButtonRectGrDown.Location = new Point(6, 72);
            radioButtonRectGrDown.Name = "radioButtonRectGrDown";
            radioButtonRectGrDown.Size = new Size(151, 19);
            radioButtonRectGrDown.TabIndex = 2;
            radioButtonRectGrDown.TabStop = true;
            radioButtonRectGrDown.Text = "Прямоуг. градиент низ";
            radioButtonRectGrDown.UseVisualStyleBackColor = true;
            // 
            // radioButtonRectGrTop
            // 
            radioButtonRectGrTop.AutoSize = true;
            radioButtonRectGrTop.Location = new Point(6, 47);
            radioButtonRectGrTop.Name = "radioButtonRectGrTop";
            radioButtonRectGrTop.Size = new Size(157, 19);
            radioButtonRectGrTop.TabIndex = 1;
            radioButtonRectGrTop.TabStop = true;
            radioButtonRectGrTop.Text = "Прямоуг. градиент верх";
            radioButtonRectGrTop.UseVisualStyleBackColor = true;
            // 
            // radioButtonRect
            // 
            radioButtonRect.AutoSize = true;
            radioButtonRect.Checked = true;
            radioButtonRect.Location = new Point(6, 22);
            radioButtonRect.Name = "radioButtonRect";
            radioButtonRect.Size = new Size(114, 19);
            radioButtonRect.TabIndex = 0;
            radioButtonRect.TabStop = true;
            radioButtonRect.Text = "Прямоугольник";
            radioButtonRect.UseVisualStyleBackColor = true;
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
            // tabPagePresets
            // 
            tabPagePresets.Controls.Add(dataGridViewPresets);
            tabPagePresets.Controls.Add(toolStrip1);
            tabPagePresets.Location = new Point(4, 24);
            tabPagePresets.Name = "tabPagePresets";
            tabPagePresets.Size = new Size(487, 219);
            tabPagePresets.TabIndex = 3;
            tabPagePresets.Text = "Пресеты";
            tabPagePresets.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPresets
            // 
            dataGridViewPresets.AllowUserToAddRows = false;
            dataGridViewPresets.AllowUserToDeleteRows = false;
            dataGridViewPresets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPresets.Columns.AddRange(new DataGridViewColumn[] { ColIndex, ColFontColor, ColFontStrokeColor, ColRectangleColor, ColGradStart, ColGradEnd, ColDrawRect, ColGrad });
            dataGridViewPresets.Dock = DockStyle.Fill;
            dataGridViewPresets.Location = new Point(0, 25);
            dataGridViewPresets.Name = "dataGridViewPresets";
            dataGridViewPresets.ReadOnly = true;
            dataGridViewPresets.Size = new Size(487, 194);
            dataGridViewPresets.TabIndex = 1;
            dataGridViewPresets.CellDoubleClick += dataGridViewPresets_CellDoubleClick;
            // 
            // ColIndex
            // 
            ColIndex.HeaderText = "Index";
            ColIndex.Name = "ColIndex";
            ColIndex.ReadOnly = true;
            ColIndex.Width = 50;
            // 
            // ColFontColor
            // 
            ColFontColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColFontColor.HeaderText = "FontColor";
            ColFontColor.Name = "ColFontColor";
            ColFontColor.ReadOnly = true;
            // 
            // ColFontStrokeColor
            // 
            ColFontStrokeColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColFontStrokeColor.HeaderText = "StrokeColor";
            ColFontStrokeColor.Name = "ColFontStrokeColor";
            ColFontStrokeColor.ReadOnly = true;
            // 
            // ColRectangleColor
            // 
            ColRectangleColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColRectangleColor.HeaderText = "RectangleColor";
            ColRectangleColor.Name = "ColRectangleColor";
            ColRectangleColor.ReadOnly = true;
            // 
            // ColGradStart
            // 
            ColGradStart.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColGradStart.HeaderText = "GradientStart";
            ColGradStart.Name = "ColGradStart";
            ColGradStart.ReadOnly = true;
            // 
            // ColGradEnd
            // 
            ColGradEnd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColGradEnd.HeaderText = "GradientEnd";
            ColGradEnd.Name = "ColGradEnd";
            ColGradEnd.ReadOnly = true;
            // 
            // ColDrawRect
            // 
            ColDrawRect.HeaderText = "Draw";
            ColDrawRect.Name = "ColDrawRect";
            ColDrawRect.ReadOnly = true;
            ColDrawRect.Width = 40;
            // 
            // ColGrad
            // 
            ColGrad.HeaderText = "Grad";
            ColGrad.Name = "ColGrad";
            ColGrad.ReadOnly = true;
            ColGrad.Width = 40;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAddPreset, toolStripButtonRemovePreset });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(487, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddPreset
            // 
            toolStripButtonAddPreset.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAddPreset.Image = Properties.Resources.i48_load;
            toolStripButtonAddPreset.ImageTransparentColor = Color.Magenta;
            toolStripButtonAddPreset.Name = "toolStripButtonAddPreset";
            toolStripButtonAddPreset.Size = new Size(23, 22);
            toolStripButtonAddPreset.Text = "toolStripButton1";
            toolStripButtonAddPreset.Click += toolStripButtonAddPreset_Click;
            // 
            // toolStripButtonRemovePreset
            // 
            toolStripButtonRemovePreset.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRemovePreset.Image = Properties.Resources.i48_hide;
            toolStripButtonRemovePreset.ImageTransparentColor = Color.Magenta;
            toolStripButtonRemovePreset.Name = "toolStripButtonRemovePreset";
            toolStripButtonRemovePreset.Size = new Size(23, 22);
            toolStripButtonRemovePreset.Text = "toolStripButton2";
            toolStripButtonRemovePreset.Click += toolStripButtonRemovePreset_Click;
            // 
            // dataGridViewImages
            // 
            dataGridViewImages.AllowUserToAddRows = false;
            dataGridViewImages.AllowUserToDeleteRows = false;
            dataGridViewImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewImages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewImages.Columns.AddRange(new DataGridViewColumn[] { ImagePath });
            dataGridViewImages.ContextMenuStrip = contextMenuStripImages;
            dataGridViewImages.Location = new Point(3, 240);
            dataGridViewImages.Name = "dataGridViewImages";
            dataGridViewImages.ReadOnly = true;
            dataGridViewImages.Size = new Size(495, 229);
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
            // contextMenuStripImages
            // 
            contextMenuStripImages.Items.AddRange(new ToolStripItem[] { копироватьДанныеToolStripMenuItem, вставитьДанныеToolStripMenuItem });
            contextMenuStripImages.Name = "contextMenuStripDataset";
            contextMenuStripImages.Size = new Size(184, 48);
            // 
            // копироватьДанныеToolStripMenuItem
            // 
            копироватьДанныеToolStripMenuItem.Name = "копироватьДанныеToolStripMenuItem";
            копироватьДанныеToolStripMenuItem.Size = new Size(183, 22);
            копироватьДанныеToolStripMenuItem.Text = "Копировать данные";
            копироватьДанныеToolStripMenuItem.Click += копироватьДанныеToolStripMenuItem_Click;
            // 
            // вставитьДанныеToolStripMenuItem
            // 
            вставитьДанныеToolStripMenuItem.Name = "вставитьДанныеToolStripMenuItem";
            вставитьДанныеToolStripMenuItem.Size = new Size(183, 22);
            вставитьДанныеToolStripMenuItem.Text = "Вставить данные";
            вставитьДанныеToolStripMenuItem.Click += вставитьДанныеToolStripMenuItem_Click;
            // 
            // dataGridViewTranslationData
            // 
            dataGridViewTranslationData.AllowUserToAddRows = false;
            dataGridViewTranslationData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewTranslationData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTranslationData.ContextMenuStrip = contextMenuStripTranslation;
            dataGridViewTranslationData.Location = new Point(3, 3);
            dataGridViewTranslationData.Name = "dataGridViewTranslationData";
            dataGridViewTranslationData.Size = new Size(495, 231);
            dataGridViewTranslationData.TabIndex = 14;
            dataGridViewTranslationData.SelectionChanged += dataGridViewTranslationData_SelectionChanged;
            // 
            // contextMenuStripTranslation
            // 
            contextMenuStripTranslation.Name = "contextMenuStripTranslation";
            contextMenuStripTranslation.Size = new Size(61, 4);
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
            pictureBoxImage.MouseClick += pictureBoxImage_MouseClick;
            pictureBoxImage.MouseDown += pictureBoxImage_MouseDown;
            pictureBoxImage.MouseMove += pictureBoxImage_MouseMove;
            pictureBoxImage.MouseUp += pictureBoxImage_MouseUp;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel, toolStripStatusLabelColor, toolStripStatusLabel2, toolStripStatusLabelMode });
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
            // toolStripStatusLabelColor
            // 
            toolStripStatusLabelColor.Name = "toolStripStatusLabelColor";
            toolStripStatusLabelColor.Size = new Size(70, 17);
            toolStripStatusLabelColor.Text = "        COLOR";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(68, 17);
            toolStripStatusLabel2.Text = "         Mode:";
            // 
            // toolStripStatusLabelMode
            // 
            toolStripStatusLabelMode.Name = "toolStripStatusLabelMode";
            toolStripStatusLabelMode.Size = new Size(12, 17);
            toolStripStatusLabelMode.Text = "-";
            // 
            // изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem
            // 
            изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem.Name = "изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem";
            изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem.Size = new Size(523, 22);
            изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem.Text = "Изменить координаты по размеру изображения для всех";
            изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem.Click += изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem_Click;
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPagePresets.ResumeLayout(false);
            tabPagePresets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPresets).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImages).EndInit();
            contextMenuStripImages.ResumeLayout(false);
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
        private ComboBox comboBoxGradientAngle;
        private Button buttonGrEndColor;
        private Button buttonGrStartColor;
        private CheckBox checkBoxUseGradient;
        private GroupBox groupBox1;
        private RadioButton radioButtonFontContur;
        private RadioButton radioButtonFont;
        private RadioButton radioButtonRectGrDown;
        private RadioButton radioButtonRectGrTop;
        private RadioButton radioButtonRect;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem пКМЦветПрямоугольникаToolStripMenuItem;
        private ToolStripMenuItem пКМЦветНачалаГрадиентаToolStripMenuItem;
        private ToolStripMenuItem пКМЦветКонцаГрадиентаToolStripMenuItem;
        private ToolStripMenuItem пКМЦветШрифтаToolStripMenuItem;
        private ToolStripMenuItem пКМЦветОбводкиToolStripMenuItem;
        private TabPage tabPagePresets;
        private DataGridView dataGridViewPresets;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAddPreset;
        private ToolStripButton toolStripButtonRemovePreset;
        private DataGridViewTextBoxColumn ColIndex;
        private DataGridViewTextBoxColumn ColFontColor;
        private DataGridViewTextBoxColumn ColFontStrokeColor;
        private DataGridViewTextBoxColumn ColRectangleColor;
        private DataGridViewTextBoxColumn ColGradStart;
        private DataGridViewTextBoxColumn ColGradEnd;
        private DataGridViewCheckBoxColumn ColDrawRect;
        private DataGridViewCheckBoxColumn ColGrad;
        private ToolStripStatusLabel toolStripStatusLabelColor;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabelMode;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem создатьСписокПереводапервыйЭлементИзображенияToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem применитьТекущиеКоординатыКоВсемСхожимИзображениямToolStripMenuItem;
        private ToolStripMenuItem применитьТекущиеКоординатыИНастройкиКоВсемСхожимИзображениямToolStripMenuItem;
        private ToolStripMenuItem автоматическиОбнаружитьЦветФонаДляТекущегоToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem применитьТекущиеЧисловыеНастройкиШрифтаКоВсемToolStripMenuItem;
        private ToolStripMenuItem применитьТекущиеНастройкиПрямоугольникаКоВсемСхожимИзображениямToolStripMenuItem;
        private ToolStripMenuItem применитьТекущиеНастройкиШрифтаКоВсемСхожимИзображениямToolStripMenuItem;
        private CheckBox checkBoxFontDrawOnAlpha;
        private CheckBox checkBoxRectDrawOnAlpha;
        private ToolStripMenuItem добавитьИзображенияБезПереводаToolStripMenuItem;
        private ContextMenuStrip contextMenuStripImages;
        private ToolStripMenuItem копироватьДанныеToolStripMenuItem;
        private ToolStripMenuItem вставитьДанныеToolStripMenuItem;
        private ContextMenuStrip contextMenuStripTranslation;
        private ToolStripMenuItem автоматическиОбнаружитьЦветФонаДляВыделенныхToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem изменитьКоординатыПоРазмеруИзображенияДляВсехToolStripMenuItem;
    }
}
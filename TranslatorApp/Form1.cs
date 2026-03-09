using UniversalAITranslator;

namespace TranslatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private AiTranslator translator;
        private ModelConfiguration configuration;


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSystemPrompt.Text))
                translator.SetDefaultSystemPrompt();
            else
                translator.SetSystemPrompt(textBoxSystemPrompt.Text);
            button1.Enabled = false;
            textBoxInput.Enabled = false;
            textBoxOutput.Enabled = false;
            try
            {
                textBoxOutput.Text = (await translator.TranslateText(textBoxInput.Text, false)).Replace("\n", "\r\n");
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = ex.Message;
            }
            button1.Enabled = true;
            textBoxInput.Enabled = true;
            textBoxOutput.Enabled = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //translator.GetStructuredFormat();
            Form_TranslateDataset translateDataset = new Form_TranslateDataset();
            translateDataset.ShowDialog();
        }

        private void íàñòðîéêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigManager config = new ConfigManager();
            Form_AiServerConfig configForm = new Form_AiServerConfig();
            configForm.SetConfiguration(config.ServerConfiguration);
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                configuration = configForm.GetConfiguration();
                translator = new AiTranslator(configuration);
                config.ServerConfiguration = configForm.GetConfiguration();
                config.Save();
            }
        }
    }
}

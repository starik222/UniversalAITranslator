using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UniversalAITranslator.DirectSpeechFixer;

namespace UniversalAITranslator
{
    public partial class Form_AiServerConfig : Form
    {
        private string lastModel = "";
        public Form_AiServerConfig()
        {
            InitializeComponent();
            textBoxServerUrl.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void trackBarTemperature_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = ((float)trackBarTemperature.Value / 100f).ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string key = "lm-studio";
            if (!string.IsNullOrEmpty(textBoxKey.Text))
                key = textBoxKey.Text;
            var models = await AiServerUtils.GetModelList(textBoxServerUrl.Text, key);
            comboBoxModel.Items.Clear();
            comboBoxModel.Items.AddRange(models.ToArray());
            if (!string.IsNullOrEmpty(lastModel))
            {
                comboBoxModel.SelectedItem = lastModel;
            }
        }

        /// <summary>
        /// Получает настройки с формы, возвращая ModelConfiguration
        /// </summary>
        /// <returns></returns>
        public ModelConfiguration GetConfiguration()
        {
            ModelConfiguration configuration = new ModelConfiguration();
            if (!string.IsNullOrEmpty(textBoxKey.Text))
                configuration.ApiKey = textBoxKey.Text;

            configuration.NeedFixDirectSpeech = checkBoxUseFixText.Checked;
            if (configuration.NeedFixDirectSpeech)
            {
                if (radioButtonNonQuote.Checked)
                    configuration.DirectSpeechFixType = DirectSpeechFixer.FixType.ClearedText;
                else if (radioButtonJapQuote.Checked)
                    configuration.DirectSpeechFixType = DirectSpeechFixer.FixType.JapaneseQuote;
                else if (radioButtonCommonQuote.Checked)
                    configuration.DirectSpeechFixType = DirectSpeechFixer.FixType.CommonQuote;
                else if (radioButtonRusQuote.Checked)
                    configuration.DirectSpeechFixType = DirectSpeechFixer.FixType.RussianDirectSpeech;
                else
                    configuration.DirectSpeechFixType = DirectSpeechFixer.FixType.None;
            }
            configuration.Temperature = ((float)trackBarTemperature.Value / 100f);
            configuration.MaxTokens = (int)numericUpDownMaxTokens.Value;
            configuration.Seed = (int)numericUpDownSeed.Value;
            configuration.Endpoint = textBoxServerUrl.Text;
            configuration.ModelName = comboBoxModel.SelectedItem.ToString();
            configuration.MaxLinesInQuery = (int)numericUpDownMaxLines.Value;
            return configuration;
        }

        /// <summary>
        /// Устанавливает настройки на форме из ModelConfiguration
        /// </summary>
        /// <param name="configuration"></param>
        public void SetConfiguration(ModelConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.ApiKey))
                textBoxKey.Text = configuration.ApiKey;

            checkBoxUseFixText.Checked = configuration.NeedFixDirectSpeech;
            if (configuration.NeedFixDirectSpeech)
            {
                switch (configuration.DirectSpeechFixType)
                {
                    case FixType.ClearedText:
                        {
                            radioButtonNonQuote.Checked = true;
                            break;
                        }
                    case FixType.JapaneseQuote:
                        {
                            radioButtonJapQuote.Checked = true;
                            break;
                        }
                    case FixType.CommonQuote:
                        {
                            radioButtonCommonQuote.Checked = true;
                            break;
                        }
                    case FixType.RussianDirectSpeech:
                        {
                            radioButtonRusQuote.Checked = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            trackBarTemperature.Value = (int)(configuration.Temperature * 100f);
            numericUpDownMaxTokens.Value = configuration.MaxTokens;
            numericUpDownSeed.Value = configuration.Seed;
            textBoxServerUrl.Text = configuration.Endpoint;
            if (comboBoxModel.Items.Count == 0)
            {
                lastModel = configuration.ModelName;
                if (lastModel != null)
                    comboBoxModel.Items.Add(lastModel);
            }
            comboBoxModel.SelectedItem = configuration.ModelName;
            numericUpDownMaxLines.Value = configuration.MaxLinesInQuery;
        }
    }
}

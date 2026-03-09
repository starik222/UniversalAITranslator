using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class ConfigManager
    {
        public ModelConfiguration ServerConfiguration { get; set; }
        public string LastPromptFile { get; set; } = "";

        public ConfigManager(bool loadFromFile = true)
        {
            if (loadFromFile)
            {
                ConfigManager? tempConfig;
                if (File.Exists(Constants.ConfigFile))
                {
                    try
                    {
                        tempConfig = JsonConvert.DeserializeObject<ConfigManager>(File.ReadAllText(Constants.ConfigFile));
                        if (tempConfig == null)
                            tempConfig = new ConfigManager(false);
                    }
                    catch
                    {
                        tempConfig = new ConfigManager(false);
                    }
                }
                else
                    tempConfig = new ConfigManager(false);
                ServerConfiguration = tempConfig.ServerConfiguration;
                LastPromptFile = tempConfig.LastPromptFile;
            }
            else
            {
                ServerConfiguration = new ModelConfiguration();
            }
        }

        public void Save()
        {
            File.WriteAllText(Constants.ConfigFile, JsonConvert.SerializeObject(this));
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class StructuredTranslationManager
    {
        public List<ChacterInfo> Characters { get; set; }

        public StructuredTranslationManager()
        {
            Characters = new List<ChacterInfo>();
        }

        public StructuredTranslationManager(List<KeyValuePair<string,string>> charaNames)
        {
            Characters = new List<ChacterInfo>();
            foreach (var charaName in charaNames)
            {
                ChacterInfo info = new() { OriginalName = charaName.Key, TranslatedName = charaName.Value };
                if (!Characters.Exists(a => a.OriginalName == info.OriginalName))
                    Characters.Add(info);
            }
        }

        public void AddCharaInfo(string origName, string translatedName)
        {
            ChacterInfo info = new() { OriginalName = origName, TranslatedName = translatedName };
            if (!Characters.Exists(a => a.OriginalName == info.OriginalName))
                Characters.Add(info);
        }

        //public void LoadFromNamesDict()
        //{
        //    foreach (var item in Program.tools.names)
        //    {
        //        ChacterInfo info = new() { OriginalName = item.orig_name, TranslatedName = item.translit_name };
        //        Characters.Add(info);
        //    }
        //}

        public StructuredTranslationData CreateTranslationData()
        {
            var data = new StructuredTranslationData();
            foreach (var item in Characters)
            {
                data.Names.Add(new StructuredTranslationData.NamesItem() { Original = item.OriginalName, Translate = item.TranslatedName });
            }
            return data;
        }

        public StructuredTranslationData CreateTranslationData(Dictionary<string, string> customCharaTranslation)
        {
            var data = new StructuredTranslationData();
            foreach (var item in customCharaTranslation)
            {
                data.Names.Add(new StructuredTranslationData.NamesItem() { Original = item.Key, Translate = item.Value });
            }
            return data;
        }

        public void SetGender(StructuredTranslationData data)
        {
            foreach (var item in data.TextData)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    item.Gender = "мужской";
                }
                else
                {
                    var foundedCharacter = Characters.FirstOrDefault(a => a.OriginalName == item.Name || a.TranslatedName == item.Name);
                    if (foundedCharacter != null)
                    {
                        item.Gender = foundedCharacter.Gender == GenderCode.Male ? "мужской" : "женский";
                    }
                    else
                    {
                        //вызов формы для указания пола?
                    }
                }
            }
        }

        public void RemoveUnusedNames(StructuredTranslationData data)
        {
            List<StructuredTranslationData.NamesItem> toDel = new List<StructuredTranslationData.NamesItem>();
            foreach (var item in data.Names)
            {
                bool needDelete = true;
                foreach (var line in data.TextData)
                {
                    if (line.Text.Contains(item.Original))
                    {
                        needDelete = false;
                        break;
                    }
                }
                if (needDelete)
                    toDel.Add(item);
            }
            foreach (var item in toDel)
                data.Names.Remove(item);
        }

        public void Save(string savePath)
        {
            File.WriteAllText(savePath, JsonConvert.SerializeObject(Characters, Formatting.Indented));
        }

        public void Load(string dictPath)
        {
            Characters = JsonConvert.DeserializeObject<List<ChacterInfo>>(File.ReadAllText(dictPath));
        }

        public List<StructuredTranslationData> SplitTranslationData(StructuredTranslationData data, int maxLines)
        {
            List<StructuredTranslationData> result = new List<StructuredTranslationData>();
            int parts = 1;
            int testCount = data.TextData.Count / parts;
            while (testCount > maxLines)
            {
                parts++;
                testCount = data.TextData.Count / parts;
            }
            for (int i = 0; i < parts; i++)
            {
                StructuredTranslationData partData = new StructuredTranslationData();
                partData.Names = new List<StructuredTranslationData.NamesItem>(data.Names);
                if (i != parts - 1)
                {
                    partData.TextData = data.TextData.GetRange(i * testCount, testCount);
                }
                else
                {
                    partData.TextData = data.TextData.GetRange(i * testCount, data.TextData.Count - i * testCount);
                }
                RemoveUnusedNames(partData);
                result.Add(partData);
            }
            return result;
        }

        public class ChacterInfo
        {
            public string OriginalName { get; set; }
            public string TranslatedName { get; set; }
            public GenderCode Gender { get; set; } = GenderCode.Female;
        }

        public enum GenderCode
        {
            Male,
            Female
        }

    }
}

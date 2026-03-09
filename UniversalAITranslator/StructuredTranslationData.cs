using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class StructuredTranslationData
    {
        public List<NamesItem> Names { get; set; }
        public List<TextDataItem> TextData { get; set; }

        public StructuredTranslationData()
        {
            Names = new List<NamesItem>();
            TextData = new List<TextDataItem>();
        }


        public class NamesItem
        {
            public string Original { get; set; }
            public string Translate { get; set; }
        }
        public class TextDataItem
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Text { get; set; }
            public TextType Type { get; set; }
        }
        public enum TextType
        {
            FirstPerson,
            Description,
            Selection
        }
    }
}

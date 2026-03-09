using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class TypedTranslationData
    {
        public int Id { get; set; }
        [JsonIgnore]
        public bool Enabled { get; set; } = true;
        [JsonConverter(typeof(StringEnumConverter))]
        public TextType Type { get; set; } = TextType.Name;
        public string Name { get; set; } = "";
        //public string Gender { get; set; } = "";
        public string Text { get; set; } = "";
        public string TranslatedText { get; set; } = "";


        public TypedTranslationData Clone()
        {
            TypedTranslationData clonedItem = new TypedTranslationData();
            clonedItem.Id = Id;
            clonedItem.Enabled = Enabled;
            clonedItem.Type = Type;
            clonedItem.Text = Text;
            clonedItem.Name = Name;
            clonedItem.TranslatedText = TranslatedText;
            return clonedItem;
        }

        public TypedTranslationRequestItem CreateTypedRequestItem()
        {
            TypedTranslationRequestItem item = new TypedTranslationRequestItem();
            item.Id = Id;
            item.Type = Type;
            item.Text = Text;
            return item;
        }
    }
}

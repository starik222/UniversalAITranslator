using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class TypedTranslationRequestItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TextType Type { get; set; } = TextType.Description;
        [JsonProperty("text")]
        public string Text { get; set; } = "";



        public TypedTranslationData CreateTypedItem()
        {
            TypedTranslationData item = new TypedTranslationData();
            item.Id = Id;
            item.Type = Type;
            item.Text = Text;
            item.Enabled = false;
            return item;
        }
    }
}

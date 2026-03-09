using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class StructuredTranslationResponse
    {
        //public List<StructuredTranslationItem> TranslationResult { get; set; }
        public string[] translated_items { get; set; }

        public StructuredTranslationResponse()
        {
            //TranslationResult = new List<StructuredTranslationItem>();
        }

        public class StructuredTranslationItem
        {
            public string TranslatedItem { get; set; }
        }

    }

}

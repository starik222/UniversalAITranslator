using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public class ModelConfiguration
    {
        public string Endpoint { get; set; }
        public string ModelName { get; set; }
        public string ApiKey { get; set; } = "lm-studio";
        public float Temperature { get; set; } = 0;
        public int MaxTokens { get; set; } = -1;
        public long Seed { get; set; } = -1;
        public bool NeedFixDirectSpeech { get; set; } = false;
        public DirectSpeechFixer.FixType DirectSpeechFixType { get; set; } = DirectSpeechFixer.FixType.None;
        public int MaxLinesInQuery { get; set; } = 2000;
        public bool ShrinkContext { get; set; } = false;
        public int KeepLastNRequestInContext { get; set; } = 2;
    }
}

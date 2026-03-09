using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public static class DirectSpeechFixer
    {
        public static string FixText(string text, FixType fixType)
        {
            string clearedText = ClearText(text);
            if (text.StartsWith('(') && (text.EndsWith(')') || text.EndsWith(").")))
            {
                if (text.EndsWith(")."))
                {
                    return text.Replace(").", ")");
                }
                return text;
            }
            switch (fixType)
            {
                case FixType.ClearedText:
                    return clearedText;
                case FixType.JapaneseQuote:
                    return string.Concat('「', clearedText, '」');
                case FixType.CommonQuote:
                    return string.Concat('«', clearedText, '»');
                case FixType.RussianDirectSpeech:
                    return string.Concat("— ", clearedText);
                default:
                    return text;
            }
        }

        public static string ClearText(string text)
        {
            string result = text.Trim();
            char startChar = result[0];
            char endChar = result[result.Length - 1];
            if (startChar == '—' && result.Length > 1 && result[1] == ' ')
                return result.Substring(2);
            else if (startChar == '「' && endChar == '」')
                return result.Substring(1, result.Length - 2);
            else if (startChar == '«' && endChar == '»')
                return result.Substring(1, result.Length - 2);
            else if (startChar == '\"' && endChar == '\"')
                return result.Substring(1, result.Length - 2);
            else if (startChar == '«' && result.EndsWith("»."))
                return result.Substring(1, result.Length - 3) + ".";
            return text;
        }



        public enum FixType
        {
            None,
            ClearedText,
            JapaneseQuote,
            CommonQuote,
            RussianDirectSpeech
        }
    }
}

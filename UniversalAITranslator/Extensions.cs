using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalAITranslator
{
    public static class Extensions
    {

        public delegate void TextDelegate(string text);
        public delegate void BoolDelegate(bool value);

        public static String ToHex(this System.Drawing.Color c) => $"{c.R:X2}{c.G:X2}{c.B:X2}";
        public static string GetBetween(this string strSource, string strStart, string strEnd)
        {
            const int kNotFound = -1;

            var startIdx = strSource.IndexOf(strStart);
            if (startIdx != kNotFound)
            {
                startIdx += strStart.Length;
                var endIdx = strSource.IndexOf(strEnd, startIdx);
                if (endIdx > startIdx)
                {
                    return strSource.Substring(startIdx, endIdx - startIdx);
                }
            }
            return String.Empty;
        }

        public static string GetBetween(this string strSource, string strStart, string strEnd, int startIndex)
        {
            const int kNotFound = -1;

            var startIdx = strSource.IndexOf(strStart, startIndex);
            if (startIdx != kNotFound)
            {
                startIdx += strStart.Length;
                var endIdx = strSource.IndexOf(strEnd, startIdx);
                if (endIdx > startIdx)
                {
                    return strSource.Substring(startIdx, endIdx - startIdx);
                }
            }
            return String.Empty;
        }
    }
}

using System;
using System.Linq;

namespace Wild.Strings
{
    public static class StringExtensions
    {
        /// <summary>
        /// Возвращает строку в заданном регистре
        /// </summary>
        public static string ToCase(this string text, CaseTypes type)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            switch (type)
            {
                case CaseTypes.Upper:
                    text = text.ToUpper();
                    break;
                case CaseTypes.Lower:
                    text = text.ToLower();
                    break;
            }
            return text;
        }

        public static bool IsOnlyDigits(this string source)
        {
            foreach (char c in source)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public static int ExtractStartInt32(this string source, int defaultValue)
        {
            int value = 0;
            string onlyDigits = new string(source.TakeWhile(c => c == '-' || c =='+' || char.IsDigit(c)).ToArray());
            if (int.TryParse(onlyDigits, out value))
                return value;
            return defaultValue;
        }
    }
}
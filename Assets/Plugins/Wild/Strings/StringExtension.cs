namespace Wild.Strings
{
    public static class StringExtension
    {
        /// <summary>
        /// Возвращает строку в заданном регистре
        /// </summary>
        public static string ToCase(this string text, CaseTypes type)
        {
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
    }
}

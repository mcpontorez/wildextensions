using System;
using System.Collections.Generic;
using System.Linq;

namespace Wild.Enums
{
    public class EnumUtils
    {
        public static List<TEnum> GetValues<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }
    }
}

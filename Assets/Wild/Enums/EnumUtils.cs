using System;
using System.Collections.Generic;
using System.Linq;

namespace Wild.Enums
{
    public class EnumUtils
    {
        public static TEnum[] GetValues<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        }
    }
}

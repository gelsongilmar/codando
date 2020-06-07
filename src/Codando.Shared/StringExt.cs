using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Shared
{
    public static class StringExt
    {
        public static bool IsNumeric(this string text) => double.TryParse(text, out _);
        public static String PascalCasing(this string text) => ((text.Length > 0) ? text.Substring(0, 1).ToUpper() : "") + ((text.Length > 1) ? text.Substring(1) : "");

    }
}

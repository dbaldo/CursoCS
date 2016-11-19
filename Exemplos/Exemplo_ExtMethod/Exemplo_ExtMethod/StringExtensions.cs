using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemplo_ExtMethod
{
    static class StringExtensions
    {
        public static string Capitalize(this string self)
        {
            return Regex.Replace(self.ToLower(), @"\b[a-z]", (m) => m.Value.ToUpper());
        }
    }
}

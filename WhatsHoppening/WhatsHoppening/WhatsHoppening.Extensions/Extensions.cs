using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Extensions
{
    public static class Extensions
    {
        public static string FormatWith(this string text, params object[] args)
        {
            return string.Format(text, args);
        }
    }
}

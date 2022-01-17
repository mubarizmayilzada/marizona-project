using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marizona.WebUI.Core.Extensions
{
    static public partial class Extension
    {

        public static string PlainText(this string text)
        {
            return Regex.Replace(text, @"<[^>]*>", "");
        }

        public static bool? IsEmail(this string text)
        {
            return Regex.IsMatch(text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }


}

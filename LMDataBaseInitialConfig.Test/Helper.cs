using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LMDataBaseInitialConfig.Test
{
    public static class Helper
    {
        public static bool CompareOnlyCaracterString(string a, string b)
        {

            Regex rgx = new Regex("[^A-Za-z0-9_]");
            a = rgx.Replace(a, "");
            b = rgx.Replace(b, "");

            return a.Equals(b);


        }

    }
}

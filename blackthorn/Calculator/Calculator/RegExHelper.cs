using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    public static class RegExHelper
    {
        public const string SignedIntegerPattern = @"^-?[0-9]+$";
        public static bool ValidateAndParseNumbers<T>(string input, string pattern, out T output) where T : struct
        {
            var result = false;
            output = default(T);

            var match = Regex.Match(input, pattern);
            if (match.Success)
            {
                Type t = typeof(T);
                output = (T)Convert.ChangeType(input, t);
                result = true;
            }
            return result;
        }

        public static bool ValidateOperator(string input)
        {
            var operators = new List<string> { "+", "-", "/", "%", "*" };

            return operators.Contains(input.Trim());
        }
    }
}

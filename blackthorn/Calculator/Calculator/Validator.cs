using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Calculator.Interfaces;

namespace Calculator
{
    public static class Validator
    {
        public const string SignedIntegerPattern = @"^-?[0-9]+$";
        public static bool ValidateAndParseNumbers<T>(string input, string pattern, out T output)
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
            var operators = new List<string> { "+", "-" }; 

            return operators.Contains(input.Trim());
        }
    }
}

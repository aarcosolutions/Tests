using Calculator.Interfaces;
using System;

namespace Calculator
{
    public class DecCalculator : BaseCalculator, ICalculator
    {
        public DecCalculator(ILogger logger):base(logger)
        {

        }

        public long Calculate(IInput input)
        {
            var result = input.FirstArgument;

            switch (input.Operator)
            {
                case "+":
                    result += input.SecondArgument;
                    break;

                case "-":
                    result -= input.SecondArgument;
                    break;

                default:
                    throw new NotImplementedException(string.Format("Operator {0} is not implemented",input.Operator));
            }

            return result;
        }
    }
}

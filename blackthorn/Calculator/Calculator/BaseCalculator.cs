using Calculator.Interfaces;
using System;

namespace Calculator
{
    public abstract class BaseCalculator
    {
        private readonly ILogger _logger;

        public BaseCalculator(ILogger logger)
        {
            _logger = logger;
        }

        protected ILogger Logger
        {
            get
            {
                return _logger;
            }
        }

        protected void Validate(IInput input)
        {
            if (input.Operator == "/" && input.SecondArgument == 0)
                throw new ArgumentException("Division by zero.");
        }
    }
}

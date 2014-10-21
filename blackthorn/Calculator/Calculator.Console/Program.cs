using Calculator.Domain;
using Calculator.Interfaces;
using Calculator.Logging;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ui = System.Console;
using Calculator.DependencyResolver;

namespace Calculator.Console
{
    class Program
    {
        private static ILogger _logger;
        static void Main(string[] args)
        {
            StructureMapResolver.ConfigureDependencies();
            _logger = StructureMapResolver.Container.GetInstance<ILogger>();

            Start();
            
        }

        private static void Start()
        {
            ui.WriteLine("Simple Calculator");
            ui.WriteLine("-----------------");

            try
            {
                var inputs = InitiateInputs();
                var result = Calculate(inputs);
                ui.WriteLine("Result: {0}", result);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
            }
            ui.ReadLine();
        }

        private static IInput InitiateInputs()
        {
            var inputValues = new Input();
            inputValues.FirstArgument =  Input<long>("Enter a number:", false);
            inputValues.SecondArgument = Input<long>("Enter another number:", false);
            inputValues.Operator = Input<string>("Enter an operator (+/-):", true);
            return inputValues;
        }

        private static T Input<T>(string message, bool isOperator)
        {
            bool isValid = false;
            T parsedValue = default(T);
            var errorMsg = isOperator ? "Please enter a valid operator. Possible values are + -" : "Please enter integer values only.";
            do
            {
                ui.Write(message);
                var input = ui.ReadLine();

                if (!isOperator && Validator.ValidateAndParseNumbers<T>(input, Validator.SignedIntegerPattern, out parsedValue))
                    isValid = true;
                else if (isOperator && Validator.ValidateOperator(input))
                {
                    parsedValue = (T)Convert.ChangeType(input, typeof(T));
                    isValid = true;
                }
                else
                    _logger.Log(errorMsg);
            }
            while (!isValid);
            return parsedValue;
        }

        private static long Calculate(IInput input)
        {
            var decimalCalculator = StructureMapResolver.Container.GetInstance<ICalculator>(CalculatorMode.Decimal.ToString());
            var result = decimalCalculator.Calculate(input);
            return result;
        }
    }
}


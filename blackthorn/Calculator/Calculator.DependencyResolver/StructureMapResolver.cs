using Calculator.Domain;
using Calculator.Interfaces;
using Calculator.Logging;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DependencyResolver
{
    public static class StructureMapResolver
    {
        private static IContainer _container;

        static StructureMapResolver()
        {
            ConfigureDependencies();
        }

        public  static void ConfigureDependencies()
        {
            _container = new Container();
            _container.Configure(x => x.For<IInput>().Use<Input>());
            _container.Configure(x => x.For<ILogger>().Use<ConsoleLogger>());
            _container.Configure(x => x.For<ICalculator>().Use<DecCalculator>().Named(CalculatorMode.Decimal.ToString()));
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}

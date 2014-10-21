using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.DependencyResolver;
using StructureMap;
using Calculator.Interfaces;
using FluentAssertions;
using Calculator.Logging;

namespace Calculator.Test
{
    [TestClass]
    public class DependencyResolverTest
    {
        [TestInitialize]
        public void Initialise()
        {
            StructureMapResolver.ConfigureDependencies();
        }

        [TestMethod]
        [TestCategory("StructureMapResolver - Happy Path - ValidateAndParseNumbers")]
        public void When_Resolving_Logger_Dependency_Should_Return_ConsoleLogger()
        {
            var logger = StructureMapResolver.Container.GetInstance<ILogger>();

            logger.Should().BeOfType<ConsoleLogger>();
        }

        [TestMethod]
        [TestCategory("StructureMapResolver - Happy Path - ValidateAndParseNumbers")]
        public void When_Resolving_DecimalCalculator_Dependency_Should_Return_DecimalCalculator()
        {
            var calculator = StructureMapResolver.Container.GetInstance<ICalculator>(CalculatorMode.Decimal.ToString());

            calculator.Should().BeOfType<DecCalculator>();
        }

        [TestMethod]
        [TestCategory("StructureMapResolver - Sad Path - ValidateAndParseNumbers")]
        public void When_Resolving_BinaryCalculator_Dependency_Should_Return_Exception()
        {
            Action action =()=> StructureMapResolver.Container.GetInstance<ICalculator>(CalculatorMode.Binary.ToString());
            action.ShouldThrow<StructureMapConfigurationException>("because Binary calculator is not configured.");
        }
    }
}

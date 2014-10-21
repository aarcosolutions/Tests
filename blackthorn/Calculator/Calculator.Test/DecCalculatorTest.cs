using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using Calculator.Interfaces;
using Calculator.Domain;

namespace Calculator.Test
{
    /// <summary>
    /// Summary description for DecCalculatorTest
    /// </summary>
    [TestClass]
    public class DecCalculatorTest
    {
        [TestMethod]
        [TestCategory("DecCalculator - Happy Path - Calculate")]
        public void When_Adding_Two_Number_Should_Return_Correct_Result()
        {
            var logMock = new Mock<ILogger>();
            var decCalculator = new DecCalculator(logMock.Object);

            var input = new Input
            {
                FirstArgument = 5,
                Operator = "+",
                SecondArgument = 5
            };

            var result = decCalculator.Calculate(input);

            result.Should().Be(10);
        }

        [TestMethod]
        [TestCategory("DecCalculator - Happy Path - Calculate")]
        public void When_Substracting_Two_Number_Should_Return_Correct_Result()
        {
            var logMock = new Mock<ILogger>();
            var decCalculator = new DecCalculator(logMock.Object);

            var input = new Input
            {
                FirstArgument = 15,
                Operator = "-",
                SecondArgument = 5
            };

            var result = decCalculator.Calculate(input);

            result.Should().Be(10);
        }

        [TestMethod]
        [TestCategory("DecCalculator - Happy Path - Calculate")]
        public void When_Substracting_Two_Negative_Number_Should_Return_Correct_Result()
        {
            var logMock = new Mock<ILogger>();
            var decCalculator = new DecCalculator(logMock.Object);

            var input = new Input
            {
                FirstArgument = -15,
                Operator = "-",
                SecondArgument = -5
            };

            var result = decCalculator.Calculate(input);

            result.Should().Be(-10);
        }

        [TestMethod]
        [TestCategory("DecCalculator - Sad Path - Calculate")]
        public void When_Dividin_Two_Number_Should_Raise_NotImplementException()
        {
            var logMock = new Mock<ILogger>();
            var decCalculator = new DecCalculator(logMock.Object);

            var input = new Input
            {
                FirstArgument = 15,
                Operator = "/",
                SecondArgument = 5
            };

            Action action = () =>decCalculator.Calculate(input);

            action.ShouldThrow<NotImplementedException>()
                .WithMessage(string.Format("Operator {0} is not implemented", input.Operator));
        }
    }
}

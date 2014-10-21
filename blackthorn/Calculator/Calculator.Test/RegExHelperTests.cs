using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calculator.Interfaces;
using FluentAssertions;

namespace Calculator.Test
{
    [TestClass]
    public class RegExHelperTests
    {
        #region Tests related to ValidateAndParseNumbers
        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_NegativeIntegerString_Should_Return_True_Parsed_NegativeInteger()
        {
            int output;
            var result = RegExHelper.ValidateAndParseNumbers<int>("-1234", RegExHelper.SignedIntegerPattern, out output);

            result.Should().BeTrue();
            output.Should().Be(-1234);
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_PositiveIntegerString_Should_Return_True_Parsed_PositiveInteger()
        {
            int output;
            var result = RegExHelper.ValidateAndParseNumbers<int>("1234", RegExHelper.SignedIntegerPattern, out output);

            result.Should().BeTrue();
            output.Should().Be(1234);
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_DecimalString_Should_Return_True_Parsed_Decimal()
        {
            decimal output;

            //Here I am verifing if the ValidateAndParseNumbers method will work with decimal numbers.
            var result = RegExHelper.ValidateAndParseNumbers<decimal>("12345.252", @"^\d", out output);

            result.Should().BeTrue();
        }


        [TestMethod]
        [TestCategory("RegExHelper - Sad Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_String_With_Two_Minus_Sign_Should_Return_False()
        {
            int output;
            var result = RegExHelper.ValidateAndParseNumbers<int>("-1-234", RegExHelper.SignedIntegerPattern, out output);

            result.Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Sad Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_String_With_Plus_Sign_Should_Return_False()
        {
            int output;
            var result = RegExHelper.ValidateAndParseNumbers<int>("+1234", RegExHelper.SignedIntegerPattern, out output);

            result.Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Sad Path - ValidateAndParseNumbers")]
        public void When_Validating_And_Parsing_AlphaNumeric_String_Should_Return_False()
        {
            int output;
            var result = RegExHelper.ValidateAndParseNumbers<int>("-1234-Abc+123", RegExHelper.SignedIntegerPattern, out output);

            result.Should().BeFalse();
        }
        #endregion

        #region Test related to ValidateOperator
        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateOperator")]
        public void When_Validating_Operator_Plus_Return_True()
        {
            var result = RegExHelper.ValidateOperator("+");
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateOperator")]
        public void When_Validating_Operator_Minus_Return_True()
        {
            var result = RegExHelper.ValidateOperator("-");
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateOperator")]
        public void When_Validating_Operator_Divide_Return_True()
        {
            var result = RegExHelper.ValidateOperator("/");
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateOperator")]
        public void When_Validating_Operator_Multiply_Return_True()
        {
            var result = RegExHelper.ValidateOperator("*");
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Happy Path - ValidateOperator")]
        public void When_Validating_Operator_Mod_Return_True()
        {
            var result = RegExHelper.ValidateOperator("%");
            result.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Sad Path - ValidateOperator")]
        public void When_Validating_Operator_Dollar_Return_False()
        {
            var result = RegExHelper.ValidateOperator("$");
            result.Should().BeFalse();
        }

        [TestMethod]
        [TestCategory("RegExHelper - Sad Path - ValidateOperator")]
        public void When_Validating_Operator_Two_Plus_Return_False()
        {
            var result = RegExHelper.ValidateOperator("+ +");
            result.Should().BeFalse();
        }

        #endregion
    }
}

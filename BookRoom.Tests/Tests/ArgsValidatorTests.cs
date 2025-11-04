using BookRoom.Logics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Tests.Tests
{
    [TestFixture]
    public class ArgsValidatorTests
    {
        private static ArgsTestCase emptyArguments = new() { 
            Arguments = new string[0], 
            Message = ArgsValidator.NotValidErrorMessage 
        };

        private static ArgsTestCase singleBookingArgument = new() { 
            Arguments = new string[] { ArgsValidator.BookingsArg }, 
            Message = ArgsValidator.NotValidErrorMessage 
        };

        private static ArgsTestCase singleHotelsArgument = new()
        {
            Arguments = new string[] { ArgsValidator.HotelsArg },
            Message = ArgsValidator.NotValidErrorMessage
        };

        private static ArgsTestCase notEnoughArguments = new()
        {
            Arguments = new string[] { ArgsValidator.BookingsArg, ArgsValidator.HotelsArg, "somestr" },
            Message = ArgsValidator.NotValidErrorMessage
        };

        private static ArgsTestCase invalidArgumentOrder = new ()
        {
            Arguments = new string[] { ArgsValidator.BookingsArg, ArgsValidator.HotelsArg, "hoo.json", "somestr.json" },
            Message = ArgsValidator.NotValidFilesExtensionMessage
        };


        private static ArgsTestCase[] NotEnoughtArgs = new[]
        {
            emptyArguments,
            singleBookingArgument,
            singleHotelsArgument,
            notEnoughArguments,
            invalidArgumentOrder
        };

        [Test]
        [TestCaseSource(nameof(NotEnoughtArgs))]
        public void TryParse_WithNotEnoughtArgs_ShouldReturnFalse(ArgsTestCase testCase)
        {
            bool isSuccess = ArgsValidator.TryParse(testCase.Arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.False);
            Assert.That(errorMessage, Is.EqualTo(testCase.Message));
        }
    }
}

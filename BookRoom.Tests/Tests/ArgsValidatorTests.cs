using BookRoom.Logics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        private static ArgsTestCase emptyArguments = new()
        {
            Arguments = new string[0],
            Message = ArgsValidator.NotValidErrorMessage
        };

        private static ArgsTestCase singleBookingArgument = new()
        {
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

        private static ArgsTestCase invalidArgumentOrder = new()
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



        private static ArgsTestCase[] InvalidExtensionFiles = new[]
        {
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsValidator.BookingsArg, "hoo.exe", ArgsValidator.HotelsArg, "somestr.sql" },
                Message = ArgsValidator.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsValidator.BookingsArg, "hoo.json", ArgsValidator.HotelsArg, "somestr.sql" },
                Message = ArgsValidator.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsValidator.BookingsArg, "hoo.sql", ArgsValidator.HotelsArg, "somestr.json" },
                Message = ArgsValidator.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsValidator.HotelsArg, "somestr.json", ArgsValidator.BookingsArg, "hoo.sql" },
                Message = ArgsValidator.NotValidFilesExtensionMessage
            }
        };

        [Test]
        [TestCaseSource(nameof(InvalidExtensionFiles))]
        public void TryParse_WithInvalidExtensionFiles_ShouldReturnFalse(ArgsTestCase testCase)
        {
            bool isSuccess = ArgsValidator.TryParse(testCase.Arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.False);
            Assert.That(errorMessage, Is.EqualTo(testCase.Message));
        }

        private static string[][] ValidParameters = new[]
        {
            new string[] { ArgsValidator.BookingsArg, "hoo.json", ArgsValidator.HotelsArg, "somestr.json" },
            new string[] { ArgsValidator.HotelsArg, "somestr.json", ArgsValidator.BookingsArg, "hoo.json" }
        };

        [Test]
        [TestCaseSource(nameof(ValidParameters))]
        public void TryParse_WithValidParameters_ShouldReturnTrue(string[] arguments)
        {
            bool isSuccess = ArgsValidator.TryParse(arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.True);
            Assert.That(errorMessage, Is.Empty);
        }
    }
}

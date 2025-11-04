using BookRoom.Logics;
using NUnit.Framework;

namespace BookRoom.Tests.Tests
{
    [TestFixture]
    public class ArgsValidatorTests
    {
        private static ArgsTestCase emptyArguments = new()
        {
            Arguments = new string[0],
            Message = ArgsParser.NotValidErrorMessage
        };

        private static ArgsTestCase singleBookingArgument = new()
        {
            Arguments = new string[] { ArgsParser.BookingsArg },
            Message = ArgsParser.NotValidErrorMessage
        };

        private static ArgsTestCase singleHotelsArgument = new()
        {
            Arguments = new string[] { ArgsParser.HotelsArg },
            Message = ArgsParser.NotValidErrorMessage
        };

        private static ArgsTestCase notEnoughArguments = new()
        {
            Arguments = new string[] { ArgsParser.BookingsArg, ArgsParser.HotelsArg, "somestr" },
            Message = ArgsParser.NotValidErrorMessage
        };

        private static ArgsTestCase invalidArgumentOrder = new()
        {
            Arguments = new string[] { ArgsParser.BookingsArg, ArgsParser.HotelsArg, "hoo.json", "somestr.json" },
            Message = ArgsParser.NotValidFilesExtensionMessage
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
            bool isSuccess = ArgsParser.TryParse(testCase.Arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.False);
            Assert.That(errorMessage, Is.EqualTo(testCase.Message));
        }



        private static ArgsTestCase[] InvalidExtensionFiles = new[]
        {
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsParser.BookingsArg, "hoo.exe", ArgsParser.HotelsArg, "somestr.sql" },
                Message = ArgsParser.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsParser.BookingsArg, "hoo.json", ArgsParser.HotelsArg, "somestr.sql" },
                Message = ArgsParser.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsParser.BookingsArg, "hoo.sql", ArgsParser.HotelsArg, "somestr.json" },
                Message = ArgsParser.NotValidFilesExtensionMessage
            },
            new ArgsTestCase()
            {
                Arguments = new string[] { ArgsParser.HotelsArg, "somestr.json", ArgsParser.BookingsArg, "hoo.sql" },
                Message = ArgsParser.NotValidFilesExtensionMessage
            }
        };

        [Test]
        [TestCaseSource(nameof(InvalidExtensionFiles))]
        public void TryParse_WithInvalidExtensionFiles_ShouldReturnFalse(ArgsTestCase testCase)
        {
            bool isSuccess = ArgsParser.TryParse(testCase.Arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.False);
            Assert.That(errorMessage, Is.EqualTo(testCase.Message));
        }

        private static string[][] ValidParameters = new[]
        {
            new string[] { ArgsParser.BookingsArg, "hoo.json", ArgsParser.HotelsArg, "somestr.json" },
            new string[] { ArgsParser.HotelsArg, "somestr.json", ArgsParser.BookingsArg, "hoo.json" }
        };

        [Test]
        [TestCaseSource(nameof(ValidParameters))]
        public void TryParse_WithValidParameters_ShouldReturnTrue(string[] arguments)
        {
            bool isSuccess = ArgsParser.TryParse(arguments, out var hotelFilePath, out var bookingFilePath, out var errorMessage);
            Assert.That(isSuccess, Is.True);
            Assert.That(errorMessage, Is.Empty);
        }
    }
}

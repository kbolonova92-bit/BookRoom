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
        string[] emptyArguments = new string[0];
        string[] singleBookingArgument = new string[] { ArgsValidator.BookingsArg };
        string[] singleHotelsArgument = new string[] { ArgsValidator.HotelsArg };
        string[] notEnoughArguments = new string[] { ArgsValidator.BookingsArg, ArgsValidator.HotelsArg, "somestr" };

        [Test]
        [TestCaseSource(nameof(emptyArguments))]
        [TestCaseSource(nameof(singleBookingArgument))]
        [TestCaseSource(nameof(singleHotelsArgument))]
        [TestCaseSource(nameof(notEnoughArguments))]
        public void TryParse_WithNotEnoughtArgs_ShouldReturnFalse(string[] arguments)
        {
            Assert.Fail();
        }
    }
}

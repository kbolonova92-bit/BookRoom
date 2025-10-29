using BookRoom.Logics;
using BookRoom.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        private FileReader<Booking> _bookingReader = new();
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("  ")]
        public void ReadFromJson_EmptyData_ShouldThrowException(string filePath)
        {
            Assert.Throws<ArgumentNullException>(() => { _bookingReader.ReadFromJson(filePath); });
        }

        [Test]
        public void ReadFromJson_File_ShouldReturnSingleObject()
        {
            Assert.Fail();
        }
    }
}

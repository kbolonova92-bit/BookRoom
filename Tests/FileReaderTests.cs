using BookRoom.Logics;
using BookRoom.Models;
using Moq;
using NUnit.Framework;

namespace BookRoom.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        private FileParser<Booking> _bookingReader;

        [SetUp]
        public void Setup()
        {
            var mockReader = new Mock<IFileReader>();
            _bookingReader = new(mockReader.Object);
        }

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
            string filePath = "test.json";
            var mockReader = new Mock<IFileReader>();
            mockReader
                .Setup(r => r.ReadFile(filePath))
                .Returns(BookingServiceTestData.SingleBooking);

            FileParser<Booking> bookingReader = new(mockReader.Object);

            var result = bookingReader.ReadFromJson(filePath);
            Assert.Fail();
        }
    }
}

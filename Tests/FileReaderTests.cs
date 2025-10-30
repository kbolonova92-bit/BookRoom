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
        private Mock<IFileReader> _fileReaderMock;

        [SetUp]
        public void Setup()
        {
            var mockReader = new Mock<IFileReader>();
            _bookingReader = new(mockReader.Object);

            _fileReaderMock = new Mock<IFileReader>();
            _fileReaderMock
                .Setup(r => r.FileExists(It.IsAny<string>()))
                .Returns(true);
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
            _fileReaderMock
                .Setup(r => r.ReadFile(It.IsAny<string>()))
                .Returns(BookingServiceTestData.SingleBooking);
            
            FileParser<Booking> bookingReader = new(_fileReaderMock.Object);

            var result = bookingReader.ReadFromJson("test.json");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].HotelId, Is.EqualTo("H1"));
            Assert.That(result[0].RoomType, Is.EqualTo("DBL"));
            Assert.That(result[0].RoomRate, Is.Not.Empty);
        }

        [Test]
        public void ReadFromJson_File_ShouldReturnMultipleObjects()
        {
            Assert.Fail();
        }
    }
}

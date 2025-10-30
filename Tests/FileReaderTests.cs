using BookRoom.Logics;
using BookRoom.Models;
using Moq;
using NUnit.Framework;

namespace BookRoom.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        private FileParser _bookingReader;
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
            Assert.Throws<ArgumentNullException>(() => { _bookingReader.ReadFromJson<Booking>(filePath); });
        }

        [Test]
        public void ReadFromJson_File_ShouldReturnSingleObject()
        {
            _fileReaderMock
                .Setup(r => r.ReadFile(It.IsAny<string>()))
                .Returns(BookingServiceTestData.SingleBooking);
            
            FileParser bookingReader = new(_fileReaderMock.Object);

            var result = bookingReader.ReadFromJson<Booking>("test.json");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().HotelId, Is.EqualTo("H1"));
            Assert.That(result.First().RoomType, Is.EqualTo("DBL"));
            Assert.That(result.First().RoomRate, Is.Not.Empty);
            Assert.That(result.First().Arrival, Is.EqualTo(new DateTime(2024, 09, 01)));
            Assert.That(result.First().Departure, Is.EqualTo(new DateTime(2024, 09, 03)));
        }

        [Test]
        public void ReadFromJson_File_ShouldReturnMultipleObjects()
        {
            _fileReaderMock
                .Setup(r => r.ReadFile(It.IsAny<string>()))
                .Returns(BookingServiceTestData.Bookings);

            FileParser bookingReader = new(_fileReaderMock.Object);

            var result = bookingReader.ReadFromJson<Booking>("test.json");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(5));

            Assert.That(result.First().HotelId, Is.EqualTo("H1"));
            Assert.That(result.First().RoomType, Is.EqualTo("DBL"));
            Assert.That(result.First().RoomRate, Is.Not.Empty);
            Assert.That(result.First().Arrival, Is.EqualTo(new DateTime(2024, 09, 01)));
            Assert.That(result.First().Departure, Is.EqualTo(new DateTime(2024, 09, 03)));

            Assert.That(result.Last().HotelId, Is.EqualTo("F1"));
            Assert.That(result.Last().RoomType, Is.EqualTo("Some"));
            Assert.That(result.Last().Arrival, Is.EqualTo(new DateTime(2024, 09, 02)));
            Assert.That(result.Last().Departure, Is.EqualTo(new DateTime(2024, 09, 05)));

        }
    }
}

using BookRoom.Logics;
using BookRoom.Models;
using NUnit.Framework;
using System.Text.Json;

namespace BookRoom.Tests
{
    [TestFixture]
    public class BookingServiceTests
    {
        private BookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            _bookingService = new BookingService(
                JsonSerializer.Deserialize<List<Hotel>>(BookingServiceTestData.Hotels),
                JsonSerializer.Deserialize<List<Booking>>(BookingServiceTestData.Bookings)
                );
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("qw", null)]
        [TestCase("qw", "")]
        [TestCase(null, "qw")]
        [TestCase("", "qw")]
        public async Task CheckAvailability_EmptyData_ThrowsException(string hotelId, string RoomTypeCode)
        {
            Assert.Throws<ArgumentNullException>(() => { _bookingService.CheckAvailability(hotelId, DateTime.Now, RoomTypeCode); });
        }


        ///Availability(H1, 20240901, SGL)
        ///Availability(H1, 20240901-20240903, DBL)
        ///

        [Test]
        public async Task CheckAvailability_SingleDate_ReturnsError()
        {
            Assert.Fail();
        }
    }
}

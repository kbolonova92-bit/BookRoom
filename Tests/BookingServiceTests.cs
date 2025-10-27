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

        public void Setup()
        {
            _bookingService = new BookingService(
                JsonSerializer.Deserialize<List<Hotel>>(BookingServiceTestData.Hotels),
                JsonSerializer.Deserialize<List<Booking>>(BookingServiceTestData.Bookings)
                );
        }

        [Test]
        [TestCase(null, null, null)]
        public async Task CheckAvailability_EmptyData_ReturnsError(string hotelId, DateTime date, string RoomTypeCode)
        {
            _bookingService.CheckAvailability(hotelId, date, RoomTypeCode);
            Assert.Fail();
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

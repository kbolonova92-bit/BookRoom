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
        private const string SomeDate = "2025-01-01";
        private const string ExistingHotelId = "H1";
        private const string NotExistingHotelId = "Bla-bla";
        private const string ExistingRoomType = "SGL";
        private const string NotExistingRoomType = "Bla-Bla";
        

        [SetUp]
        public void Setup()
        {
            var hotelHash = JsonSerializer.Deserialize<List<Hotel>>(BookingServiceTestData.Hotels)
                .ToDictionary(x => x.Id);

            _bookingService = new BookingService(
                hotelHash,
                JsonSerializer.Deserialize<List<Booking>>(BookingServiceTestData.Bookings)
                );
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase(NotExistingHotelId, null)]
        [TestCase(NotExistingHotelId, "")]
        [TestCase(null, NotExistingRoomType)]
        [TestCase("", NotExistingRoomType)]
        [TestCase(NotExistingHotelId, " ")]
        [TestCase(" ", NotExistingRoomType)]
        public async Task CheckAvailability_EmptyData_ThrowsException(string hotelId, string RoomTypeCode)
        {
            Assert.Throws<ArgumentNullException>(() => { _bookingService.CheckAvailability(hotelId, DateTime.Now, RoomTypeCode); });
        }

        [Test]
        [TestCase(NotExistingHotelId, SomeDate, ExistingRoomType)]
        public async Task CheckAvailability_DataIsMissing_ThrowsKeyNotFoundException(string hotelId, DateTime date, string RoomTypeCode)
        {
            Assert.Throws<KeyNotFoundException>(() => { _bookingService.CheckAvailability(hotelId, date, RoomTypeCode); });
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

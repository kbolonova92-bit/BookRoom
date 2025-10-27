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
        private const string SingleRoomHotelId = "J1";
        private const string SingleRoomHotelRoomType = "Vip";

        private const string СrowdedHotelId = "F1";
        private const string CrowdedRoomType = "Some";


        [SetUp]
        public void Setup()
        {
            var hotelHash = JsonSerializer.Deserialize<List<Hotel>>(BookingServiceTestData.Hotels)
                .ToDictionary(x => x.Id);
            var bookingHash = JsonSerializer.Deserialize<List<Booking>>(BookingServiceTestData.Bookings).GroupBy(x => x.HotelId)
                .ToDictionary(x => x.Key,
                              x => x.ToList());

            _bookingService = new BookingService(
                hotelHash,
                bookingHash
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
            Assert.Throws<ArgumentNullException>(() => { _bookingService.CheckAvailability(hotelId, RoomTypeCode, DateTime.Now); });
        }

        [Test]
        [TestCase(NotExistingHotelId, SomeDate, ExistingRoomType)]
        [TestCase(ExistingHotelId, SomeDate, NotExistingRoomType)]
        public async Task CheckAvailability_DataIsMissing_ThrowsKeyNotFoundException(string hotelId, DateTime date, string RoomTypeCode)
        {
            Assert.Throws<KeyNotFoundException>(() => { _bookingService.CheckAvailability(hotelId, RoomTypeCode, date); });
        }


        ///Availability(H1, 20240901, SGL)
        ///Availability(H1, 20240901-20240903, DBL)
        ///

        [Test]
        [TestCase(SingleRoomHotelId, "2024-01-01", SingleRoomHotelRoomType,1)]
        [TestCase(ExistingHotelId, "2024-09-02", ExistingRoomType, 1)]
        [TestCase(ExistingHotelId, "2024-09-03", ExistingRoomType, 1)]
        [TestCase(ExistingHotelId, "2024-09-05", ExistingRoomType, 2)]
        [TestCase(ExistingHotelId, "2024-09-10", ExistingRoomType, 2)]
        [TestCase(СrowdedHotelId, "2024-09-02", CrowdedRoomType, -1)]
        public async Task CheckAvailability_SingleDate_ReturnsAvailableRoomsAmount(string hotelId, DateTime date, string RoomTypeCode, int roomsAmount)
        {
            var result = _bookingService.CheckAvailability(hotelId, RoomTypeCode, date);
            Assert.That(result, Is.EqualTo(roomsAmount));
        }
    }
}

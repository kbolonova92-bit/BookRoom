using BookRoom.Logics;
using BookRoom.Models;
using NUnit.Framework;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private const string CrowdedHotelId = "F1";
        private const string CrowdedRoomType = "Some";

        private readonly DateTime fakeToday = new DateTime(2024, 09, 01);


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
        public async Task CheckAvailability_EmptyData_ShouldThrowException(string hotelId, string roomTypeCode)
        {
            Assert.Throws<ArgumentNullException>(() => { _bookingService.CheckAvailability(hotelId, roomTypeCode, DateTime.Now); });
        }

        [Test]
        [TestCase(NotExistingHotelId, SomeDate, ExistingRoomType)]
        [TestCase(ExistingHotelId, SomeDate, NotExistingRoomType)]
        public async Task CheckAvailability_DataIsMissing_ShouldThrowKeyNotFoundException(string hotelId, DateTime date, string roomTypeCode)
        {
            Assert.Throws<KeyNotFoundException>(() => { _bookingService.CheckAvailability(hotelId, roomTypeCode, date); });
        }

        [Test]
        [TestCase(SingleRoomHotelId, "2024-01-01", SingleRoomHotelRoomType,1)]
        [TestCase(ExistingHotelId, "2024-09-02", ExistingRoomType, 1)]
        [TestCase(ExistingHotelId, "2024-09-03", ExistingRoomType, 1)]
        [TestCase(ExistingHotelId, "2024-09-05", ExistingRoomType, 2)]
        [TestCase(ExistingHotelId, "2024-09-10", ExistingRoomType, 2)]
        [TestCase(CrowdedHotelId, "2024-09-02", CrowdedRoomType, -1)]
        public async Task CheckAvailability_SingleDate_ShouldReturnAvailableRoomsAmount(string hotelId, DateTime date, string roomTypeCode, int roomsAmount)
        {
            var result = _bookingService.CheckAvailability(hotelId, roomTypeCode, date);
            Assert.That(result, Is.EqualTo(roomsAmount));
        }

        [Test]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-01", "2024-09-03", 1)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-02", "2024-09-03", 1)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-03", "2024-09-05", 1)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-04", "2024-09-05", 1)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-04", "2024-09-06", 1)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-05", "2024-09-10", 2)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-09-06", "2024-09-07", 2)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-10-01", "2024-11-01", 2)]
        [TestCase(ExistingHotelId, ExistingRoomType, "2024-10-01", "2024-09-01", 1)]
        [TestCase(CrowdedHotelId, CrowdedRoomType, "2024-10-01", "2024-09-01", -1)]

        public async Task CheckAvailability_ArrivalDepartureDates_ShouldReturnAvailableRoomsAmount(string hotelId, string RoomTypeCode, DateTime arrival, DateTime departure, int roomsAmount)
        {
            var result = _bookingService.CheckAvailability(hotelId, RoomTypeCode, arrival, departure);
            Assert.That(result, Is.EqualTo(roomsAmount));
        }

        //Search(H1, 365, SGL) 


        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase(NotExistingHotelId, null)]
        [TestCase(NotExistingHotelId, "")]
        [TestCase(null, NotExistingRoomType)]
        [TestCase("", NotExistingRoomType)]
        [TestCase(NotExistingHotelId, " ")]
        [TestCase(" ", NotExistingRoomType)]
        public async Task Search_EmptyData_ShouldThrowException(string hotelId, string roomTypeCode)
        {
            Assert.Throws<ArgumentNullException>(() => { _bookingService.Search(fakeToday, hotelId, 3, roomTypeCode); });
        }

        [Test]
        [TestCase(NotExistingHotelId, ExistingRoomType)]
        [TestCase(ExistingHotelId, NotExistingRoomType)]
        public async Task Search_MissingData_ShouldThrowException(string hotelId, string roomTypeCode)
        {
            Assert.Throws<KeyNotFoundException>(() => { _bookingService.Search(fakeToday, hotelId, 3, roomTypeCode); });
        }

        [Test]
        public async Task Search_RightData_ShouldReturnAvailabilitySlot()
        {
            Assert.Fail();
        }
    }
}

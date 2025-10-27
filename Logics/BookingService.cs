using BookRoom.Models;

namespace BookRoom.Logics
{
    public class BookingService
    {
        private Dictionary<string,Hotel> _hotels;
        private Dictionary<string, List<Booking>> _bookings;
        public BookingService(Dictionary<string, Hotel> hotels, Dictionary<string, List<Booking>> bookings) 
        {
            _hotels = hotels;
            _bookings = bookings;
        }

        public int CheckAvailability(string hotelId, string roomTypeCode, DateTime date, DateTime? departureDate = null)
        {
            if (string.IsNullOrWhiteSpace(hotelId)) throw new ArgumentNullException("Hotel Id is not correct.");
            if (string.IsNullOrWhiteSpace(roomTypeCode)) throw new ArgumentNullException("Room type is not correct.");
            if (!_hotels.ContainsKey(hotelId)) throw new KeyNotFoundException($"Hotel with Id {hotelId} is missing.");
            if (!_hotels[hotelId].RoomTypeExists(roomTypeCode)) throw new KeyNotFoundException($"Room Type with {roomTypeCode} is missing in Hotel {hotelId}.");

            int hotelWholeAvailability = _hotels[hotelId].Rooms.Count(x => x.RoomType == roomTypeCode);

            if (!_bookings.ContainsKey(hotelId)) return hotelWholeAvailability;



            int bookedRooms = _bookings[hotelId].Count(x => x.RoomType == roomTypeCode && x.Arrival <= date && x.Departure > date);

            return hotelWholeAvailability - bookedRooms;
        }

        public string Search()
        {
            return null;
        }

    }
}

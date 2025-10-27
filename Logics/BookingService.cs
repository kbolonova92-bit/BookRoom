using BookRoom.Models;

namespace BookRoom.Logics
{
    public class BookingService
    {
        private Dictionary<string,Hotel> _hotels;
        private List<Booking> _bookings;
        public BookingService(Dictionary<string, Hotel> hotels, List<Booking> bookings) 
        {
            _hotels = hotels;
            _bookings = bookings;
        }

        public int CheckAvailability(string hotelId, DateTime date, string roomTypeCode)
        {
            if (string.IsNullOrWhiteSpace(hotelId)) throw new ArgumentNullException("Hotel Id is not correct.");
            if (string.IsNullOrWhiteSpace(roomTypeCode)) throw new ArgumentNullException("Room type is not correct.");
            if (!_hotels.ContainsKey(hotelId)) throw new KeyNotFoundException($"Hotel with Id {hotelId} is missing.");
            

            return default;
        }

        public string Search()
        {
            return null;
        }

    }
}

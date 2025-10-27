using BookRoom.Models;

namespace BookRoom.Logics
{
    public class BookingService
    {
        private List<Hotel> _hotels;
        private List<Booking> _bookings;
        public BookingService(List<Hotel> hotels, List<Booking> bookings) 
        {
            _hotels = hotels;
            _bookings = bookings;
        }

        public string CheckAvailability(string hotelId, DateTime date, string roomTypeCode)
        {
            if (string.IsNullOrWhiteSpace(hotelId)) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(roomTypeCode)) throw new ArgumentNullException();

            

            return null;
        }

        public string Search()
        {
            return null;
        }

    }
}

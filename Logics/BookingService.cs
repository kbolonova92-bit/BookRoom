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

        public string Availability()
        {
            return null;
        }

        public string Search()
        {
            return null;
        }

    }
}

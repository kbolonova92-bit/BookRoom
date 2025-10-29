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

        public int CheckAvailability(string hotelId, string roomTypeCode, DateTime arrival, DateTime? departure = null)
        {
            if (string.IsNullOrWhiteSpace(hotelId)) throw new ArgumentNullException("Hotel Id is not correct.");
            if (string.IsNullOrWhiteSpace(roomTypeCode)) throw new ArgumentNullException("Room type is not correct.");
            if (!_hotels.ContainsKey(hotelId)) throw new KeyNotFoundException($"Hotel with Id {hotelId} is missing.");
            if (!_hotels[hotelId].RoomTypeExists(roomTypeCode)) throw new KeyNotFoundException($"Room Type with {roomTypeCode} is missing in Hotel {hotelId}.");

            int hotelWholeAvailability = _hotels[hotelId].Rooms.Count(x => x.RoomType == roomTypeCode);

            if (!_bookings.ContainsKey(hotelId)) return hotelWholeAvailability;

            int bookedRooms = default;

            if (departure.HasValue && arrival > departure)
            {
                var arrivalCopy = arrival;
                arrival = departure.Value;
                departure = arrivalCopy;
            }

            if (!departure.HasValue)
            {
                bookedRooms = _bookings[hotelId]
                                    .Where(x => x.RoomType == roomTypeCode)
                                    .Count(x => x.Arrival <= arrival && x.Departure > arrival);
            }
            else
            {
                bookedRooms = _bookings[hotelId]
                    .Where(x => x.RoomType == roomTypeCode)
                    .Count(x => (arrival >= x.Arrival && arrival < x.Departure) || (departure > x.Arrival && departure < x.Departure)
                             || (x.Arrival >= arrival && x.Arrival < departure) || ((x.Departure > arrival && x.Departure < departure)));
            }

            return hotelWholeAvailability - bookedRooms;
        }

        //Search(H1, 365, SGL) 
        public AvailabilitySlot Search(DateTime today, string hotelId, int daysAhead, string roomTypeCode)
        {
            return null;
        }

    }
}

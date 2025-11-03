namespace BookRoom.Models
{
    public class AvailabilityParams
    {
        public string HotelId {  get; set; }
        public string RoomTypeCode { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime? Departure { get; set; }
    }
}

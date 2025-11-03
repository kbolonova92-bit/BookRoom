namespace BookRoom.Models
{
    public class AvailabilityParams
    {
        public required string HotelId {  get; set; }
        public required string RoomTypeCode { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime? Departure { get; set; }
    }
}

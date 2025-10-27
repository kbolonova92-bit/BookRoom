using System.Text.Json.Serialization;

namespace BookRoom.Models
{
    public class Booking
    {
        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("arrival")]
        public string Arrival { get; set; }

        public DateTime ArrivalDate { get; private set; }

        [JsonPropertyName("departure")]
        public string Departure { get; set; }

        public DateTime DepartureDate { get; private set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("roomRate")]
        public string RoomRate { get; set; }
    }
}

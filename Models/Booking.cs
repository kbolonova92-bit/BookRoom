using BookRoom.Common;
using System.Text.Json.Serialization;

namespace BookRoom.Models
{
    public class Booking
    {
        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("arrival")]
        [JsonConverter(typeof(DateOnlyConverterYYYYMMDD))]
        public DateTime Arrival { get; set; }

        [JsonPropertyName("departure")]

        [JsonConverter(typeof(DateOnlyConverterYYYYMMDD))]
        public DateTime Departure { get; set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("roomRate")]
        public string RoomRate { get; set; }
    }
}

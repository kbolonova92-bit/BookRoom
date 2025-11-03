namespace BookRoom.Tests.Tests
{
    public static class BookingServiceTestData
    {
        public static string Bookings = @"[ 

    { 
        ""hotelId"": ""H1"", 
        ""arrival"": ""20240901"", 
        ""departure"": ""20240903"", 
        ""roomType"": ""DBL"", 
        ""roomRate"": ""Prepaid"" 
    },
    { 
        ""hotelId"": ""H1"", 
        ""arrival"": ""20240902"", 
        ""departure"": ""20240905"", 
        ""roomType"": ""SGL"", 
        ""roomRate"": ""Standard"" 
    },
    { 
        ""hotelId"": ""H1"", 
        ""arrival"": ""20241102"", 
        ""departure"": ""20241105"", 
        ""roomType"": ""SGL"", 
        ""roomRate"": ""Standard"" 
    },
    { 
        ""hotelId"": ""F1"", 
        ""arrival"": ""20240902"", 
        ""departure"": ""20240905"", 
        ""roomType"": ""Some"", 
        ""roomRate"": ""Standard"" 
    }, 
    { 
        ""hotelId"": ""F1"", 
        ""arrival"": ""20240902"", 
        ""departure"": ""20240905"", 
        ""roomType"": ""Some"", 
        ""roomRate"": ""Standard"" 
    }
        ] ";

        public static string SingleBooking = @"[
{ 
        ""hotelId"": ""H1"", 
        ""arrival"": ""20240901"", 
        ""departure"": ""20240903"", 
        ""roomType"": ""DBL"", 
        ""roomRate"": ""Prepaid"" 
    }
]";


        public static string Hotels = @"[ 
    { 
        ""id"": ""H1"", 
        ""name"": ""Hotel California"", 
        ""roomTypes"": [ 
            { 
                ""code"": ""SGL"", 
                ""description"": ""Single Room"", 
                ""amenities"": [""WiFi"", ""TV""], 
                ""features"": [""Non-smoking""] 
            }, 
            { 
                ""code"": ""DBL"", 
                ""description"": ""Double Room"", 
                ""amenities"": [""WiFi"", ""TV"", ""Minibar""], 
                ""features"": [""Non-smoking"", ""Sea View""] 
            } 
        ], 
        ""rooms"": [ 
            { 
                ""roomType"": ""SGL"", 
                ""roomId"": ""101"" 
            }, 
            { 
                ""roomType"": ""SGL"", 
                ""roomId"": ""102"" 
            },
            {
                ""roomType"": ""DBL"", 
                ""roomId"": ""201"" 
            }, 
            { 
                ""roomType"": ""DBL"", 
                ""roomId"": ""202"" 
            } 
        ] 
    },
    {
        ""id"": ""J1"",
        ""name"": ""Hotel Jumanji"",
        ""roomTypes"": [
{ 
                ""code"": ""Vip"", 
                ""description"": ""Vip Room"", 
                ""amenities"": [""WiFi"", ""TV""], 
                ""features"": [""Non-smoking""] 
            }
        ],
        ""rooms"": [
            { 
                ""roomType"": ""Vip"", 
                ""roomId"": ""007"" 
            }
            ]
    },
    {
        ""id"": ""F1"",
        ""name"": ""Hotel FullHouse"",
        ""roomTypes"": [
            { 
                ""code"": ""Some"", 
                ""description"": ""Some Room"", 
                ""amenities"": [""WiFi"", ""TV""], 
                ""features"": [""Non-smoking""] 
            }
        ],
        ""rooms"": [
            { 
                ""roomType"": ""Some"", 
                ""roomId"": ""001"" 
            }
            ]
    }
    ]";

    }
}

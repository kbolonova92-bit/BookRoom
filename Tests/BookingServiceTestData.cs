namespace BookRoom.Tests
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

    } 

] ";
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

    } 

] ";
    }
}

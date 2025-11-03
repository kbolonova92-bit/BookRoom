using BookRoom.Models;
using System.Globalization;

namespace BookRoom.Logics
{
    public static class CommandParser
    {
        public static bool IsSearchCommand(this string command) => command.StartsWith("Search(");

        public static bool IsAvailabilityCommand(this string command) => command.StartsWith("Availability(");

        public static SearchParams ParseSearchCommand(this string command)
        {
            
            var parameters = command.Replace("Search(", string.Empty).Replace(")", string.Empty).Split(",");

            int.TryParse(parameters[1], out var daysAhead);

            SearchParams result = new()
            {
                HotelId = parameters[0],
                DaysAhead = daysAhead,
                RoomType = parameters[2]
            };

            return result;
        }

        public static AvailabilityParams ParseAvailabilityCommand(this string command)
        {
            var parameters = command.Replace("Availability(", string.Empty).Replace(")", string.Empty).Split(",");
            string hotelId = parameters[0];
            string dates = parameters[1];
            string roomType = parameters[2];
            DateTime arrival = DateTime.Now;
            DateTime? departure = null;

            const string dateSeparator = "-";
            if (!dates.Contains(dateSeparator)) DateTime.TryParseExact(dates, GeneralSettings.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out arrival);
            else
            {
                var separatedDates = dates.Split(dateSeparator);
                DateTime.TryParseExact(separatedDates[0], GeneralSettings.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out arrival);
                if (DateTime.TryParseExact(separatedDates[1], GeneralSettings.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
                    departure = d;
            }

            return new()
            {
                HotelId = hotelId,
                Arrival = arrival,
                Departure = departure,
                RoomTypeCode = roomType,
            };

        }
    }
}

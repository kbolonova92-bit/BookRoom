using BookRoom.Models;
using System.Globalization;

namespace BookRoom.Logics
{
    public class Command
    {
        const string ExitCommand = "";
        public BookingService _bookingService;
        public string _input;
        public Command(BookingService service, string input) 
        {
            _input = input.Replace(" ", string.Empty);
            _bookingService = service;
        }

        public string Execute()
        {
            return _input switch
            {
                var _ when IsExit() => ExitCommand,
                var _ when IsSearchCommand() => ExecuteSafely(() => ExecuteSearch()),
                var _ when IsAvailabilityCommand() => ExecuteSafely(() => ExecuteAvailability()),
                _ => "Unknown command."
            };
        }

        private string ExecuteSearch()
        {
            var parameters = this.ParseSearchCommand();
            var avaliableSlots = _bookingService.Search(DateTime.Now, parameters.HotelId, parameters.DaysAhead, parameters.RoomType);
            return String.Join(",", avaliableSlots.Select(x => x.ToString()));
        }

        private string ExecuteAvailability()
        {
            var parameters = this.ParseAvailabilityCommand();
            var result = _bookingService.CheckAvailability(parameters.HotelId, parameters.RoomTypeCode, parameters.Arrival, parameters.Departure);
            return result.ToString();
        }

        private string ExecuteSafely(Func<string> action)
        {
            try
            {
                return action();
            }
            catch (ArgumentNullException e)
            {
                return e.Message;
            }
            catch (KeyNotFoundException e)
            {
                return e.Message;
            }
        }

        private bool IsSearchCommand() => _input.StartsWith("Search(");

        private SearchParams ParseSearchCommand()
        {
            var parameters = _input.Replace("Search(", string.Empty).Replace(")", string.Empty).Split(",");

            int.TryParse(parameters[1], out var daysAhead);

            SearchParams result = new()
            {
                HotelId = parameters[0],
                DaysAhead = daysAhead,
                RoomType = parameters[2]
            };

            return result;
        }

        private AvailabilityParams ParseAvailabilityCommand()
        {
            var parameters = _input.Replace("Availability(", string.Empty).Replace(")", string.Empty).Split(",");
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

        private bool IsAvailabilityCommand() => _input.StartsWith("Availability(");

        public bool IsExit()
        {
            return _input.Equals(ExitCommand);
        }
    }
}

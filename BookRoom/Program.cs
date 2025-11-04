using BookRoom.Logics;
using BookRoom.Models;

if (!ArgsValidator.TryParse(args, out var hotelsPath, out var bookingsPath, out var errorMesasge)) ExitWithMessage(errorMesasge);



if (hotelsPath is null || bookingsPath is null) ExitWithMessage("Not valid params! Add --hotels <filepath> and --bookings <filepath>.");

BookingService bookingService = new(new(), new());

try
{
    FileParser parser = new(new FileReader());

    var hotelHash = parser.ReadFromJson<Hotel>(string.Concat(Environment.CurrentDirectory, "/", hotelsPath))
                .ToDictionary(x => x.Id);
    var bookingHash = parser.ReadFromJson<Booking>(string.Concat(Environment.CurrentDirectory, "/", bookingsPath))
        .GroupBy(x => x.HotelId)
        .ToDictionary(x => x.Key,
                      x => x.ToList());
    bookingService = new(hotelHash, bookingHash);
}
catch (Exception e)
{
    ExitWithMessage(e.Message);
}

Console.WriteLine("Hello, Input your command:");

string input;
do
{
    input = Console.ReadLine() ?? string.Empty;
    input = input.Replace(" ", string.Empty);
    string result = string.Empty;
    if (input.IsSearchCommand())
    {
        var parameters = input.ParseSearchCommand();
        try
        {
            var avaliableSlots = bookingService.Search(DateTime.Now, parameters.HotelId, parameters.DaysAhead, parameters.RoomType);
            result = String.Join(",", avaliableSlots.Select(x => x.ToString()));
            Console.WriteLine(result);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        continue;
    }
    if (input.IsAvailabilityCommand())
    {
        var parameters = input.ParseAvailabilityCommand();
        
        try
        {
            result = bookingService.CheckAvailability(parameters.HotelId, parameters.RoomTypeCode, parameters.Arrival, parameters.Departure).ToString();
            Console.WriteLine(result);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        continue;
    }
    if (!string.IsNullOrEmpty(input)) Console.WriteLine("Unknown command.");
}
while (input != string.Empty);

static void WriteMessage(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}

static void ExitWithMessage(string message)
{
    WriteMessage(message);
    Environment.Exit(1);
}

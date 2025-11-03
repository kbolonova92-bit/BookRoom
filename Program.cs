using BookRoom.Logics;
using BookRoom.Models;

if (!args.Contains("--hotels") || !args.Contains("--bookings")) ToExit("Not valid params! Add --hotels <filepath> and --bookings <filepath>.");

string hotelsPath = string.Empty;
string bookingsPath = string.Empty;

for (int i = 0; i < args.Length; i++)
{
    switch (args[i])
    {
        case "--hotels":
            if (i + 1 < args.Length)
                hotelsPath = args[i + 1];
            break;

        case "--bookings":
            if (i + 1 < args.Length)
                bookingsPath = args[i + 1];
            break;
    }
}

if (hotelsPath is null || bookingsPath is null) ToExit("Not valid params! Add --hotels <filepath> and --bookings <filepath>.");

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
    ToExit(e.Message);
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

void ToExit(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    Environment.Exit(1);
}

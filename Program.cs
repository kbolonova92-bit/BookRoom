// See https://aka.ms/new-console-template for more information
using BookRoom.Logics;
using BookRoom.Models;
using BookRoom.Tests;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

//myapp --hotels hotels.json --bookings bookings.json

///Availability(H1, 20240901, SGL)
///Availability(H1, 20240901-20240903, DBL)

//Search(H1, 365, SGL) 



if (!args.Contains("--hotels")|| !args.Contains("--bookings")) ToExit("Not valid params! Add --hotels <filepath> and --bookings <filepath>.");

string hotelsPath = null;
string bookingsPath = null;

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

BookingService bookingService = null;

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
    input = Console.ReadLine();
    input = input.Replace(" ", string.Empty);
    string result = string.Empty;
    if (input.StartsWith("Search("))
    {
        var parameters = input.Replace("Search(", string.Empty).Replace(")", string.Empty).Split(",");
        string hotelId = parameters[0];
        int daysAhead = int.Parse(parameters[1]);
        string roomType = parameters[2];
        var avaliableSlots = bookingService.Search(DateTime.Now, hotelId, daysAhead, roomType);
        result = String.Join(",", avaliableSlots.Select(x => x.ToString()));
    }
    if (input.StartsWith("Availability("))
    {
        var parameters = input.Replace("Availability(", string.Empty).Replace(")", string.Empty).Split(",");
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

            result = bookingService.CheckAvailability(hotelId, roomType, arrival, departure).ToString();
    }
    if (!string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Unknown command.");
        continue;
    }
    
    Console.WriteLine(result);
}
while (input != string.Empty);

void ToExit(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    Environment.Exit(1);
}

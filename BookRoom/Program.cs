using BookRoom.Logics;
using BookRoom.Models;

if (!ArgsValidator.TryParse(args, out var hotelsPath, out var bookingsPath, out var errorMesasge)) ExitWithMessage(errorMesasge);

BookingService bookingService = null;

try
{
    bookingService = BookingService.Create(hotelsPath, bookingsPath);
}
catch (Exception e)
{
    ExitWithMessage(e.Message);
}

Console.WriteLine("Hello, Input your command:");

Command command;
do
{
    string input = Console.ReadLine() ?? string.Empty;
    command = new(bookingService, input);
    Console.WriteLine(command.Execute());
    
} while (!command.IsExit());

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

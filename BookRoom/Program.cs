using BookRoom.Logics;

if (!ArgsParser.TryParse(args, out var hotelsPath, out var bookingsPath, out var errorMesasge)) ExitWithMessage(errorMesasge);

BookingService bookingService;

try
{
    bookingService = BookingService.Create(hotelsPath, bookingsPath);
}
catch (Exception e)
{
    ExitWithMessage(e.Message);
    return;
}

Console.WriteLine("Hello, Input your command:");

Command? command = null;
do
{
    try
    {
        string input = Console.ReadLine() ?? string.Empty;
        command = new(bookingService, input);
        Console.WriteLine(command.Execute());
    }
    catch (Exception e)
    {
        Console.WriteLine("Unexpected error.");
    }
} while (!command.IsExit());

static void ExitWithMessage(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    Environment.Exit(1);
}

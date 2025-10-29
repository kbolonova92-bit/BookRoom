// See https://aka.ms/new-console-template for more information
using BookRoom.Logics;
using BookRoom.Models;
using System;
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

try
{

}
catch (Exception e)
{
    ToExit(e.Message);
}

Console.WriteLine("Hello, Input your command:");
var input = Console.ReadLine();
while (input != string.Empty)
{

}


void ToExit(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
    Environment.Exit(1);
}

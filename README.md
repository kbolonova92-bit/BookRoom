## Chalenge description 
🏨 Hotel Room Availability & Reservation Manager
📋 Description

This console application manages hotel room availability and reservations.
It reads data from two JSON files — hotels.json and bookings.json — and allows users to check room availability for a given hotel, date range, and room type.

🚀 Example Command to Run
myapp --hotels hotels.json --bookings bookings.json

🏠 hotels.json Example
```
[
  {
    "id": "H1",
    "name": "Hotel California",
    "roomTypes": [
      {
        "code": "SGL",
        "description": "Single Room",
        "amenities": ["WiFi", "TV"],
        "features": ["Non-smoking"]
      },
      {
        "code": "DBL",
        "description": "Double Room",
        "amenities": ["WiFi", "TV", "Minibar"],
        "features": ["Non-smoking", "Sea View"]
      }
    ],
    "rooms": [
      { "roomType": "SGL", "roomId": "101" },
      { "roomType": "SGL", "roomId": "102" },
      { "roomType": "DBL", "roomId": "201" },
      { "roomType": "DBL", "roomId": "202" }
    ]
  }
]
```


📅 bookings.json Example
```
[
  {
    "hotelId": "H1",
    "arrival": "20240901",
    "departure": "20240903",
    "roomType": "DBL",
    "roomRate": "Prepaid"
  },
  {
    "hotelId": "H1",
    "arrival": "20240902",
    "departure": "20240905",
    "roomType": "SGL",
    "roomRate": "Standard"
  }
]
```

💬 Commands
🔹 Availability Command

Example input:

Availability(H1, 20240901, SGL)
Availability(H1, 20240901-20240903, DBL)


Expected output:
Displays the number of available rooms for the given room type and date range.

Note: Hotels may allow overbookings, so the result can be negative, indicating the hotel is over capacity for that room type.

🔹 Search Command

Example input:

Search(H1, 365, SGL)


Expected output:
A comma-separated list of available date ranges and room counts for the given hotel and room type within the next n days.

If no availability is found, the program should return an empty line.

Example output:

(20241101-20241103, 2), (20241203-20241210, 1)


This means that within the next 365 days:

There are 2 SGL rooms available from 2024/11/01 to 2024/11/03

There is 1 SGL room available from 2024/12/03 to 2024/12/10

⚙️ General Notes

The task should be implemented in C#.

The program should exit when a blank line is entered in the console.

## How to Build a .NET Console Application in VS Code.

### 1. Install Prerequisites

Make sure you have:

.NET SDK – download and install from
  https://dotnet.microsoft.com/download

Visual Studio Code – download from
  https://code.visualstudio.com/

C# Dev Kit and .NET Install Tool extensions:

Open VS Code → Extensions panel → search for “C# Dev Kit” → install.

This will automatically suggest installing the .NET Runtime and C# extensions.

### 2. Open the Project in VS Code
Inside the VS Code terminal, run:
```
dotnet build
```
The compiled files are now inside:
bin/Debug/net9.0/

### 3. Run the Application
Place test files to bin/Debug/net9.0/ next to the .exe file
Run this command:
```
dotnet run --hotels bin\Debug\net9.0\hotels.json --bookings bin\Debug\net9.0\bookings.json
```

## How to run app from cmd
Place test files to bin/Debug/net9.0/ next to the .exe file
Open cmd in a folder with .exe file.
Run this command:
```
bookroom --hotels hotels.json --bookings bookings.json
```

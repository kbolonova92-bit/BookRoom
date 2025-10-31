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

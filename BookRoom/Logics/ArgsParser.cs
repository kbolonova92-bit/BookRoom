using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public static class ArgsParser
    {

        public const string HotelsArg = "--hotels";
        public const string BookingsArg = "--bookings";
        public const int ValidParamsAmount = 4;
        public const string FilesExtension = ".json";

        public const string NotValidErrorMessage = "Invalid parameters. Add --hotels <filepath> and --bookings <filepath>.";
        public const string NotValidFilesExtensionMessage = $"Invalid parameters. Only {FilesExtension} files are supported.";

        public static bool TryParse(string[] arguments, out string hotelFilePath, out string bookingsFilePath, out string errorMessage)
        {
            errorMessage = string.Empty;
            hotelFilePath = string.Empty;
            bookingsFilePath = string.Empty;

            if (!arguments.Contains(HotelsArg) || !arguments.Contains(BookingsArg))
            {
                errorMessage = NotValidErrorMessage;
                return false;
            }

            if (arguments.Length != ValidParamsAmount)
            {
                errorMessage = NotValidErrorMessage;
                return false;
            }
            
            for (int i = 0; i < arguments.Length; i++)
            {
                switch (arguments[i])
                {
                    case HotelsArg:
                        if (i + 1 < arguments.Length)
                            hotelFilePath = arguments[i + 1];
                        break;

                    case BookingsArg:
                        if (i + 1 < arguments.Length)
                            bookingsFilePath = arguments[i + 1];
                        break;
                }
            }

            if (!hotelFilePath.EndsWith(FilesExtension) || !bookingsFilePath.EndsWith(FilesExtension))
            {
                errorMessage = NotValidFilesExtensionMessage;
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Logics
{
    public static class ArgsValidator
    {

        public const string HotelsArg = "--hotels";
        public const string BookingsArg = "--bookings";

        public const string NotValidErrorMessage = "Not valid params! Add --hotels <filepath> and --bookings <filepath>.";

        public static bool TryParse(string[] arguments, out string hotelFilePath, out string bookingFilePath, out string errorMessage)
        {
            errorMessage = string.Empty;
            hotelFilePath = string.Empty;
            bookingFilePath = string.Empty;

            if (!arguments.Contains(HotelsArg) || !arguments.Contains(BookingsArg)) errorMessage = NotValidErrorMessage;

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
                            bookingFilePath = arguments[i + 1];
                        break;
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Models
{
    public class AvailabilitySlot
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomsAvailable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRoom.Models
{
    public class SearchParams
    {
        public string HotelId { get; set; }
        public int DaysAhead { get; set; }
        public string RoomType { get; set; }
    }
}

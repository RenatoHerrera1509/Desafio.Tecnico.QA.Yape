using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Booking
{
    public class BookingRequestDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
    }
}

using Models.CreateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UpdateBooking
{
    public class UpdateBookingRequestDto
    {
        public int id { get; set; }
        public CreateBookingRequestDto dto { get; set; }
    }
}

using Models.GetBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CreateBooking
{
    public class CreateBookingResponseDto
    {
        public int BookingId { get; set; }
        public BookingDetailsResponseDto Booking { get; set; }
    }
}

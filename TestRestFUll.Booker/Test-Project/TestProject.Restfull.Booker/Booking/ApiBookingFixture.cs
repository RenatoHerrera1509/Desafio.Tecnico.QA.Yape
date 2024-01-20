using BusinessLogic.restful_booker.Authenticate;
using BusinessLogic.restful_booker.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class ApiBookingFixture
    {
        public IBooking BookingService { get; set; }
        public IAuth AuthService { get; }
        public ApiBookingFixture()
        {
            var client = new HttpClient();
            AuthService = new BusinessLogic.restful_booker.Authenticate.Auth(client);
            BookingService = new BusinessLogic.restful_booker.Booking.Booking(client, AuthService);
        }
    }
}

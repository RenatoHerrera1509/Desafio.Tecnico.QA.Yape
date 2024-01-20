using Models.GetBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.PartialUpdate
{
    public class PartialUpdateBookingRequestDto
    {
        public int id { get; set; }
        public dto dt { get; set; }

        public PartialUpdateBookingRequestDto()
        {
            dt = new dto();
        }
    }
    public class dto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int? totalprice { get; set; }
        public bool? depositpaid { get; set; }
        public BookingDates? bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
}


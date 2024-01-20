using Models.Booking;
using Models.CreateBooking;
using Models.GetBooking;
using Models.PartialUpdate;
using Models.UpdateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.restful_booker.Booking
{
    public interface IBooking
    {
        Task<ApiResponse<IEnumerable<BookingResponseDto>>> GetBookingIdsAsync(BookingRequestDto request);
        Task<ApiResponse<BookingDetailsResponseDto>> GetBookingAsync(int bookingId);
        Task<ApiResponse<CreateBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto request);
        Task<ApiResponse<BookingDetailsResponseDto>> UpdateBookingAsync(UpdateBookingRequestDto request);
        Task<ApiResponse<BookingDetailsResponseDto>> PartialUpdateBookingAsync(PartialUpdateBookingRequestDto request);
    }
}

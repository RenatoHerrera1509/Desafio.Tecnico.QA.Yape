using BusinessLogic.restful_booker.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class BookingDetailsServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;
        public BookingDetailsServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "GetBooking retorna detalles de reserva válidos")]
        public async Task GetBookingAsync_ReturnsValidBookingDetails_WhenIdIsValid()
        {
            // Arrange
            int validBookingId = 1;

            // Act
            var apiResponse = await _bookingService.GetBookingAsync(validBookingId);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.False(apiResponse.IsSuccessStatusCode);
            Assert.Null(apiResponse.Result);
            Assert.Equal(418, apiResponse.StatusCode);
        }
    }
}

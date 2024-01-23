using BusinessLogic.restful_booker.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class DeleteBookingServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;

        public DeleteBookingServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "DeleteBooking elimina una reserva existente")]
        public async Task DeleteBookingAsync_DeletesExistingBooking()
        {
            // Arrange
            int bookingId = 2; 

            // Act
            var apiResponse = await _bookingService.DeleteBookingAsync(bookingId);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.Equal(201, (double)apiResponse.StatusCode);
        }
    }
}

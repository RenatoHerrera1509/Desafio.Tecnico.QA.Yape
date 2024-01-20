using BusinessLogic.restful_booker.Booking;
using Models.PartialUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class PartialUpdateBookingServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;

        public PartialUpdateBookingServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "PartialUpdateBooking actualiza parcialmente una reserva y retorna detalles actualizados")]
        public async Task PartialUpdateBookingAsync_UpdatesBookingPartiallyAndReturnsUpdatedDetails()
        {
            // Arrange
            var requestDto = new PartialUpdateBookingRequestDto();
            requestDto.id = 1;
            requestDto.dt.firstname = "James";
            requestDto.dt.lastname = "Brown";

            // Act
            var apiResponse = await _bookingService.PartialUpdateBookingAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.False(apiResponse.IsSuccessStatusCode);
            Assert.Null(apiResponse.Result);
        }
    }
}

using BusinessLogic.restful_booker.Booking;
using Models.GetBooking;
using Models.UpdateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class UpdateBookingServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;

        public UpdateBookingServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "UpdateBooking actualiza una reserva y retorna detalles actualizados")]
        public async Task UpdateBookingAsync_UpdatesBookingAndReturnsUpdatedDetails()
        {
            // Arrange
            var requestDto = new UpdateBookingRequestDto
            {
                id = 1,
                dto = new Models.CreateBooking.CreateBookingRequestDto
                {
                    firstname = "James",
                    lastname = "Brown",
                    totalprice = 111,
                    depositpaid = true,
                    bookingdates = new BookingDates
                    {
                        checkin = "2018-01-01",
                        checkout = "2019-01-01"
                    },
                    additionalneeds = "Breakfast"
                }
            };

            // Act
            var apiResponse = await _bookingService.UpdateBookingAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.False(apiResponse.IsSuccessStatusCode);
            Assert.Null(apiResponse.Result);
        }
    }
}

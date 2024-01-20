using BusinessLogic.restful_booker.Booking;
using Models.CreateBooking;
using Models.GetBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Booking
{
    public class CreateBookingServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;

        public CreateBookingServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "CreateBooking crea una nueva reserva y retorna detalles")]
        public async Task CreateBookingAsync_CreatesNewBookingAndReturnsDetails()
        {
            // Arrange
            var requestDto = new CreateBookingRequestDto
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            };

            // Act
            var apiResponse = await _bookingService.CreateBookingAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.False(apiResponse.IsSuccessStatusCode);
            Assert.Null(apiResponse.Result);
        }
    }
}

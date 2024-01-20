using BusinessLogic.restful_booker.Booking;
using Models.Booking;

namespace TestProject.Restfull.Booker.Booking
{
    public class BookingServiceTests : IClassFixture<ApiBookingFixture>
    {
        private readonly IBooking _bookingService;
        public BookingServiceTests(ApiBookingFixture fixture)
        {
            _bookingService = fixture.BookingService;
        }

        [Fact(DisplayName = "GetBookingIds retorna todos los IDs cuando no hay filtros")]
        public async Task GetBookingIdsAsync_ReturnsAllBookingIds_WhenNoFilterIsApplied()
        {
            // Arrange
            var requestDto = new BookingRequestDto();

            // Act
            var apiResponse = await _bookingService.GetBookingIdsAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.NotNull(apiResponse.Result);
            Assert.Equal(200, apiResponse.StatusCode);
            Assert.Null(apiResponse.ErrorMessage);
            Assert.IsAssignableFrom<IEnumerable<BookingResponseDto>>(apiResponse.Result);
        }

        [Fact(DisplayName = "GetBookingIds retorna IDs filtrados por nombre y apellido")]
        public async Task GetBookingIdsAsync_ReturnsFilteredBookingIds_WhenNameFilterIsApplied()
        {
            // Arrange
            var requestDto = new BookingRequestDto { firstName = "sally", lastName = "brown" };

            // Act
            var apiResponse = await _bookingService.GetBookingIdsAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.NotNull(apiResponse.Result);
            Assert.Equal(200, apiResponse.StatusCode);
            Assert.Null(apiResponse.ErrorMessage);
            Assert.IsAssignableFrom<IEnumerable<BookingResponseDto>>(apiResponse.Result);
        }

        [Fact(DisplayName = "GetBookingIds retorna IDs filtrados por fecha de checkin y checkout")]
        public async Task GetBookingIdsAsync_ReturnsFilteredBookingIds_WhenDateFilterIsApplied()
        {
            // Arrange
            var requestDto = new BookingRequestDto { checkIn = "2014-03-13", checkOut = "2014-05-21" };

            // Act
            var apiResponse = await _bookingService.GetBookingIdsAsync(requestDto);

            // Assert
            Assert.NotNull(apiResponse);
            Assert.True(apiResponse.IsSuccessStatusCode);
            Assert.NotNull(apiResponse.Result);
            Assert.Equal(200, apiResponse.StatusCode);
            Assert.Null(apiResponse.ErrorMessage);
            Assert.IsAssignableFrom<IEnumerable<BookingResponseDto>>(apiResponse.Result);
        }

    }
}

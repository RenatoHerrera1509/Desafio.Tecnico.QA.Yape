using BusinessLogic.restful_booker.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Restfull.Booker.Ping
{
    public class PingServiceTests
    {
        private readonly IPing _pingService;

        public PingServiceTests()
        {
            var httpClient = new HttpClient();
            _pingService = new BusinessLogic.restful_booker.Ping.Ping(httpClient);
        }

        [Fact(DisplayName = "HealthCheck devuelve verdadero si la API está operativa")]
        public async Task HealthCheckAsync_ReturnsTrue_IfApiIsOperational()
        {
            // Act
            var isOperational = await _pingService.HealthCheckAsync();

            // Assert
            Assert.True(isOperational);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.APK.Booking.Fixture;

namespace TestProject.APK.Booking.LaunchTest
{
    public class BasicAppiumTests : IClassFixture<AppiumFixture>
    {
        private readonly AppiumFixture _appiumFixture;

        public BasicAppiumTests(AppiumFixture appiumFixture)
        {
            _appiumFixture = appiumFixture;
        }

        [Fact]
        public void TestAppLaunches()
        {
            Assert.NotNull(_appiumFixture.Driver);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Models.Appium_Model.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.APK.Booking.Fixture
{
    public class AppiumFixture : IDisposable
    {
        public AppiumConfiguration Configuration { get; private set; }
        public AndroidDriver<AndroidElement> Driver { get; private set; }

        public AppiumFixture()
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            Configuration = configuration.GetSection("capabilities").Get<AppiumConfiguration>();

            // Create Appium options from configuration
            var appiumOptions = new AppiumOptions();

            // Check if AlwaysMatch section exists and has values
            if (Configuration.AlwaysMatch != null)
            {
                appiumOptions.AddAdditionalCapability("appium:app", Configuration.AlwaysMatch.App);
                appiumOptions.AddAdditionalCapability("appium:deviceName", Configuration.AlwaysMatch.DeviceName);
                appiumOptions.AddAdditionalCapability("appium:automationName", Configuration.AlwaysMatch.AutomationName);
                appiumOptions.AddAdditionalCapability("platformName", Configuration.AlwaysMatch.PlatformName);
                appiumOptions.AddAdditionalCapability("appium:platformVersion", Configuration.AlwaysMatch.PlatformVersion);
            }


            // Initialize the Appium driver
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/"), appiumOptions);
        }

        public void Dispose()
        {
            Driver?.Quit();
        }
    }

}

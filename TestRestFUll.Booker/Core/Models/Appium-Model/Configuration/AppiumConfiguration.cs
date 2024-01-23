namespace Models.Appium_Model.Configuration
{
    public class AppiumCapabilities
    {
        public string PlatformName { get; set; }
        public string PlatformVersion { get; set; }
        public string DeviceName { get; set; }
        public string App { get; set; }
        public string AutomationName { get; set; }
    }

    public class AppiumConfiguration
    {
        public AppiumCapabilities AlwaysMatch { get; set; }
    }

}

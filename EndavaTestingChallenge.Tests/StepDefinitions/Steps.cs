using EndavaTestingChallenge.Library.SwagLabs.Pages;
using OpenQA.Selenium;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    [Binding]
    public abstract class Steps : TechTalk.SpecFlow.Steps
    {
        protected Dictionary<string, dynamic> TestData { get; set; } = new();

        protected Setttings Settings { get; set; }

        protected Lazy<IWebDriver> Driver { get; set; }

        protected App App { get; set; }

        protected static AventStack.ExtentReports.ExtentReports ExtentReport { get; set; }

        public Steps() { }

        public Steps(AventStack.ExtentReports.ExtentReports extentReport) 
        {
            ExtentReport = extentReport;
        }

        public Steps(App app)
        {
            App = app;
        }
        public Steps(Dictionary<string, dynamic> testData, App app)
        {
            TestData = testData;
            App = app;
        }

        public Steps(Dictionary<string, dynamic> testData, Setttings settings, Lazy<IWebDriver> driver, App app)
        {
            TestData = testData;
            Settings = settings;
            Driver = driver;
            App = app;
        }
    }
}

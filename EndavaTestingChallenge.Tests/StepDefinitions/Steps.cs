using EndavaTestingChallenge.Library.SwagLabs.Pages;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    [Binding]
    public abstract class Steps : TechTalk.SpecFlow.Steps
    {
        protected Dictionary<string, dynamic> TestData { get; set; } = new();

        protected Setttings Settings { get; set; }

        protected Lazy<IWebDriver> Driver { get; set; }

        protected App App { get; set; }

        public Steps() { }

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

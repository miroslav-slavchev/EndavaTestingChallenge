using BoDi;
using EndavaTestingChallenge.Library.SwagLabs.Pages;
using EndavaTestingChallenge.Tests.FilesFacades;
using FluentAssertions.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.Hooks
{
    [Binding]
    public class AppHooks : StepDefinitions.Steps
    {
        private IObjectContainer ObjectContainer { get; set; }

        public AppHooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }


        [BeforeScenario]
        [Order(1)]
        public void InitConfig()
        {
            Dictionary<string, dynamic> testData = new();

#if DEBUG
            string envirnoment = "dev";
#else
            string envirnoment = "release";
#endif
            JObject json = JsonFileReaderFacade.GetJObjectFromFile($"settings.{envirnoment}.json");
            Settings = json.ToObject<Setttings>();
            ObjectContainer.RegisterInstanceAs(Settings);
            ObjectContainer.RegisterInstanceAs(testData);
            ObjectContainer.RegisterInstanceAs(ExtentReport);
        }

        [BeforeScenario]
        [Order(2)]
        public void OpenBrowser()
        {

            Driver = new Lazy<OpenQA.Selenium.IWebDriver>(() => GetDriver(Settings.Browser));
            Driver.Value.Url = Settings.Url;
            SetResolution();

            App = new(Driver.Value);

            ObjectContainer.RegisterInstanceAs(Driver);
            ObjectContainer.RegisterInstanceAs(App);
        }

        private void SetResolution()
        {
            if (Settings.BrowserResolution == null)
            {
                Driver.Value.Manage().Window.Maximize();
            }
            else
            {
                Driver.Value.Manage().Window.Size = new Size(
                width: Settings.BrowserResolution.Width,
                height: Settings.BrowserResolution.Height);
            }
        }

        private static IWebDriver GetDriver(string browser)
        {
            IWebDriver webDriver;
            switch (browser)
            {
                case "Chrome": webDriver = new ChromeDriver(); break;
                case "Firefox": webDriver = new FirefoxDriver(); break;
                default: throw new NotSupportedException(browser);
            }
            return webDriver;
        }

        [AfterScenario(Order = 1)]
        public void LogOut()
        {
            if (App.Navigation.IsNavigationExpanded == false)
            {
                App.Header.NavigationBurger.Click();
                Thread.Sleep(2000);
            }
            App.Navigation.Logout.Click();
        }

        [AfterScenario(Order = 2)]
        public void StopBrowser()
        {
            Driver.Value.Quit();
        }
    }
}

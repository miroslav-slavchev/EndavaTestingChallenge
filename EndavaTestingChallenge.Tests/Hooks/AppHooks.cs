using BoDi;
using EndavaTestingChallenge.Library.SwagLabs.Pages;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
        public void OpenBrowser()
        {
            Dictionary<string, dynamic> testData = new();
            JsonFileReaderFacade config = new JsonFileReaderFacade();
            Setttings settings = config.GetJObjectFromFile("settings.json").ToObject<Setttings>();

            Driver = new Lazy<OpenQA.Selenium.IWebDriver>(() => new ChromeDriver());
            Driver.Value.Url = settings.Url;
            App = new(Driver.Value);

            ObjectContainer.RegisterInstanceAs(settings);
            ObjectContainer.RegisterInstanceAs(Driver);
            ObjectContainer.RegisterInstanceAs(App);
            ObjectContainer.RegisterInstanceAs(testData);
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

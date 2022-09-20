using EndavaTestingChallenge.Library.SwagLabs.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    public class NavigationSteps : Steps
    {
        public NavigationSteps(App app) :base(app)
        {

        }

        [When(@"Go to (.*)")]
        public void GoToPage(string page)
        {
            switch (page.ToLower())
            {
                case "checkout": App.Header.Cart.Click(); break;
                case "all items": ExpandNavMenu(); App.Navigation.AllItems.Click(); break;
                case "logout": ExpandNavMenu(); App.Navigation.Logout.Click(); break;
                case "reset app state": ExpandNavMenu(); App.Navigation.ResetAppState.Click(); break;
                default: throw new NotSupportedException($"Uknown page:{page}");
            }
        }

        private void ExpandNavMenu()
        {
            if (App.Navigation.IsNavigationExpanded == false)
            {
                App.Header.NavigationBurger.Click();
                Thread.Sleep(2000);
            }
        }
    }
}

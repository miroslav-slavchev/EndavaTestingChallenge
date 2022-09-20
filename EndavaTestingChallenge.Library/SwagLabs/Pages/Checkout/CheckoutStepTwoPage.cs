using EndavaTestingChallenge.Library.SwagLabs.CartPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages.Checkout
{
    public class CheckoutStepTwoPage : Page
    {
        internal CheckoutStepTwoPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public CheckOutOverview CheckOutOverview => Container.FindPageObject<CheckOutOverview>(By.Id("checkout_summary_container"));
    }
}

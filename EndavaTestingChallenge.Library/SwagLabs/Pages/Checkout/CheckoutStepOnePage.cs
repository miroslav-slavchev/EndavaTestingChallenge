using EndavaTestingChallenge.Library.SwagLabs.CartPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages.Checkout
{
    public class CheckoutStepOnePage : Page
    {
        internal CheckoutStepOnePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public BillingDetails BillingDetails => Container.FindPageObject<BillingDetails>(By.Id("checkout_info_container"));
    }
}

using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.CartPage;
using EndavaTestingChallenge.Library.SwagLabs.Components;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages.Checkout
{
    public class CheckoutCompletePage : Page
    {
        public CheckoutCompletePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public CheckoutCompleteContainer CheckoutCompleteContainer => Container.FindPageObject<CheckoutCompleteContainer>(By.Id("checkout_complete_container"));
    }
}

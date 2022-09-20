using EndavaTestingChallenge.Library.SwagLabs.CartPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages.Checkout
{
    public class CartPage : Page
    {
        internal CartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public CartContentsContainer Cart => Container.FindPageObject<CartContentsContainer>(By.Id("cart_contents_container"));
    }
}

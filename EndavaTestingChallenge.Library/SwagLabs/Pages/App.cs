using EndavaTestingChallenge.Library.SwagLabs.Generic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages
{
    public class App
    {
        private IWebDriver Driver { get; init; }

        public App(IWebDriver driver)
        {
            Driver = driver;
        }

        public Header Header => new(Driver);

        public Navigation Navigation => new(Driver);

        public LoginPage LoginPage => new(Driver);

        public InventoryPage InventoryPage => new(Driver);

        public Checkout.CartPage CartPage => new(Driver);

        public Checkout.CheckoutStepOnePage CheckoutStepOnePage => new(Driver);

        public Checkout.CheckoutStepTwoPage CheckoutStepTwoPage => new(Driver);

        public Checkout.CheckoutCompletePage CheckoutCompletePage => new(Driver);
    }
}

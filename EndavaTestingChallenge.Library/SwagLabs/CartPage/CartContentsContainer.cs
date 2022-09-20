using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.CartPage
{
    public class CartContentsContainer : PageObject
    {
        internal CartContentsContainer(Container container) : base(container)
        {
        }

        public List<InventoryCartItem> CartItems => Container.FindPageObjects<InventoryCartItem>(By.ClassName("cart_item"));

        public Button ContinueShopping => Container.FindComponent<Button>(By.Id("continue-shopping"));

        public Button Checkout => Container.FindComponent<Button>(By.Id("checkout"));
    }
}

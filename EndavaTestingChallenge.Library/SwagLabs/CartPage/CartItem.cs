using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Anchor;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using OpenQA.Selenium;

namespace EndavaTestingChallenge.Library.SwagLabs.CartPage
{
    public class InventoryCartItem : InvertoryItem
    {
        internal InventoryCartItem(Container container) : base(container)
        {
        }

        public int Quantity => int.Parse(Container.FindComponent<TextNode>(By.ClassName("cart_quantity")).Text);

        public Button Remove => Container.FindComponent<Button>(By.Id("remove-sauce-labs-backpack"));
    }
}
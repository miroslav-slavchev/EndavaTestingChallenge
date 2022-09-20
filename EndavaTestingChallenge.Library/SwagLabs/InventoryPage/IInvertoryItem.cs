using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Anchor;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using OpenQA.Selenium;

namespace EndavaTestingChallenge.Library.SwagLabs.InventoryPage
{
    public abstract class InvertoryItem : PageObject
    {
        internal InvertoryItem(Container container) : base(container)
        {
        }

        public AnchorText Name => Container.FindComponent<AnchorText>(By.ClassName("inventory_item_name"));

        public TextNode Description => Container.FindComponent<TextNode>(By.ClassName("inventory_item_desc"));

        public InventoryPrice InventoryPrice => new(Container.FindComponent<TextNode>(By.ClassName("inventory_item_price")).Text);
    }
}
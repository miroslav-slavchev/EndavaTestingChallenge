using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Anchor;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using EndavaTestingChallenge.Library.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.InventoryPage
{
    public class InventoryProductItem : InvertoryItem
    {
        internal InventoryProductItem(Container container) : base(container)
        {
        }

        public AnchorImage Image => Container.FindComponent<AnchorImage>(By.ClassName("inventory_item_img"));

        public Maybe<Button> AddToCart => Container.TryFindComponent<Button>(By.CssSelector("button[id*='add-to-cart']"));

        public Maybe<Button> Remove => Container.TryFindComponent<Button>(By.CssSelector("button[id*='remove']"));
    }
}

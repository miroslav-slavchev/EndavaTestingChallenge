using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.CartPage
{
    public class CheckOutOverview : PageObject
    {
        internal CheckOutOverview(Container container) : base(container)
        {
        }

        public List<InventoryCartItem> CartItems => Container.FindPageObjects<InventoryCartItem>(By.ClassName("cart_item"));

        public Button Cancel => Container.FindComponent<Button>(By.Id("cancel"));

        public Button Finish => Container.FindComponent<Button>(By.Id("finish"));

        public SummaryInfo SummaryInfo => Container.FindPageObject<SummaryInfo>(By.ClassName("summary_info"));
    }

    public class SummaryInfo : PageObject
    {
        internal SummaryInfo(Container container) : base(container)
        {
        }

        public string PaymentInforamation => Container.FindComponent<TextNode>(By.CssSelector("div.summary_info > div:nth-child(2)")).Text;

        public string ShippingInforamation => Container.FindComponent<TextNode>(By.CssSelector("div.summary_info > div:nth-child(4)")).Text;

        public InventoryPrice ItemTotal => new(Container.FindComponent<TextNode>(By.ClassName("summary_subtotal_label")).Text.Split(" ")[1]);

        public InventoryPrice Tax => new(Container.FindComponent<TextNode>(By.ClassName("summary_tax_label")).Text.Split(" ")[1]);

        public InventoryPrice Total => new(Container.FindComponent<TextNode>(By.ClassName("summary_total_label")).Text.Split(" ")[1]);
    }
}

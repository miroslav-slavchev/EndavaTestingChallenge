using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using OpenQA.Selenium;

namespace EndavaTestingChallenge.Library.SwagLabs.CartPage
{
    public class CheckoutCompleteContainer : PageObject
    {
        internal CheckoutCompleteContainer(Container container) : base(container)
        {
        }

        public string ThankYouHeading => Container.FindComponent<TextNode>(By.ClassName("complete-header")).Text;

        public string OrderMessage => Container.FindComponent<TextNode>(By.ClassName("complete-text")).Text;

        public Image PonyExpressImage => Container.FindComponent<Image>(By.CssSelector("img.pony_express"));

        public Button BackHome => Container.FindComponent<Button>(By.Id("back-to-products"));
    }
}

using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.Input;
using EndavaTestingChallenge.Library.SwagLabs.LoginPage;
using EndavaTestingChallenge.Library.Utils;
using OpenQA.Selenium;

namespace EndavaTestingChallenge.Library.SwagLabs.CartPage
{
    public class BillingDetails : PageObject
    {
        internal BillingDetails(Container container) : base(container)
        {
        }

        public TextInputField GetTextInputField(string placeHolder) => Container.FindComponent<TextInputField>(By.CssSelector($"input[placeholder='{placeHolder}']"));

        public Maybe<ValidationMessage> ErrorMessage => Container.TryFindPageObject<ValidationMessage>(By.CssSelector("div.error"));

        public Button Cancel => Container.FindComponent<Button>(By.Id("cancel"));

        public Button Continue => Container.FindComponent<Button>(By.Id("continue"));
    }
}

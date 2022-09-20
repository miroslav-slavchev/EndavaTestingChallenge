using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.Input;
using EndavaTestingChallenge.Library.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.LoginPage
{
    public class LoginForm : PageObject
    {
        internal LoginForm(Container container) : base(container)
        {
        }

        public TextInputField UserName => Container.FindComponent<TextInputField>(By.Id("user-name"));

        public TextInputField Password => Container.FindComponent<TextInputField>(By.Id("password"));

        public Button Login => Container.FindComponent<Button>(By.Id("login-button"));

        public Maybe<ValidationMessage> ErrorMessage => Container.TryFindPageObject<ValidationMessage>(By.CssSelector("div.error"));
    }
}

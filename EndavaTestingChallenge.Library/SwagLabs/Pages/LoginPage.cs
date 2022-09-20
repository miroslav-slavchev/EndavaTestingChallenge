using EndavaTestingChallenge.Library.SwagLabs.LoginPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public LoginForm LoginForm => Container.FindPageObject<LoginForm>(By.Id("login_button_container"));

        public CredentialsContainer CredentialsContainer => Container.FindPageObject<CredentialsContainer>(By.CssSelector("div.login_credentials_wrap"));
    }
}

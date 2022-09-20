using EndavaTestingChallenge.Library.SwagLabs.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps : Steps
    {
        protected LoginPage LoginPage => App.LoginPage;

        public LoginSteps(App app) : base(app)
        {

        }

        [Given(@"Log in with the standard user")]
        public void GivenLogInWithTheStandardUser()
        {
            (string username, string password) = ObtainCredentions();
            LogIn(username, password);
        }

        private void LogIn(string username, string password)
        {
            var loginForm = LoginPage.LoginForm;
            loginForm.UserName.SendKeys(username);
            loginForm.Password.SendKeys(password);
            loginForm.Login.Click();
        }

        private (string Username, string Password) ObtainCredentions()
        {
            var credentialsContainer = LoginPage.CredentialsContainer;
            return (credentialsContainer.AcceptedUsernames.First(), credentialsContainer.PasswordForAllUsers);
        }
    }
}

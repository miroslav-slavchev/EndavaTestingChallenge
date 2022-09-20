using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.LoginPage
{
    public class CredentialsContainer : PageObject
    {
        internal CredentialsContainer(Container container) : base(container)
        {
        }

        public List<string> AcceptedUsernames => Container.FindComponent<TextNode>(By.Id("login_credentials"))
            .InnerHtml
            .Split("</h4>")[1]
            .Split("<br>")
            .Where(item => string.IsNullOrEmpty(item) == false)
            .ToList();

        public string PasswordForAllUsers => Container.FindComponent<TextNode>(By.ClassName("login_password"))
            .InnerHtml
            .Split("</h4>")[1];
    }
}

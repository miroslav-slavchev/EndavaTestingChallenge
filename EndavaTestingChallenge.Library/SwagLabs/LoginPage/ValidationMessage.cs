using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.LoginPage
{
    public class ValidationMessage : PageObject
    {
        internal ValidationMessage(Container container) : base(container)
        {
        }

        public TextNode Message => Container.FindComponent<TextNode>(By.TagName("h3"));

        public Button Close => Container.FindComponent<Button>(By.TagName("button"));
    }
}

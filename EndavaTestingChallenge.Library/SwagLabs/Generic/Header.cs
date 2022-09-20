using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using EndavaTestingChallenge.Library.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Generic
{
    public class Header : PageObject
    {
        internal Header(IWebDriver driver) : base(driver)
        {
        }

        private Container Main => Container.FindComponent<Container>(By.ClassName("primary_header"));

        public Button Cart => Main.FindComponent<Button>(By.Id("shopping_cart_container"));

        public Maybe<TextNode> CartBadge => Main.TryFindComponent<TextNode>(By.ClassName("shopping_cart_badge"));

        public Button NavigationBurger => Main.FindComponent<Button>(By.Id("react-burger-menu-btn"));

    }
}

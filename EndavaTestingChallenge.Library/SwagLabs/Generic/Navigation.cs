using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using EndavaTestingChallenge.Library.SwagLabs.Components.Buttons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Generic
{
    public class Navigation : PageObject, IAreaHidden
    {
        internal Navigation(IWebDriver driver) : base(driver)
        {
        }
        private Container Main => Container.FindComponent<Container>(By.ClassName("bm-menu-wrap"));

        public Button Close => Main.FindComponent<Button>(By.Id("react-burger-cross-btn"));

        public Button AllItems => Main.FindComponent<Button>(By.Id("inventory_sidebar_link"));

        public Button About => Main.FindComponent<Button>(By.Id("about_sidebar_link"));

        public Button Logout => Main.FindComponent<Button>(By.Id("logout_sidebar_link"));

        public Button ResetAppState => Main.FindComponent<Button>(By.Id("reset_sidebar_link"));

        public string AriaHidden => Main.GetAttribute("aria-hidden");

        public bool IsNavigationExpanded => !bool.Parse(AriaHidden);

    }
}

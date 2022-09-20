using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.Anchor
{
    public class Anchor : Component, IHref, IClickable
    {
        internal Anchor(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public string Href => WrappedElement.GetAttribute("href");

        public void Click() => WrappedElement.Click();
    }
}

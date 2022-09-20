using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.Buttons
{
    public class Button : Component, IClickable
    {
        internal Button(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public void Click()
        {
            WrappedElement.Click();
        }
    }
}

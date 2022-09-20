using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.Infrastructure.Components
{
    public abstract class Component
    {
        protected IWebElement WrappedElement { get; private set; }
        protected By Locator { get; private set; }

        internal Component(By locator, IWebElement wrappedElement)
        {
            Locator = locator;
            WrappedElement = wrappedElement;
        }
    }
}

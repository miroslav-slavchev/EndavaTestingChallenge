using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.Infrastructure.PageObjects
{
    public abstract class PageObject
    {
        private By RootElementLocator { get; } = By.TagName("body");
        private protected Container Container { get; }

        internal PageObject(Container container)
        {
            Container = container;
        }

        internal PageObject(IWebDriver driver)
        {
            Container body = new(RootElementLocator, driver.FindElement(RootElementLocator));
            Container = body;
        }
    }
}

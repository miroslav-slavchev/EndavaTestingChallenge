using EndavaTestingChallenge.Library.Infrastructure.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages
{
    public abstract class Page : PageObject
    {
        private IWebDriver WebDriver { get; init; }

        public Page(IWebDriver webDriver) : base(webDriver)
        {
            WebDriver = webDriver;
        }

    }
}

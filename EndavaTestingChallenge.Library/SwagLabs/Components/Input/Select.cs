using EndavaTestingChallenge.Library.Infrastructure.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.Input
{
    public class Select : Component
    {
        private SelectElement SelectElement => new SelectElement(WrappedElement);
        internal Select(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public void SelectOption(string option) => SelectElement.SelectByText(option);

        public string SelectedOption => SelectElement.SelectedOption.Text;

        public List<string> Options => SelectElement.Options.Select(option => option.Text).ToList();
    }
}

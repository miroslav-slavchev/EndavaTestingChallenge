using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.Input
{
    public class TextInputField : Component, ISendKeys, IValue, IPlaceHolder
    {
        internal TextInputField(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public void SendKeys(string keys)
        {
            WrappedElement.SendKeys(keys);
        }

        public string Value => WrappedElement.GetAttribute("value");

        public string PlaceHolder => WrappedElement.GetAttribute("placeholder");
    }
}

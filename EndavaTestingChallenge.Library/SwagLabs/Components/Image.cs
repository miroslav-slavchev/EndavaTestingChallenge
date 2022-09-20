using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components
{
    public class Image : Component, IAlt, ISrc
    {
        internal Image(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public string Alt => WrappedElement.GetAttribute("alt");

        public string Src => WrappedElement.GetAttribute("src");
    }
}

using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers
{
    public class TextNode : Component, IText, IInnerHtml
    {
        internal TextNode(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public string Text => WrappedElement.Text;

        public string InnerHtml => WrappedElement.GetAttribute("innerHTML");
    }
}

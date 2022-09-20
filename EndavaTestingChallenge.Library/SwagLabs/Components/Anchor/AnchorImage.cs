using EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Components.Anchor
{
    public class AnchorImage : Anchor, ISrc, IAlt
    {
        internal AnchorImage(By locator, IWebElement wrappedElement) : base(locator, wrappedElement)
        {
        }

        public string Src => WrappedElement.GetAttribute("src");

        public string Alt => WrappedElement.GetAttribute("alt");
    }
}

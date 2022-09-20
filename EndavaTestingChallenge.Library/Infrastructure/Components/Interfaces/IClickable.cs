using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.Infrastructure.Components.Interfaces
{
    public interface IClickable
    {
        void Click();
    }

    /*
    public static class IClickableExtensions
    {
        public static void Click(this IClickable clickable)
        {
            IWebElement element = (IWebElement)clickable.GetType().GetField("_wrappedElement", BindingFlags.NonPublic | BindingFlags.Instance) 
                ?? throw new ArgumentNullException(nameof(element));
            element.Click();
        }
    }*/
}

using EndavaTestingChallenge.Library.Infrastructure.Components;
using EndavaTestingChallenge.Library.Utils;
using OpenQA.Selenium;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace EndavaTestingChallenge.Library.Infrastructure.PageObjects
{
    internal class Container : Component
    {
        internal Container(By locator, IWebElement searchContext) : base(locator, searchContext)
        {
        }

        public T FindComponent<T>(By locator) where T : Component
        {
            var webElement = WrappedElement.FindElement(locator);
            T t = CreateComponent<T>(locator, webElement);
            return t;
        }

        public Maybe<T> TryFindComponent<T>(By locator) where T : Component
        {
            Maybe<T> result;
            var webElements = WrappedElement.FindElements(locator).ToList();
            if (webElements.Any() == true)
            {
                result = new(CreateComponent<T>(locator, webElements.First()));
            }
            else
            {
                result = new();
            }
            return result;
        }

        public List<T> FindComponents<T>(By locator) where T : Component
        {
            var webElements = WrappedElement.FindElements(locator).ToList();
            var components = webElements.Select(element => CreateComponent<T>(locator, element)).ToList();
            return components;
        }

        public T FindPageObject<T>(By locator) where T : PageObject
        {
            var webElement = WrappedElement.FindElement(locator);
            var pageObject = CreatePageObject<T>(locator, webElement);
            return pageObject;
        }

        public Maybe<T> TryFindPageObject<T>(By locator) where T : PageObject
        {
            Maybe<T> result;
            var webElements = WrappedElement.FindElements(locator).ToList();
            if (webElements.Any() == true)
            {
                result = new(CreatePageObject<T>(locator, webElements.First()));
            }
            else
            {
                result = new();
            }
            return result;
        }

        public List<T> FindPageObjects<T>(By locator) where T : PageObject
        {
            var webElements = WrappedElement.FindElements(locator).ToList();
            var pageObjects = webElements.Select(pageObject => CreatePageObject<T>(locator, pageObject)).ToList();
            return pageObjects;
        }

        public string GetAttribute(string atr) => WrappedElement.GetAttribute(atr);

        private T CreateComponent<T>(By locator, IWebElement webElement) where T : Component
        {
            Type type = typeof(T);
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            CultureInfo culture = CultureInfo.InvariantCulture;
            Binder? binder = null;
            object[] args = new object[] { locator, webElement };
            object? component = Activator.CreateInstance(type, flags, binder, args, culture);
            return component as T;
        }

        private T CreatePageObject<T>(By locator, IWebElement webElement) where T : PageObject
        {
            var container = new Container(locator, webElement);
            Type type = typeof(T);
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            CultureInfo culture = CultureInfo.InvariantCulture;
            Binder? binder = null;
            object[] args = new object[] { container };
            object? pageObject = Activator.CreateInstance(type, flags, binder, args, culture);
            return pageObject as T;
        }

    }
}

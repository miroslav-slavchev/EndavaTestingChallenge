using EndavaTestingChallenge.Library.SwagLabs.Components.Input;
using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Library.SwagLabs.Pages
{
    public class InventoryPage : Page
    {
        internal InventoryPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public List<InventoryProductItem> InventoryItems => Container.FindPageObjects<InventoryProductItem>(By.ClassName("inventory_item"));

        public List<InventoryProductItem> AddedInventoryItems => 
            Container.FindPageObjects<InventoryProductItem>(By.ClassName("inventory_item"))
            .Where(item => item.AddToCart.Any() == false).ToList();

        public Select SortSelect => Container.FindComponent<Select>(By.ClassName("product_sort_container"));
    }
}

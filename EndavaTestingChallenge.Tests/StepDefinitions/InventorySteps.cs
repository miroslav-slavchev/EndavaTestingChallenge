using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using EndavaTestingChallenge.Library.SwagLabs.Pages;
using EndavaTestingChallenge.Tests.StepDefinitions.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    public class InventorySteps : Steps
    {
        public InventorySteps(Dictionary<string, dynamic> testData, App app) : base(app: app, testData: testData)
        {

        }

        [When(@"Add the (.*) and the (.*) items in the cart")]
        public void AddTheNthandMthItemInTheCart(string nth, string mth)
        {
            var itemsToAdd = GetInventoryItems(nth, mth);
            itemsToAdd.ForEach(item => item.AddToCart.Single().Click());
            StoreItemsData();
        }

        private void StoreItemsData()
        {
            var addedItems = App.InventoryPage.AddedInventoryItems.Select(item =>
                            new InventoryItemData
                            {
                                Name = item.Name.Text,
                                Description = item.Description.Text,
                                InventoryPrice = item.InventoryPrice.PriceFulltext
                            }
                        ).ToList();
            if (TestData.ContainsKey("AddedInventoryItems") == false)
            {
                TestData.Add("AddedInventoryItems", addedItems);
            }
            else
            {
                TestData["AddedInventoryItems"] = addedItems;
            }
        }

        [When(@"Add the (.*) item in the cart")]
        public void AddTheNthItemInTheCart(string nth)
        {
            var itemsToAdd = GetInventoryItem(nth);
            itemsToAdd.AddToCart.Single().Click();
            StoreItemsData();
        }

        [When(@"Remove the (.*) item")]
        public void RemoveTheNthItem(string nth)
        {
            var itemsToAdd = GetInventoryItem(nth);
            itemsToAdd.Remove.Single().Click();
            StoreItemsData();
        }

        [When(@"Verify when for sorting it is selected ""(.*)""")]
        public void WhenVerifyWhenForSortingItIsSelected(string option)
        {
            App.InventoryPage.SortSelect.SelectOption(option);
        }

        [Then(@"The items are sorted in the correct manner")]
        public void ThenTheItemsAreSortedInTheCorrectManner()
        {
            var currentSelect = App.InventoryPage.SortSelect.SelectedOption;
            var allItems = App.InventoryPage.InventoryItems.Select(item => item);

            if (currentSelect.StartsWith("Name"))
            {
                ValidateByName(currentSelect, allItems);
            }
            else if (currentSelect.StartsWith("Price"))
            {
                ValidateByPrice(currentSelect, allItems);
            }
            else
            {
                throw new NotSupportedException($"Not supported:{currentSelect}");
            }
        }

        private static void ValidateByPrice(string currentSelect, IEnumerable<InventoryProductItem> allItems)
        {
            List<double> actualItems = allItems.Select(item => item.InventoryPrice.Price).ToList();
            List<double> expectedItems;
            if (currentSelect.EndsWith("(low to high)"))
            {
                expectedItems = actualItems.OrderBy(item => item).ToList();
            }
            else if (currentSelect.EndsWith("(high to low)"))
            {
                expectedItems = actualItems.OrderByDescending(item => item).ToList();
            }
            else
            {
                throw new NotSupportedException($"Not supported:{currentSelect}");
            }
            actualItems.Should().BeEquivalentTo(expectedItems);
        }

        private static void ValidateByName(string currentSelect, IEnumerable<InventoryProductItem> allItems)
        {
            List<string> actualItems = allItems.Select(item => item.Name.Text).ToList();
            List<string> expectedItems;
            if (currentSelect.EndsWith("(A to Z)"))
            {
                expectedItems = actualItems.OrderBy(item => item).ToList();
            }
            else if (currentSelect.EndsWith("(Z to A)"))
            {
                expectedItems = actualItems.OrderByDescending(item => item).ToList();
            }
            else
            {
                throw new NotSupportedException($"Not supported:{currentSelect}");
            }

            actualItems.Should().BeEquivalentTo(expectedItems);
        }

        private List<InventoryProductItem> GetInventoryItems(params string[] indexes) => indexes.Select(index => GetInventoryItem(index)).ToList();

        private InventoryProductItem GetInventoryItem(string index)
        {
            var items = App.InventoryPage.InventoryItems;
            int nthIndex = GetInvetoryItemIndex(index, items.Count);
            return items.ElementAt(nthIndex);
        }

        public static int GetInvetoryItemIndex(string nth, int count)
        {
            bool isNumArg = int.TryParse(nth, out int index);
            if (isNumArg)
            {
                index--;
            }
            else
            {
                switch (nth.ToLower())
                {
                    case "first": index = 0; break;
                    case "last": index = count - 1; break;
                    case "previous to the last": index = count - 2; break;
                    default: throw new NotSupportedException($"Keyword '{nth}' not supported.");
                }
            }

            return index;
        }
    }
}

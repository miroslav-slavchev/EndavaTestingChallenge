using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using EndavaTestingChallenge.Library.SwagLabs.Pages;
using EndavaTestingChallenge.Tests.StepDefinitions.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.StepDefinitions
{
    public class CheckoutSteps : Steps
    {
        public CheckoutSteps(Dictionary<string, dynamic> testData, App app) : base(app: app, testData: testData)
        {

        }

        [Then(@"Verify the correct items are added")]
        public void VerifyTheCorrectItemsAreAdded()
        {
            List<InventoryItemData> addedItems = TestData["AddedInventoryItems"];
            var currentItems = App.CartPage.Cart.CartItems;
            addedItems.ForEach(expctedItem =>
            {
                var actualItem = currentItems.Single(currentItem => currentItem.Name.Text == expctedItem.Name);
                actualItem.Name.Text.Should().Be(expctedItem.Name);
                actualItem.Description.Text.Should().Be(expctedItem.Description);
                actualItem.InventoryPrice.PriceFulltext.Should().Be(expctedItem.InventoryPrice);
                actualItem.Quantity.Should().Be(1);
            });
        }

        [When(@"Remove the (.*) item from cart")]
        public void RemoveTheNthItemFromCart(string nth)
        {
            var currentItems = App.CartPage.Cart.CartItems;
            int index = InventorySteps.GetInvetoryItemIndex(nth, currentItems.Count);
            currentItems.ElementAt(index).Remove.Click();
        }

        [When(@"Proceed to checkout")]
        public void ProceedToCheckout()
        {
            App.CartPage.Cart.Checkout.Click();
        }

        [When(@"Enter billing details")]
        public void WhenEnterBillingDetails(Table table)
        {
            var fields = table.Header.ToArray();
            var values = table.Rows.First().Values;
            var fieldValuesPairs = fields.Zip(values, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            foreach (var fieldValuePair in fieldValuesPairs)
            {
                var field = fieldValuePair.Key;
                var value = fieldValuePair.Value;
                App.CheckoutStepOnePage.BillingDetails.GetTextInputField(field).SendKeys(value);
            }
            App.CheckoutStepOnePage.BillingDetails.Continue.Click();
        }

        [When(@"Finish the order")]
        public void WhenFinishTheOrder()
        {
            App.CheckoutStepTwoPage.CheckOutOverview.Finish.Click();
        }

        [Then(@"Verify order is placed")]
        public void ThenVerifyOrderIsPlaced()
        {
            App.CheckoutCompletePage.CheckoutCompleteContainer.ThankYouHeading.Should().Be("THANK YOU FOR YOUR ORDER");
            App.CheckoutCompletePage.CheckoutCompleteContainer.OrderMessage.Should().Be("Your order has been dispatched, and will arrive just as fast as the pony can get there!");
        }

        [Then(@"Verify cart is empty")]
        public void ThenVerifyCartIsEmpty()
        {
            App.CartPage.Cart.CartItems.Count.Should().Be(0);
            App.Header.CartBadge.Any().Should().Be(false);
        }

    }
}

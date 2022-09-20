using EndavaTestingChallenge.Library.SwagLabs.Components.Anchor;
using EndavaTestingChallenge.Library.SwagLabs.Components.TextContainers;
using EndavaTestingChallenge.Library.SwagLabs.InventoryPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndavaTestingChallenge.Tests.StepDefinitions.Data
{
    public class InventoryItemData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string InventoryPrice { get; set; }
    }
}

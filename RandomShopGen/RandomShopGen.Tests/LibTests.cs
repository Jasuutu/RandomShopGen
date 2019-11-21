using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomShopGen.Lib;
using RandomShopGen.Tests.TestData;

namespace RandomShopGen.Tests
{
    [TestClass]
    public class LibTests
    {
        private List<Item> items = new List<Item>
        {
            new Item("Test1", 1),
            new Item("Test2", 2),
            new Item("Test10", 10),
            new Item("Test Space", 100),
            new Item("Test3", 3),
            new Item("Test4", 4)
        };

        [TestMethod]
        [TestCategory("Item")]
        public void ItemWillNotThrowExceptionWhenGivenProperValues()
        {
            // Setup
            var itemName = "Test Item";
            var itemValue = 100;
            Item item = null;

            // Execute
            Action act = () =>
            {
                item = new Item(itemName, itemValue);
            };
            
            // Assert
            act.Should().NotThrow<ArgumentException>("a valid name and valid value were provided.");
            item.Should().NotBeNull("item should have been constructed correctly.");
        }

        [TestMethod]
        [TestCategory("Item")]
        public void ItemWillThrowExceptionWhenGivenIncorrectValues()
        {
            // Setup
            var itemName = string.Empty;
            var itemValue = 100;
            Item item = null;

            // Execute
            Action act = () => { item = new Item(itemName, itemValue); };

            // Assert
            act.Should().Throw<ArgumentException>("an empty item name is not a valid value");
            item.Should().BeNull("no item should be created when an invalid value is used.");
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldHaveNameWhenValidValuesAreProvided()
        {
            // Setup
            var shopName = "Test Shop";
            var shopGold = 1000;
            
            // Execute
            var shop = new Shop(shopName, shopGold, ItemData.BasicItemList);

            // Assert
            shop.Name.Should().Be("Test Shop");
            shop.Gold.Should().Be(1000);
            shop.ItemList.Count().Should().Be(2);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToAddItemToList()
        {
            var shop = new Shop("Test Shop", 100, ItemData.BasicItemList);
            var addedItem = new Item("Item 3", 300);

            shop.AddItemToList(addedItem);

            shop.ItemList.Should().Contain(addedItem);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToRemoveAnItemFromList()
        {
            var shop = new Shop("Test Shop", 100, ItemData.BasicItemList);
            
            shop.RemoveItemFromList("Item 1");

            shop.ItemList.Should().NotContain(x => x.Name == "Item 1");
        }

        [TestMethod]
        [TestCategory("JsonConversion")]
        [TestCategory("LocalOnly")]
        public void ItemExtractorShouldReadTestFileCorrectly()
        {
            var filePath = @"c:\TestItems.json";
            var extractor = new ItemsExtractor();

            var itemsList = extractor.ConvertFileToItemsCollection(filePath);

            itemsList.Items.Any().Should().BeTrue();
            itemsList.Items.FirstOrDefault().Should().NotBeNull();
        }
    }
}

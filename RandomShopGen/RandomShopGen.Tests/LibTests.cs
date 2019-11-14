using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomShopGen.Lib;

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
            var shop = new Shop(shopName, shopGold);

            // Assert
            shop.Name.Should().Be("Test Shop");
            shop.Gold.Should().Be(1000);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShouldShouldReturnSuccessWhenCreatingItemList()
        {
            
        }
    }
}

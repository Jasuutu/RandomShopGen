using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomShopGen.Lib;
using RandomShopGen.Tests.TestData;

namespace RandomShopGen.Tests
{
    [TestClass]
    public class LibTests
    {
        private const string TestItem = "Test Item";
        private const string TestShop = "Test Shop";
        private const int ItemValue100 = 100;
        private const int ShopGold1000 = 1000;

        [TestMethod]
        [TestCategory("Item")]
        public void ItemWillNotThrowExceptionWhenGivenProperValues()
        {
            Item item = null;

            Action act = () => { item = new Item(TestItem, ItemValue100, ItemType.Usable); };
            
            act.Should().NotThrow<ArgumentException>("a valid name and valid value were provided.");
            item.Should().NotBeNull("item should have been constructed correctly.");
        }

        [TestMethod]
        [TestCategory("Item")]
        public void ItemWillThrowExceptionWhenGivenIncorrectValues()
        {
            var itemName = string.Empty;
            Item item = null;

            Action act = () => { item = new Item(itemName, ItemValue100, ItemType.Usable); };

            act.Should().Throw<ArgumentException>("an empty item name is not a valid value");
            item.Should().BeNull("no item should be created when an invalid value is used.");
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldHaveNameWhenValidValuesAreProvided()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);

            shop.Name.Should().Be("Test Shop");
            shop.Gold.Should().Be(1000);
            shop.ItemList.Count().Should().Be(2);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToAddItemToList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            var addedItem = new Item("Item 3", ItemValue100, ItemType.Usable);

            shop.AddItemToList(addedItem);

            shop.ItemList.Should().Contain(addedItem);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToRemoveAnItemFromList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            
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

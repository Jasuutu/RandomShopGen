using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            item = new Item(itemName, ItemValue100, ItemType.Usable);
            
            ValidateModel(item).Should().Contain(v => v.MemberNames.Contains("Name") &&
                                                      v.ErrorMessage.Contains("required"));
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldHaveNameWhenValidValuesAreProvided()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);

            shop.Name.Should().Be("Test Shop");
            shop.Gold.Should().Be(700);
            shop.ItemList.Count().Should().Be(2);
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToAddItemToList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            var addedItem = new Item("Item 3", ItemValue100, ItemType.Usable);

            bool result = shop.AddItemToList(addedItem);

            result.Should().BeTrue("the action of removing the item should have been successful.");
            shop.ItemList.Should().Contain(addedItem);
            shop.Gold.Should().Be(600, "the gold value of Item 3 should have been removed from the 700 remaining gold of the shop when Item 3 was added.");
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldBeAbleToRemoveAnItemFromList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            
            bool result = shop.RemoveItemFromList("Item 1");

            result.Should().BeTrue("the action of removing the item should have been successful.");
            shop.ItemList.Should().NotContain(x => x.Name == "Item 1");
            shop.Gold.Should().Be(800, "the gold value of Item 1 should have been returned to the shops total gold when Item 1 was removed.");
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldReturnFailResultWhenFailingToRemoveAnItem()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);

            bool result = shop.RemoveItemFromList("No Item");

            result.Should().BeFalse("RemoveItemFromList should not return true when it wasn't able to find an item in it's list of items");
            shop.ItemList.Count().Should().Be(2, "no item should have been removed from the list since the item wasn't in the list in the first place.");
        }

        [TestMethod]
        [TestCategory("Shop")]
        public void ShopShouldReturnFailResultWhenItemCostsMoreThanItCanAfford()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            var expensiveItem = new Item(TestItem, 1000, ItemType.Key);

            var result = shop.AddItemToList(expensiveItem);

            result.Should().BeFalse("if the item costs more gold than the shop has available, it can't buy the item");
            shop.ItemList.Should().NotContain(expensiveItem);
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

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}

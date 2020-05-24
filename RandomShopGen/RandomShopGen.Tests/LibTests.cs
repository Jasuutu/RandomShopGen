using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RandomShopGen.Lib;
using RandomShopGen.Lib.Models;
using RandomShopGen.Tests.Mocks;
using RandomShopGen.Tests.TestData;

namespace RandomShopGen.Tests
{
    [TestFixture]
    public class LibTests
    {
        private const string TestItem = "Test Item";
        private const string TestShop = "Test Shop";
        private const string TestOwner = "TestOwner";
        private const string ValidFilePath = "C:\\testPath";
        private const int ItemValue100 = 100;
        private const int ShopGold1000 = 1000;
        private const string LongString = "bmpynpibcxyfhcbrxyosaivthjdrpooibjlfirsykubvkmoyxfqynftfhmedknpdlkvjpepugmhvthigcrbwbitbdpgkmgnplnedvqgnpbqstqvgdnzlpcqircixcpawfcrtbfpmchralzadiyxhfskbgbrtcjuyflbrgiebrgaxbptuumiktldxnusijbbpvxhwfousarefarfkigfqbggsztiqwdunbyfkzk";

        [Test]
        [Category("Item")]
        public void ItemWillNotThrowExceptionWhenGivenProperValues()
        {
            Item item = null;

            Action act = () => { item = new Item(TestItem, ItemValue100, ItemType.Usable); };
            
            act.Should().NotThrow<ArgumentException>("a valid name and valid value were provided.");
            item.Should().NotBeNull("item should have been constructed correctly.");
        }

        [Test]
        [Category("Item")]
        public void ItemWillThrowExceptionWhenGivenIncorrectValues()
        {
            var itemName = string.Empty;
            Item item = null;

            item = new Item(itemName, ItemValue100, ItemType.Usable);
            
            ValidateModel(item).Should().Contain(v => v.MemberNames.Contains("Name") &&
                                                      v.ErrorMessage.Contains("required"));
        }

        [Test]
        [Category("Shop")]
        public void ShopShouldHaveNameWhenValidValuesAreProvided()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);

            shop.Name.Should().Be("Test Shop");
            shop.Gold.Should().Be(700);
            shop.ItemList.Count().Should().Be(2);
        }

        [Test]
        [Category("Shop")]
        public void ShopShouldBeAbleToAddItemToList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            var addedItem = new Item("Item 3", ItemValue100, ItemType.Usable);

            bool result = shop.AddItemToList(addedItem);

            result.Should().BeTrue("the action of removing the item should have been successful.");
            shop.ItemList.Should().Contain(addedItem);
            shop.Gold.Should().Be(600, "the gold value of Item 3 should have been removed from the 700 remaining gold of the shop when Item 3 was added.");
        }

        [Test]
        [Category("Shop")]
        public void ShopShouldBeAbleToRemoveAnItemFromList()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            
            bool result = shop.RemoveItemFromList("Item 1");

            result.Should().BeTrue("the action of removing the item should have been successful.");
            shop.ItemList.Should().NotContain(x => x.Name == "Item 1");
            shop.Gold.Should().Be(800, "the gold value of Item 1 should have been returned to the shops total gold when Item 1 was removed.");
        }

        [Test]
        [Category("Shop")]
        public void ShopShouldReturnFailResultWhenFailingToRemoveAnItem()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);

            bool result = shop.RemoveItemFromList("No Item");

            result.Should().BeFalse("RemoveItemFromList should not return true when it wasn't able to find an item in it's list of items");
            shop.ItemList.Count().Should().Be(2, "no item should have been removed from the list since the item wasn't in the list in the first place.");
        }

        [Test]
        [Category("Shop")]
        public void ShopShouldReturnFailResultWhenItemCostsMoreThanItCanAfford()
        {
            var shop = new Shop(TestShop, ShopGold1000, ItemData.BasicItemList);
            var expensiveItem = new Item(TestItem, 1000, ItemType.Key);

            var result = shop.AddItemToList(expensiveItem);

            result.Should().BeFalse("if the item costs more gold than the shop has available, it can't buy the item");
            shop.ItemList.Should().NotContain(expensiveItem);
        }

        [Test]
        [Category(nameof(ShopRequest))]
        public void ShopRequestShouldValidateShopNameIsValid()
        {
            var shopRequest = new ShopRequest(new MemoryItemExtractor())
            {
                ShopName = null, OwnerName = TestOwner, StartingGold = ShopGold1000, ItemsFilePath = ValidFilePath
            };

            ValidateModel(shopRequest).Should().Contain(v => v.MemberNames.Contains("ShopName") &&
                                                                       v.ErrorMessage.Contains("required"));

            shopRequest.ShopName = LongString;

            ValidateModel(shopRequest).Should().Contain(v => v.MemberNames.Contains("ShopName") &&
                                                             v.ErrorMessage.Contains("ShopName can't be longer than 64 characters."));

            shopRequest.ShopName = TestShop;

            ValidateModel(shopRequest).Should().BeEmpty("because a valid ShopRequest should throw no errors");
        }

        [Test]
        [Category(nameof(ShopRequest))]
        public void ShopRequestShouldValidateShopOwnerIsValid()
        {
            var shopRequest = new ShopRequest(new MemoryItemExtractor())
            {
                ShopName = TestShop, OwnerName = null, StartingGold = ShopGold1000, ItemsFilePath = ValidFilePath
            };

            ValidateModel(shopRequest).Should().Contain(v => v.MemberNames.Contains("OwnerName") &&
                                                             v.ErrorMessage.Contains("required"));

            shopRequest.OwnerName = LongString;

            ValidateModel(shopRequest).Should().Contain(v => v.MemberNames.Contains("OwnerName") &&
                                                             v.ErrorMessage.Contains("OwnerName can't be longer than 64 characters."));

            shopRequest.OwnerName = TestShop;

            ValidateModel(shopRequest).Should().BeEmpty("because a valid ShopRequest should throw no errors");
        }

        [Test]
        [Category(nameof(ShopRequest))]
        public void ShopRequestBuildShopShouldReturnShop()
        {
            var shopRequest = new ShopRequest(new MemoryItemExtractor())
            {
                ShopName = TestShop, OwnerName = TestOwner, StartingGold = ShopGold1000, ItemsFilePath = ValidFilePath
            };

            shopRequest.BuildShopFromRequest().Should().NotBeNull("because ShopRequests should return shops.");
        }

        [Test]
        [Category("JsonConversion")]
        [Category("LocalOnly")]
        public void ItemExtractorShouldReadTestFileCorrectly()
        {
            var filePath = @"c:\TestItems.json";
            var extractor = new JsonExtractor();

            var itemsList = extractor.ConvertFileToItemsCollection(filePath).ToList();

            itemsList.Any().Should().BeTrue();
            itemsList.FirstOrDefault().Should().NotBeNull();
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

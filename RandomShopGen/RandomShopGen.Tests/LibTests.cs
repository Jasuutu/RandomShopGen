using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomShopGen.Lib;

namespace RandomShopGen.Tests
{
    [TestClass]
    public class LibTests
    {
        [TestMethod]
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
    }
}

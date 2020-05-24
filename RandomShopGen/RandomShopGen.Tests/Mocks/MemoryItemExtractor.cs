using System.Collections.Generic;
using RandomShopGen.Lib;
using RandomShopGen.Lib.Interfaces;
using RandomShopGen.Lib.Models;
using RandomShopGen.Tests.TestData;

namespace RandomShopGen.Tests.Mocks
{
    public class MemoryItemExtractor : IItemsExtractor

    {
        public IEnumerable<Item> ConvertFileToItemsCollection(string filePath)
        {
            return ItemData.BasicItemList;
        }
    }
}
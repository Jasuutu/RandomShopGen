using System.Collections.Generic;
using RandomShopGen.Lib.Models;

namespace RandomShopGen.Lib.Interfaces
{
    public interface IItemsExtractor
    {
        IEnumerable<Item> ConvertFileToItemsCollection(string filePath);
    }
}
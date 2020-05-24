using System.Collections.Generic;

namespace RandomShopGen.Lib.Interfaces
{
    public interface IItemsExtractor
    {
        IEnumerable<Item> ConvertFileToItemsCollection(string filePath);
    }
}
using System.Collections.Generic;
using System.Text.Json;
using RandomShopGen.Lib.Interfaces;
using RandomShopGen.Lib.Models;

namespace RandomShopGen.Lib
{
    public class JsonExtractor : IItemsExtractor
    {
        public IEnumerable<Item> ConvertFileToItemsCollection(string itemString)
        {
            return JsonSerializer.Deserialize<IEnumerable<Item>>(itemString);
        }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using RandomShopGen.Lib.Interfaces;
using RandomShopGen.Lib.Models;

namespace RandomShopGen.Lib
{
    public class JsonExtractor : IItemsExtractor
    {
        public IEnumerable<Item> ConvertFileToItemsCollection(string itemString)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(itemString);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RandomShopGen.Lib.Interfaces;
using RandomShopGen.Lib.Models;

namespace RandomShopGen.Lib
{
    public class JsonExtractor : IItemsExtractor
    {
        public IEnumerable<Item> ConvertFileToItemsCollection(string filePath)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(File.ReadAllText(filePath));
        }
    }
}
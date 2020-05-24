using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RandomShopGen.Lib
{
    public class ItemsExtractor
    {
        public IEnumerable<Item> ConvertFileToItemsCollection(string filePath)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(File.ReadAllText(filePath));
        }
    }
}
using System.IO;
using Newtonsoft.Json;

namespace RandomShopGen.Lib
{
    public class ItemsExtractor
    {
        public ItemList ConvertFileToItemsCollection(string filePath)
        {
            return JsonConvert.DeserializeObject<ItemList>(File.ReadAllText(filePath));
        }
    }
}
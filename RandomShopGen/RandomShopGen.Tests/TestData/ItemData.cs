using System.Collections.Generic;
using RandomShopGen.Lib;

namespace RandomShopGen.Tests.TestData
{
    public class ItemData
    {
        public static List<Item> BasicItemList = new List<Item>
        {
            new Item("Item 1", 100, ItemType.Usable),
            new Item("Item 2", 200, ItemType.Wearable | ItemType.Usable)
        };
    }
}
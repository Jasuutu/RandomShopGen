using System.Collections.Generic;
using RandomShopGen.Lib;

namespace RandomShopGen.Tests.TestData
{
    public class ItemData
    {
        public static List<Item> BasicItemList = new List<Item>
        {
            new Item("Test 1", 100),
            new Item("Test 2", 200)
        };
    }
}
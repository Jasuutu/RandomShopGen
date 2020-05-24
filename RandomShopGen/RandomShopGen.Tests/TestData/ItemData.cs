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

        public static string ItemListJsonString = @"
[
  {
    ""Name"": ""Item 1"",
    ""Value"": 100
  },
  {
    ""Name"": ""Item 2"",
    ""Value"": 200
  },
  {
    ""Name"": ""Item 3"",
    ""Value"": 300
  },
  {
    ""Name"": ""Item 4"",
    ""Value"": 400
  },
  {
    ""Name"": ""Item 5"",
    ""Value"": 500
  },
  {
    ""Name"": ""Item 6"",
    ""Value"": 600
  },
  {
    ""Name"": ""Item 7"",
    ""Value"": 700
  },
  {
    ""Name"": ""Item 8"",
    ""Value"": 800
  },
  {
    ""Name"": ""Item 9"",
    ""Value"": 900
  },
  {
    ""Name"": ""Item 10"",
    ""Value"": 1000
  }
]";
    }
}
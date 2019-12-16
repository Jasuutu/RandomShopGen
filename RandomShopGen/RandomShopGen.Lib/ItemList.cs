using System.Collections.Generic;

namespace RandomShopGen.Lib
{
    public class ItemList 
    {
        public ItemList(List<Item> itemList)
        {
            Items = itemList;
        }
        
        public List<Item> Items { get; set; }
    }
}
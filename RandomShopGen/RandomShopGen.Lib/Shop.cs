using System.Collections.Generic;
using System.Linq;
using RandomShopGen.Lib.Interfaces;

namespace RandomShopGen.Lib
{
    public class Shop : IShop
    {
        private List<Item> itemList;
        private string name;
        private int gold;
        
        public Shop(string name, int gold, IEnumerable<Item> items)
        {
            itemList = items.ToList();
            this.name = name;
            this.gold = gold;
        }

        public string Name => name;

        public int Gold => gold;

        public IEnumerable<Item> ItemList => itemList;

        public void AddItemToList(Item item)
        {
            itemList.Add(item);
        }

        public bool RemoveItemFromList(string itemName)
        {
            Item itemToRemove = itemList.FirstOrDefault(x => x.Name == itemName);

            if (itemToRemove == null) return false;
            itemList.Remove(itemToRemove);
            gold += itemToRemove.Value;
            return true;
        }
    }
}
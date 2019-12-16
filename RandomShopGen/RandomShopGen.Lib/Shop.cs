using System.Collections.Generic;
using System.Linq;
using RandomShopGen.Lib.Interfaces;

namespace RandomShopGen.Lib
{
    public class Shop : IShop
    {
        private readonly List<Item> itemList;
        private readonly int startingGold;
        private int itemsValue;

        public Shop(string name, int gold, IEnumerable<Item> items)
        {
            itemList = items.ToList();
            itemsValue = itemList.Sum(item => item.Value);
            this.Name = name;
            this.startingGold = gold;
        }

        public string Name { get; set; }

        public int Gold => startingGold - itemsValue;

        public IEnumerable<Item> ItemList => itemList;

        public bool AddItemToList(Item item)
        {
            // Do not add the item to the list if the shop can't afford the item.
            if (Gold - item.Value <= 0) return false;

            // Add the item to the list and adjust the total value of all the items to reflect the change.
            itemsValue += item.Value;
            itemList.Add(item);
            return true;

        }

        public bool RemoveItemFromList(string itemName)
        {
            // If we can't find the item in the list of items, we can't remove it.
            Item itemToRemove = itemList.FirstOrDefault(x => x.Name == itemName);
            if (itemToRemove == null) return false;

            // Remove the item from the list and adjust the totals.
            itemsValue -= itemToRemove.Value;
            itemList.Remove(itemToRemove);
            return true;
        }
    }
}
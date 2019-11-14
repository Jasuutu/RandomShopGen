using System.Collections.Generic;
using RandomShopGen.Lib.Interfaces;

namespace RandomShopGen.Lib
{
    public class Shop : IShop
    {
        private List<Item> itemList;
        private string name;
        private int gold;
        
        public Shop(string name, int gold)
        {
            itemList = new List<Item>();
            this.name = name;
            this.gold = gold;
        }

        public string Name => name;

        public int Gold => gold;
        
        // take formatted data file and create items for itemList
        public bool CreateItemList(string fileLocation)
        {
            return false;
        }

        // create output file for the shop and save to the disk
        public bool CreateShopFile(string fileLocation)
        {
            return false;
        }
    }
}
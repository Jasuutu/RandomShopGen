namespace RandomShopGen.Lib.Interfaces
{
    public interface IShop
    {
        void AddItemToList(Item item);
        bool RemoveItemFromList(string itemName);
    }
}
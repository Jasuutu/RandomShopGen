namespace RandomShopGen.Lib.Interfaces
{
    public interface IShop
    {
        bool AddItemToList(Item item);
        bool RemoveItemFromList(string itemName);
    }
}
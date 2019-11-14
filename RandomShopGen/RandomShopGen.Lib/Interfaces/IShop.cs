namespace RandomShopGen.Lib.Interfaces
{
    public interface IShop
    {

        /// <summary>
        /// Creates the item list based on a csv file.
        /// </summary>
        /// <param name="fileLocation">The location of the csv file.</param>
        /// <returns>Tells if the method was successful or not.</returns>
        bool CreateItemList(string fileLocation);

        /// <summary>
        /// Creates a file based on the list of items in the shop.
        /// </summary>
        /// <param name="fileLocation">The location where the file should be dropped.</param>
        /// <returns>Tells if the method was successful or not.</returns>
        bool CreateShopFile(string fileLocation);
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RandomShopGen.Lib.Interfaces;

namespace RandomShopGen.Lib
{
    public class ShopRequest
    {
        private IItemsExtractor extractor; 

        public ShopRequest(IItemsExtractor extractor)
        {
            this.extractor = extractor;
            ShopName = string.Empty;
            OwnerName = string.Empty;
            ItemsFilePath = string.Empty;
            //Items = new List<Item>();
        }

        [Required]
        [StringLength(64, ErrorMessage = "ShopName can't be longer than 64 characters.")]
        public string ShopName { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "OwnerName can't be longer than 64 characters.")]
        public string OwnerName { get; set; }

        public int StartingGold { get; set; } 

        public string? Description { get; set; }

        [Required]
        public string ItemsFilePath { get; set; }

        //[Required]
        //[ListCountMin(1, ErrorMessage = "Must have at least 1 item.")]
        //[ValidateComplexType]
        //public List<Item> Items { get; set; }

        public Shop BuildShopFromRequest()
        {
            var itemList = extractor.ConvertFileToItemsCollection(ItemsFilePath);

            var shop = new Shop(ShopName, StartingGold, itemList);

            return shop;
        }
    }
}
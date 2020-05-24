using System;
using System.ComponentModel.DataAnnotations;

namespace RandomShopGen.Lib
{
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="itemType">Type of the item.</param>
        public Item(string name, int value, ItemType itemType)
        {
            //if(string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            this.Name = name;
            this.Value = value;
            this.ItemType = itemType;
        }

        public Item()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [Required]
        [Range(1, 100000, ErrorMessage = "Valid gold range: 1 - 100000")]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        [ItemTypeRequired]
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets the item tier.
        /// </summary>
        /// <value>
        /// The item tier.
        /// </value>
        [Range(1, 10, ErrorMessage = "Valid Item Tier range: 1 - 10")]
        public int? ItemTier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the reference location.
        /// </summary>
        /// <value>
        /// The reference location.
        /// </value>
        public string? ReferenceLocation { get; set; }
    }

    [Flags]
    public enum ItemType
    {
        None = 0,
        Consumable = 1,
        Usable = 2,
        Wearable = 4,
        Chargeable = 8,
        Key = 16
    }
}

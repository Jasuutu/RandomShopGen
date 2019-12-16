using System;

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
            if(string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            this.Name = name;
            this.Value = value;
            this.ItemType = itemType;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Gets or sets the item tier.
        /// </summary>
        /// <value>
        /// The item tier.
        /// </value>
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
}

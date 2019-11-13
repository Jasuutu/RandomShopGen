using System;

namespace RandomShopGen.Lib
{
    public class Item
    {
        private readonly string name;
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public Item(string name, int value)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => name;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value => value;
    }
}

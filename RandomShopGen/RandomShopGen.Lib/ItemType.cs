using System;

namespace RandomShopGen.Lib
{
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
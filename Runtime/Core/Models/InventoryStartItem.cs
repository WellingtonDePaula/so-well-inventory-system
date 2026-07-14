using System;
using UnityEngine;
using SoWell.Inventory.Items;

namespace SoWell.Inventory.Core.Models {
    [Serializable]
    public class InventoryStartItem {
        public ItemData Item;

        [Min(0)]
        public int Quantity = 1;
    }
}

using System;
using UnityEngine;
using Wellz.Inventory.Items;

namespace Wellz.Inventory.Core.Models {
    [Serializable]
    public class InventoryStartItem {
        public ItemData Item;

        [Min(0)]
        public int Quantity = 1;
    }
}

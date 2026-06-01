using UnityEngine;
using Wellz.Inventory.Items;

namespace Wellz.Inventory.Core.Interfaces {
    public interface ISlot {
        ItemData Item { get; }
        int Quantity { get; }
        bool IsEmpty { get; }
        int MaxStackSize { get; }
        Vector2Int GridPosition { get; }

        bool TryAddItem(ItemData item, int quantity = 1);
        bool TryRemoveItem(int quantity = 1);
        void SwapWith(ISlot other);
        void Clear();

    }
}
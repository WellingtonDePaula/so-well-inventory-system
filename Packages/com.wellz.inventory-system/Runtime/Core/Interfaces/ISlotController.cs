using UnityEngine;
using Wellz.Inventory.Core.Controllers;
using Wellz.Inventory.Items;

namespace Wellz.Inventory.Core.Interfaces {
    public interface ISlotController {
        Vector2Int GridPos { get; set; }

        void CreateSlot(Vector2Int gridPos);
        bool SwapSlot(SlotControllerBase slot);
        bool SwapItem(ItemData item);
        int AddItem(ItemData item, int quantity = 1);
        int RemoveItem(ItemData item, int quantity = 1);
        void Setup(ItemData item = null, int quantity = 0);
        void FocusSlot(bool hover);
        void SelectSlot(bool select);
        bool ContainsScreenPoint(Vector2 screenPoint, Camera eventCamera);
    }
}
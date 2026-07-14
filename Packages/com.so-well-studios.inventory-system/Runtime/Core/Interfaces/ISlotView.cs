using UnityEngine;
using UnityEngine.UI;
using SoWell.Inventory.Items;

namespace SoWell.Inventory.Core.Interfaces {
    public interface ISlotView : IInteractable {
        public void SetupView(ItemData data, int quantity);
        public void RefreshView(ItemData data, int quantity);
        public void Clear();
    }
}
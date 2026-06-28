using UnityEngine;
using Wellz.Inventory.Input;
using Wellz.Utils.Core;

namespace Wellz.Inventory.Core.Controllers {
    public class InventoryController : InventoryControllerBase {
        // Campos estáticos e constantes

        // Campos expostos no Inspector

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe

        #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)
        private void Awake() {
            inventoryGrid = new GenericGrid<SlotControllerBase>(width, height, 1, default, (grid, x, y) => {
                var slot = Instantiate(slotPrefab, slotsTransform).GetComponent<SlotController>();
                slot.CreateSlot(new Vector2Int(x, y));
                return slot;
            });
            InitializeItems();
        }
        #endregion

        #region Métodos públicos e privados da lógica da classe
        protected override void HandleOnPressed() {
            if (currentHoverSlot == null) {
                return;
            }

            bool clickedSameSlot = (currentSelectedSlot == currentHoverSlot);

            currentSelectedSlot?.SelectSlot(false);
            currentSelectedSlot = null;

            if (!clickedSameSlot) {
                currentHoverSlot.SelectSlot(true);
                currentSelectedSlot = currentHoverSlot;
            }
        }
        protected override void HandleOnReleased() {
            //throw new NotImplementedException();
        }
        protected override void HandleOnOtherReleased() {
            //throw new NotImplementedException();
        }

        protected override void HandleOnOtherPressed() {
            if (currentSelectedSlot == null) { return; }
            currentSelectedSlot.AddItem(currentSelectedSlot.Item, 1);
        }
        protected override void HandleOnPositionChanged(Vector2 pos) {
            SlotControllerBase slotUnder = null;
            inventoryGrid.ForEach((x, y, slot) => {
                if (RectTransformUtility.RectangleContainsScreenPoint(slot.RectTransform, pos)) {
                    slotUnder = slot;
                }
            });

            if (slotUnder != currentHoverSlot) {
                if (currentHoverSlot != null) {
                    currentHoverSlot.FocusSlot(false);
                }

                currentHoverSlot = slotUnder;

                if (currentHoverSlot != null) {
                    currentHoverSlot.FocusSlot(true);
                }
            }
        }
    }
        #endregion
}
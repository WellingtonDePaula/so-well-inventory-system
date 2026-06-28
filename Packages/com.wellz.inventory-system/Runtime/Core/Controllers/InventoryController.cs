using UnityEngine;
using Wellz.Inventory.Input;
using Wellz.Utils.Core;

namespace Wellz.Inventory.Core.Controllers {
    public class InventoryController : MonoBehaviour {
        // Campos estáticos e constantes

        // Campos expostos no Inspector
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] int width;
        [SerializeField] int height;
        [SerializeField] Transform slotsTransform;

        [SerializeField] InputProvider inputProvider;

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe
        private SlotController currentHoverSlot = null;
        private SlotController currentSelectedSlot = null;
        private GenericGrid<SlotController> inventoryGrid;

        #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)
        private void Awake() {
            inventoryGrid = new GenericGrid<SlotController>(width, height, 1, default, (grid, x, y) => {
                var slot = Instantiate(slotPrefab, slotsTransform).GetComponent<SlotController>();
                slot.transform.localPosition = new Vector3(x, y, 0);
                return slot;
            });
        }

        private void OnEnable() {
            if (inputProvider != null) {
                inputProvider.Activate();
                inputProvider.OnPressed += HandleOnPressed;
                inputProvider.OnReleased += HandleOnReleased;

                inputProvider.OnOtherPressed += HandleOnOtherPressed;
                inputProvider.OnOtherReleased += HandleOnOtherReleased;
                inputProvider.OnPositionChanged += HandleOnPositionChanged;
            }
        }

        private void OnDisable() {
            if (inputProvider != null) {
                inputProvider.OnPressed -= HandleOnPressed;
                inputProvider.OnReleased -= HandleOnReleased;

                inputProvider.OnOtherPressed -= HandleOnOtherPressed;
                inputProvider.OnOtherReleased -= HandleOnOtherReleased;
                inputProvider.OnPositionChanged -= HandleOnPositionChanged;
                inputProvider.Deactivate();
            }
        }
        #endregion

        #region Métodos públicos e privados da lógica da classe
        private void HandleOnPressed() {
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
        private void HandleOnReleased() {
            //throw new NotImplementedException();
        }
        private void HandleOnOtherReleased() {
            //throw new NotImplementedException();
        }

        private void HandleOnOtherPressed() {
            if (currentSelectedSlot == null) { return; }
            currentSelectedSlot.AddItem(currentSelectedSlot.Item, 1);
        }
        private void HandleOnPositionChanged(Vector2 pos) {
            SlotController slotUnder = null;
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
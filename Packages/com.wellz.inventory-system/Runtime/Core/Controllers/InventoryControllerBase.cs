using UnityEngine;
using Wellz.Inventory.Input;
using Wellz.Utils.Core;

namespace Wellz.Inventory.Core.Controllers {
    public abstract class InventoryControllerBase : MonoBehaviour {
        // Campos estáticos e constantes

        // Campos expostos no Inspector
        [SerializeField] protected GameObject slotPrefab;
        [SerializeField] protected int width;
        [SerializeField] protected int height;
        [SerializeField] protected Transform slotsTransform;

        [SerializeField] protected InputProvider inputProvider;

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe
        protected SlotController currentHoverSlot = null;
        protected SlotController currentSelectedSlot = null;
        protected GenericGrid<SlotController> inventoryGrid;

        #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)
        protected virtual void Awake() {
            inventoryGrid = new GenericGrid<SlotController>(width, height, 1, default, (grid, x, y) => {
                var slot = Instantiate(slotPrefab, slotsTransform).GetComponent<SlotController>();
                slot.transform.localPosition = new Vector3(x, y, 0);
                return slot;
            });
        }

        protected virtual void OnEnable() {
            if (inputProvider != null) {
                inputProvider.Activate();
                inputProvider.OnPressed += HandleOnPressed;
                inputProvider.OnReleased += HandleOnReleased;

                inputProvider.OnOtherPressed += HandleOnOtherPressed;
                inputProvider.OnOtherReleased += HandleOnOtherReleased;

                inputProvider.OnPositionChanged += HandleOnPositionChanged;
            }
        }

        protected virtual void OnDisable() {
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
        protected abstract void HandleOnPressed();
        protected abstract void HandleOnReleased();

        protected abstract void HandleOnOtherReleased();
        protected abstract void HandleOnOtherPressed();

        protected abstract void HandleOnPositionChanged(Vector2 pos);
    }
        #endregion
}
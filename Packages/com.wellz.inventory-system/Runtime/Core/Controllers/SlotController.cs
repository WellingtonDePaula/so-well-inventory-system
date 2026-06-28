using System;
using UnityEngine;
using Wellz.Inventory.Core.Interfaces;
using Wellz.Inventory.Core.Models;
using Wellz.Inventory.Input;
using Wellz.Inventory.Items;
using Wellz.Utils.Core;

namespace Wellz.Inventory.Core.Controllers {
    [RequireComponent(typeof(ISlotView))]
    public class SlotController : SlotControllerBase {
        // Campos estáticos e constantes

        // Campos expostos no Inspector

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe


        #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)
        #endregion

        #region Métodos públicos e privados da lógica da classe

        public override int RemoveItem(ItemData item, int quantity = 1) {
            int remainder = model.RemoveItem(item, quantity);
            return remainder;
        }
        public override int AddItem(ItemData item, int quantity = 1) {
            return model.AddItem(item, quantity);
        }

        public override bool SwapItem(ItemData item) {
            bool swapped = model.SetItem(item);
            view.SwapItem(item, model.Quantity);
            return swapped;
        }

        public override bool SwapSlot(ISlotController slot) {
            if (slot == null) {
                return false;
            }
            if (ReferenceEquals(this, slot)) {
                return false;
            }

            Vector2Int tempPos = this.gridPos;

            this.gridPos = slot.GridPos;

            slot.GridPos = tempPos;

            return true;
        }

        public override void Setup(ItemData item = null, int quantity = 0) {
            model = new SlotModel(item, quantity);

            model.OnQuantityChanged += HandleModelChanged;

            view.SetupView(model.Item, model.Quantity);
        }
        protected override void HandleModelChanged() {
            view.RefreshView(model.Item, model.Quantity);
        }

        public override void FocusSlot(bool hover) {
            isFocused = hover;
            if (isSelected) { return; }

            if (hover) {
                view.FocusStarted();
                return;
            }
            view.FocusEnded();
        }

        public override void SelectSlot(bool select) {
            isSelected = select;

            if (select) {
                view.Select();
                return;
            }
            view.Deselect();
            if (isFocused) {
                view.FocusStarted();
            }
        }
        #endregion


    }
}
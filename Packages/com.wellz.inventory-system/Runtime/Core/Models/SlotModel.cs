using System;
using UnityEngine;
using Wellz.Inventory.Core.Interfaces;
using Wellz.Inventory.Items;

namespace Wellz.Inventory.Core.Models {
    public class SlotModel : ISlot {
        // Campos estáticos e constantes

        // Campos privados para o estado interno da classe
        private ItemData item;
        private int quantity;
        private int maxStackSize;
        private Vector2Int gridPos;

        // Propriedades para acesso controlado externo

        // Construtores

        public ItemData Item => item;

        public int Quantity => quantity;

        public bool IsEmpty {
            get {
                if (item.IsPermanentSlot) {
                    return quantity <= 0;
                }
                return item == null;

            }
        }

        public int MaxStackSize => maxStackSize;

        public Vector2Int GridPosition => gridPos;

        public SlotModel(ItemData item, int quantity, Vector2Int gridPos) {
            this.item = item;
            this.quantity = quantity;
            this.maxStackSize = item.MaxStackSize;
            this.gridPos = gridPos;
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public void SwapWith(ISlot other) {
            throw new NotImplementedException();
        }

        public bool TryAddItem(ItemData item, int quantity = 1) {
            throw new NotImplementedException();
        }

        public bool TryRemoveItem(int quantity = 1) {
            throw new NotImplementedException();
        }

        #region Métodos públicos e privados da lógica da classe
        #endregion
    }
}
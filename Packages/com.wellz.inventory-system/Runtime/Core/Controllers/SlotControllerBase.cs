using System;
using UnityEngine;
using Wellz.Inventory.Core.Interfaces;
using Wellz.Inventory.Core.Models;
using Wellz.Inventory.Input;
using Wellz.Inventory.Items;

namespace Wellz.Inventory.Core.Controllers {
    [RequireComponent(typeof(ISlotView))]
    public abstract class SlotControllerBase : MonoBehaviour, ISlotController {
        // Campos estáticos e constantes

        // Campos expostos no Inspector
        [SerializeField] protected RectTransform rectTransform;

        // Propriedades para acesso controlado externo
        public Vector2Int GridPos { get => gridPos; set => gridPos = value; }
        public RectTransform RectTransform => rectTransform;
        public ItemData Item => model.Item;

        // Campos privados para o estado interno da classe
        protected Vector2Int gridPos;

        protected SlotModel model;
        protected ISlotView view;

        protected bool isFocused = false;
        protected bool isSelected = false;


        #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)

        protected virtual void Awake() {
            view = GetComponent<ISlotView>();
        }

        protected virtual void OnDestroy() {
            if (model != null) {
                model.OnQuantityChanged -= HandleModelChanged;
            }
        }

        #endregion

        #region Métodos públicos e privados da lógica da classe

        public abstract int RemoveItem(ItemData item, int quantity = 1);
        public abstract int AddItem(ItemData item, int quantity = 1);

        public abstract bool SwapItem(ItemData item);

        public abstract bool SwapSlot(ISlotController slot);

        public abstract void Setup(Vector2Int gridPos, ItemData item = null, int quantity = 0);
        protected abstract void HandleModelChanged();

        public abstract void FocusSlot(bool hover);

        public abstract void SelectSlot(bool select);
        #endregion


    }
}
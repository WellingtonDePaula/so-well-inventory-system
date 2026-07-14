using System;
using UnityEngine;
using SoWell.Inventory.Core.Interfaces;
using SoWell.Inventory.Core.Models;
using SoWell.Inventory.Core.Views;
using SoWell.Inventory.Input;
using SoWell.Inventory.Items;

namespace SoWell.Inventory.Core.Controllers {
    [RequireComponent(typeof(SlotViewBase))]
    public abstract class SlotControllerBase : MonoBehaviour, ISlotController {
        // Campos estáticos e constantes

        // Campos expostos no Inspector
        [SerializeField] protected RectTransform rectTransform;

        // Propriedades para acesso controlado externo
        public Vector2Int GridPos { get => gridPos; set => gridPos = value; }
        public ItemData Item => model?.Item;
        public bool IsEmpty => model?.Item == null;
        public bool IsFocused => isFocused;
        public bool IsSelected => isSelected;
        public event Action<SlotControllerBase> OnItemEnded;

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
            UnsubscribeFromModel();
        }

        #endregion

        #region Métodos públicos e privados da lógica da classe
        public virtual void CreateSlot(Vector2Int gridPos) {
            this.gridPos = gridPos;
        }

        public abstract int RemoveItem(ItemData item, int quantity = 1);
        public abstract int AddItem(ItemData item, int quantity = 1);

        public abstract bool SwapItem(ItemData item);

        public abstract bool SwapSlot(SlotControllerBase slot);

        public abstract void Setup(ItemData item = null, int quantity = 0);
        protected abstract void HandleModelChanged(int quantity);

        public abstract void FocusSlot(bool hover);

        public abstract void SelectSlot(bool select);
        public virtual bool ContainsScreenPoint(Vector2 screenPoint, Camera eventCamera) {
            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint, eventCamera);
        }
        protected void InvokeOnItemEnded(SlotControllerBase slotController) {
            OnItemEnded?.Invoke(slotController);
        }

        // Centraliza a desinscrição do evento do model. Evita assinatura duplicada
        // quando Setup() é chamado mais de uma vez (ex.: slot reciclado em um pool)
        // e evita repetição entre OnDestroy e Setup.
        protected void UnsubscribeFromModel() {
            if (model != null) {
                model.OnQuantityChanged -= HandleModelChanged;
            }
        }
        #endregion


    }
}
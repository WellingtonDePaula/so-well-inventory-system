using UnityEngine;
using Wellz.Inventory.Core.Controllers;
using Wellz.Inventory.Items;

[RequireComponent(typeof(SlotController))]
public class SetupSlot : MonoBehaviour {
    // Campos estáticos e constantes

    // Campos expostos no Inspector
    [SerializeField] private ItemData item;
    [SerializeField] private int quantity;
    [SerializeField] private int position;

    // Propriedades para acesso controlado externo

    // Campos privados para o estado interno da classe

    #region Métodos do ciclo de vida da Unity (Awake, OnEnable, Start, OnDisable)
    private void Start() {
        SlotController controller = GetComponent<SlotController>();
        position = GameManager.SlotsCount;

        controller.CreateSlot(new Vector2Int(position, 0));
        controller.Setup(item, quantity);
        GameManager.SlotsCount ++;
    }
    #endregion

    #region Métodos públicos e privados da lógica da classe
    #endregion
}
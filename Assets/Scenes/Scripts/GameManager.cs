using UnityEngine;
using UnityEngine.UI;
using Wellz.Inventory.Core.Controllers;
using Wellz.Inventory.Items;

public class GameManager : MonoBehaviour {
    [SerializeField] private ItemData data;
    [SerializeField] private SlotController controller;
    [SerializeField] private Slider slider;
    [SerializeField] private Text response;

    public static GameManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void SetupController() {
        controller.Setup(new Vector2Int(0, 0), data, 1);

        response.text = "Setup concluido com sucesso!";
    }

    public void AddItem() {
        int remainder = controller.AddItem(data, (int) slider.value);

        response.text = $"{slider.value - remainder} adicionados; {remainder} restantes.";
    }

    public void RemoveItem() {
        int remainder = controller.RemoveItem(data, (int) slider.value);

        response.text = $"{remainder} removidos; {slider.value - remainder} restantes.";
    }

    public void SwapItem() {

    }
}

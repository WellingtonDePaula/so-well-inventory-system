using UnityEngine;
using UnityEngine.InputSystem;
using Wellz.Utils.Core;

namespace Wellz.Inventory.Input {
    [CreateAssetMenu(fileName = "MouseInputProvider", menuName = "Wellz/Inventory/InputProvider/Mouse")]
    public class MouseInputProvider : InputProvider {
        // Campos estáticos e constantes

        // Campos expostos no Inspector

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe

        #region Métodos do ciclo de vida do ScriptableObject (OnEnable, OnDisable, OnDestroy)
        #endregion

        #region Métodos públicos e privados da lógica da classe
        public override Vector2 Position() {
            return UtilsClass.GetMouseScreenPosition();
        }

        public override bool Pressed() {
            return Mouse.current.leftButton.wasPressedThisFrame;
        }

        public override bool Released() {
            return Mouse.current.leftButton.wasReleasedThisFrame;
        }
        #endregion
    }
}

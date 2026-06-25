using UnityEngine;
using Wellz.Inventory.Core.Interfaces;
namespace Wellz.Inventory.Input {
    public abstract class InputProvider : ScriptableObject, IInputProvider {
        // Campos estáticos e constantes

        // Campos expostos no Inspector

        // Propriedades para acesso controlado externo

        // Campos privados para o estado interno da classe

        #region Métodos do ciclo de vida do ScriptableObject (OnEnable, OnDisable, OnDestroy)
        #endregion

        #region Métodos públicos e privados da lógica da classe
        public abstract Vector2 Position();

        public abstract bool Pressed();

        public abstract bool Released();
        #endregion
    }
}

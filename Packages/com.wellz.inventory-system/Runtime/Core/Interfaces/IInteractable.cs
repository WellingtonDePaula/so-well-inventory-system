using System;

namespace Wellz.Inventory.Core.Interfaces {
    public interface IInteractable {
        void FocusStarted();
        void FocusEnded();
        void Select();
        void Deselect();
    }
}

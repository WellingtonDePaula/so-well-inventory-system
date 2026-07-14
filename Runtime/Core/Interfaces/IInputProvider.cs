using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SoWell.Inventory.Core.Interfaces {
    public interface IInputProvider {
        bool Pressed();
        bool Released();
        Vector2 Position();
    }
}

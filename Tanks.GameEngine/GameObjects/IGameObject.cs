using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects
{
    public interface IGameObject
    {
        int X { get; }
        int Y { get; }
        bool IsAlive { get; set; }
        GameBoard Board { get; set; }
    }
}

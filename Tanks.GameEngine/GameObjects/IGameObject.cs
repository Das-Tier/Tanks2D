using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsAlive { get; set; }
        GameBoard Board { get; set; }
    }
}

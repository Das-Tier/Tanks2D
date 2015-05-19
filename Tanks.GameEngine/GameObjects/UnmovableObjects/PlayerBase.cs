using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine.GameObjects;

namespace Tanks.GameEngine.GameObjects.UnmovableObjects
{
    public class PlayerBase:BaseGameObject
    {
        public PlayerBase(int x, int y)
            : base(x, y)
        {
            X = x;
            Y = y;
            IsAlive = true;
        }
    }
}

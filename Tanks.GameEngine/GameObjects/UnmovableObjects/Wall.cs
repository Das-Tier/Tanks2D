using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects.UnmovableObjects
{
    public class Wall:BaseGameObject
    {
        public Wall(int x, int y)
            : base(x, y)
        {
            IsAlive = true;
        }
    }
}

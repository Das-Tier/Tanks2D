using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects.UnmovableObjects
{
    public class Concrete:BaseGameObject
    {
        public Concrete(int x, int y)
            : base(x, y)
        {
            IsAlive = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects.UnmovableObjects
{
    // Review remark from IP:
    // а в чому відмінність даного класу від базового ?
    public class Wall:BaseGameObject
    {
        public Wall(int x, int y)
            : base(x, y)
        {
            IsAlive = true;
        }
    }
}

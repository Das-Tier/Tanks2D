using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects
{
    public abstract class BaseGameObject:IGameObject
    {
        public BaseGameObject(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public GameBoard Board { get; set; }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine.GameObjects;

namespace Tanks.GameEngine.GameObjects.DynamicObjects
{
    public class Enemy : BaseGameObject, IMovable
    {
        #region Properties
        private Random randomDirect { get; set; }
        public Direction Direction { get; set; }
        #endregion
               
        #region Constructor
        public Enemy(int x, int y)
            : base(x, y)
        {
            X = x;
            Y = y;
            Direction = Direction.Down;
            IsAlive = true;
            randomDirect = new Random();
        }
        #endregion

        #region Methods
        public void MoveOn()
        {
            int newX = X;
            int newY = Y;
            switch (Direction)
            {
                case Direction.Down: newY += 1; break;
                case Direction.Up: newY -= 1; break;
                case Direction.Left: newX -= 1; break;
                case Direction.Right: newX += 1; break;
            }
            if (CheckMoveOn(newX, newY)==true)
            {
                X = newX;
                Y = newY;
            }
            else
            {
                Direction = (Direction)randomDirect.Next(0, 5);
            }
        }

        public bool CheckMoveOn(int newX, int newY)
        {
            if (Board != null)
            {
                return Board.IsCorrectPosition(this, newX, newY);
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

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
        public Direction Direction { get; set; }
        Random changeDirect = new Random();
        #endregion

        #region Constructor
        public Enemy(int x, int y)
            : base(x, y)
        {
            Direction = Direction.Down;
            IsAlive = true;
            Random randomDirect = new Random();
        }
        #endregion

        #region Methods
        public void MoveOn()
        {
            int newX = X;
            int newY = Y;
            switch (Direction)
            {
                case Direction.Down: newY++; break;
                case Direction.Up: newY--; break;
                case Direction.Left: newX--; break;
                case Direction.Right: newX++; break;
            }
            if (CheckMoveOn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                Direction = (Direction)changeDirect.Next(0, 5);
            }
        }

        public bool CheckMoveOn(int newX, int newY)
        {
            // Review remark from IP:
            // можна і треба відрефакторити в один рядок !
            if (Board != null)
            {
                return this.Board.IsCorrectPosition(this, newX, newY);
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

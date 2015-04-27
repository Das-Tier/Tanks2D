using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects.DynamicObjects
{
    public class Bullet:BaseGameObject, IMovable
    {
        #region Properties
        public Direction Direction { get; set; }
        public bool OfPlayer { get; set; }
        #endregion

        #region Constructor
        public Bullet(int x, int y, Direction direction, bool ofPlayer)
            : base(x, y)
        {
            OfPlayer = ofPlayer;
            IsAlive = true;
            Direction = direction;
        }
        #endregion

        #region Methods
        public void MoveOn()
        {
            int dy = 0; int dx = 0;
            switch (Direction)
            {
                case Direction.Up: dy -= 1; break;
                case Direction.Down: dy += 1; break;
                case Direction.Left: dx -= 1; break;
                case Direction.Right: dx += 1; break;
            }
            int newX = X + dx;
            int newY = Y + dy;
            if (CheckMoveOn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

        public bool CheckMoveOn(int newX, int newY)
        {
            if (this.Board != null)
            {
                return this.Board.BulletObjectCollision(this, newX, newY);
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

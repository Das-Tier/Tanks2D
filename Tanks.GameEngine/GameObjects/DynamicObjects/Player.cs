using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks.GameEngine.GameObjects.DynamicObjects
{
    public class Player : BaseGameObject, IPlayer
    {
        #region Properties
        public Direction Direction { get; set; }
        public int Lives { get; set; }
        #endregion

        #region Constructor
        public Player(int x, int y)
            : base(x, y)
        {
            Direction = Direction.Up;
            Lives = 4;
        }
        #endregion

        #region Methods
        public void MoveOn(int dx, int dy)
        {
            if (CheckMoveOn(dx, dy) == true)
            {
                X += dx;
                Y += dy;
            }
        }

        public bool CheckMoveOn(int dx, int dy)
        {
            int newX = X + dx;
            int newY = Y + dy;
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

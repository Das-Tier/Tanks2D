using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine.GameObjects;
using Tanks.GameEngine.GameObjects.UnmovableObjects;
using Tanks.GameEngine.GameObjects.DynamicObjects;

namespace Tanks.GameEngine
{
    public class GameBoard
    {
        // Review remark from IP:
        // правила іменування приватних полів варто не змішувати з такими для локальних змінних
        private List<IGameObject> gameObjects = new List<IGameObject>();

        public IEnumerable<IGameObject> GameObjects
        {
            get { return gameObjects; }
        }

        public void AddObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
            gameObject.Board = this;
        }

        public bool CanBePlaced(IGameObject gameObject, int newX, int newY)
        {
            if (this.gameObjects.Any(r => r == gameObject) == false)
            {
                return false;
            }
            else
            {
                return IsCorrectPosition(gameObject, newX, newY);
            }
        }

        public bool IsCorrectPosition(IGameObject gameObject, int newX, int newY)
        {
            //if (this.gameObjects.Any(r => r.X == newX && r.Y == newY) == true)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            // Review remark from IP:
            // так значно лаконічніше ))
            return !this.gameObjects.Any(r => r.X == newX && r.Y == newY);
        }

        public bool BulletObjectCollision(Bullet bullet, int newX, int newY)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].X == newX && gameObjects[i].Y == newY)
                {
                    if ((gameObjects[i] is Player) && (bullet.OfPlayer == false))
                    {
                        gameObjects[i].IsAlive = false;
                    }
                    if (gameObjects[i] is Wall)
                    {
                        gameObjects[i].IsAlive = false;
                        gameObjects.Remove(this.gameObjects[i]);
                    }
                    if (gameObjects[i] is Enemy)
                    {
                        if (bullet.OfPlayer == true)
                        {
                            gameObjects[i].IsAlive = false;
                            gameObjects.Remove(this.gameObjects[i]);
                        }
                    }
                    bullet.IsAlive = false;
                    gameObjects.Remove(bullet);
                    return false;
                }
            }
            return true;
        }
    }
}



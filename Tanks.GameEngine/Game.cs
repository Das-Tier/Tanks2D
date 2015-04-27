using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine.GameObjects;
using Tanks.GameEngine.GameObjects.DynamicObjects;
using Tanks.GameEngine.GameObjects.UnmovableObjects;

namespace Tanks.GameEngine
{
    public enum GameStatus
    {
        ReadyToStart, InProgress, Completed
    }
    public class Game
    {
        public GameStatus gameStatus;
        #region Public Fields
        public int score;
        public int enemiesCount;
        public Player Player { get; set; }
        public GameBoard GameBoard { get; protected set; }
        public List<Bullet> bullets { get; set; }
        public List<Enemy> enemies { get; set; }
        public List<Wall> walls { get; set; }
        #endregion
        #region Constructor
        public Game()
        {
            gameStatus = GameStatus.ReadyToStart;
        }
        #endregion
        #region StatusMethods
        public void Start()
        {
            this.gameStatus = GameStatus.InProgress;
            score = 0;
            walls = new List<Wall>();
            enemies = new List<Enemy>();
            bullets = new List<Bullet>();
            GameBoard = new GameBoard();
            InitializeMap();
            PlayerInitialize();
            EnemyInitialize();
        }
        public bool Stop()
        {
            if (Player.Lives < 0 || enemiesCount < 0)
            {
                this.gameStatus = GameStatus.Completed;
                return true;
            }
            return false;
        }
        #endregion
        #region Helpers
        private void PlayerInitialize()
        {
            Player = new Player(7, 18);
            GameBoard.AddObject(Player);
        }
        private void EnemyInitialize()
        {
            enemiesCount = 10;
            Enemy e1 = new Enemy(7, 3);
            Enemy e2 = new Enemy(1, 1);
            Enemy e3 = new Enemy(14, 1);
            Enemy e4 = new Enemy(9, 9);
            enemies.Add(e1);
            enemies.Add(e2);
            enemies.Add(e3);
            enemies.Add(e4);
            GameBoard.AddObject(e1);
            GameBoard.AddObject(e2);
            GameBoard.AddObject(e3);
            GameBoard.AddObject(e4);
        }
        #endregion
        #region PublicGameMethods
        public bool CheckPlayerIsAlive()
        {
            if (Player.IsAlive == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public void PlayerReborn()
        {           
                Player.X = 7;
                Player.Y = 18;
                Player.Lives--;
                Player.IsAlive = true;
        }
       
        public void Fire(Player player)
        {
            Bullet b = new Bullet(player.X, player.Y, player.Direction, true);
            bullets.Add(b);
            GameBoard.AddObject(b);
        }

        public void EnemyFire(Enemy e)
        {
            Bullet b = new Bullet(e.X, e.Y, e.Direction, false);
            bullets.Add(b);
            GameBoard.AddObject(b);
        }

        public void CheckBulletsAlive()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].IsAlive == false)
                {
                    bullets.Remove(bullets[i]);
                }
            }
        }

        public void CheckEnemiesAlive()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsAlive == false)
                {
                    RaiseScore();
                    enemies.RemoveAt(i);
                    enemiesCount--;
                }
                if (enemies.Count < 4)
                {
                    AddEnemy();
                }
            }
        }
        public bool CheckWallDestruction(Wall wall)
        {
            if (wall.IsAlive == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DestructWall(Wall wall)
        {
            walls.Remove(wall);
        }

        public void AddEnemy()
        {
            Enemy e = new Enemy(14, 1);
            enemies.Add(e);
            GameBoard.AddObject(e);
        }

        public void RaiseScore()
        {
            score += 100;
        }

        public void InitializeMap()
        {
            World world = new World();
            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (World.MapArray[j, i])
                    {
                        case '1': GameBoard.AddObject(new GameObjects.UnmovableObjects.Concrete(i, j)); break;
                        case '2': Wall wall = new Wall(i, j); GameBoard.AddObject(wall); walls.Add(wall); break;
                        default: break;
                    }
                }
            }
        }
        #endregion
    }
}

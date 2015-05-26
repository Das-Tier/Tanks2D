using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine.GameObjects;
using Tanks.GameEngine.GameObjects.DynamicObjects;
using Tanks.GameEngine.GameObjects.UnmovableObjects;

namespace Tanks.GameEngine
{
    public class Game
    {
                
        #region Fields&Properties
        /*
         * ВВ: поля не повинні бути публічними.
         */
        public GameStatus gameStatus;
        public int EnemiesCount { get; set; }
        public int Score { get; set; }
        public PlayerBase PlBase { get; set; }
        public Player Player { get; set; }
        public GameBoard GameBoard { get; private set; }
        public List<Bullet> Bullets { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public List<Wall> Walls { get; private set; }

        #endregion

        #region Constructor
        
        public  Game()
        {
           gameStatus = GameStatus.ReadyToStart;
        }
        
        #endregion

        #region Public Methods

        public void Start()
        {
            gameStatus = GameStatus.InProgress;
            Score = 0;
            Walls = new List<Wall>();
            Enemies = new List<Enemy>();
            Bullets = new List<Bullet>();
            GameBoard = new GameBoard();
            InitializeMap();
            InitializePlayer();
            InitializeEnemy();
        }
       
        public bool Stop()
        {
            gameStatus = GameStatus.Completed;
            return Player.Lives < 0 || EnemiesCount < 0 || !PlBase.IsAlive;
        }

        public void AddEnemy()
        {
            Enemy e;
            if (EnemiesCount % 2 == 0)
            {
                e = new Enemy(1, 1);
            }
            else
            {
                e = new Enemy(14, 1);
            }
            Enemies.Add(e);
            GameBoard.AddObject(e);
        }
        
        public bool CheckPlayerIsAlive()
        {
            return !Player.IsAlive;            
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
            Bullets.Add(b);
            GameBoard.AddObject(b);
        }

        public void EnemyFire(Enemy e)
        {
            Bullet b = new Bullet(e.X, e.Y, e.Direction, false);
            Bullets.Add(b);
            GameBoard.AddObject(b);
        }

        public void CheckBulletsAlive()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].IsAlive == false)
                {
                    Bullets.Remove(Bullets[i]);
                }
            }
        }

        public bool CheckEnemiesAlive()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (!Enemies[i].IsAlive)
                {
                    RaiseScore();
                    Enemies.RemoveAt(i);
                    EnemiesCount--;
                    return true;
                }
                if (Enemies.Count < 4 && EnemiesCount > 2)
                {
                    AddEnemy();
                }                
            }
            return false;
        }

        public bool CheckWallDestruction(Wall wall)
        {
            return !wall.IsAlive;            
        }

        public void DestructWall(Wall wall)
        {
            Walls.Remove(wall);
        }

        public bool CheckBaseIsAlive(PlayerBase plBase)
        {
            return plBase.IsAlive;
        }

        #endregion

        #region Private Methods
       

        public void RaiseScore()
        {
            Score += 100;
        }

        private void InitializeMap()
        {
            World world = new World();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (World.MapArray[j, i])
                    {
                        case '1': GameBoard.AddObject(new Concrete(i, j)); break;
                        case '2': Wall wall = new Wall(i, j); GameBoard.AddObject(wall); Walls.Add(wall); break;
                        default: break;
                    }
                }
            }
        }

        private void InitializePlayer()
        {
            Player = new Player(7, 18);
            PlBase = new PlayerBase(9, 18);
            GameBoard.AddObject(PlBase);
            GameBoard.AddObject(Player);
        }

        private void InitializeEnemy()
        {
            EnemiesCount = 10;
            Enemy e1 = new Enemy(7, 3);
            Enemy e2 = new Enemy(1, 1);
            Enemy e3 = new Enemy(14, 1);
            Enemy e4 = new Enemy(9, 9);
            Enemies.Add(e1);
            Enemies.Add(e2);
            Enemies.Add(e3);
            Enemies.Add(e4);
            GameBoard.AddObject(e1);
            GameBoard.AddObject(e2);
            GameBoard.AddObject(e3);
            GameBoard.AddObject(e4);
        }

        #endregion
    }
}

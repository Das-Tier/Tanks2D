using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tanks.GameEngine;
using Tanks.GameEngine.GameObjects.DynamicObjects;
using Tanks.GameEngine.GameObjects.UnmovableObjects;
using Tanks.GameEngine.GameObjects;
using System.Collections.Generic;
using Tanks;

namespace GameEngineTest
{
    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            GameBoard board = new GameBoard();
            Assert.IsNotNull(board);
        }
        
        [TestMethod]
        public void CheckBaseIsAlive()
        {
            Game game = new Game();
            game.Start();
            Assert.IsTrue(game.CheckBaseIsAlive(game.PlBase));
        }
        [TestMethod]
        public void CheckEnemyMoveOn()
        {
            GameBoard board = new GameBoard();
            Enemy e = new Enemy(1, 1);
            e.MoveOn();
            Assert.IsTrue(e.X != 1 || e.Y != 1);
        }
        [TestMethod]
        public void TestAddObject()
        {
            GameBoard board = new GameBoard();
            IGameObject player = new Player(1, 1);
            board.AddObject(player);
            IGameObject lastGameObject = board.GameObjects.Last();
            Assert.AreSame(lastGameObject, player);
            Assert.AreSame(board, player.Board);
        }
        [TestMethod]
        public void CheckGameConstructor()
        {
            Game game = new Game();
            Assert.IsTrue(game.gameStatus == GameStatus.ReadyToStart);
        }
        [TestMethod]
        public void CheckGameStart()
        {
            Game game = new Game();
            game.Start();
            Assert.IsTrue(game.Score == 0);
            Assert.IsTrue(game.gameStatus == GameStatus.InProgress);
            Assert.IsNotNull(game.Bullets);
            Assert.IsNotNull(game.Enemies);
            Assert.IsNotNull(game.Player);
        }
        [TestMethod]
        public void CheckGameStop()
        {
            Game game = new Game();
            game.Start();
            game.Player.Lives =-5;
            Assert.IsTrue(game.Stop());
            Assert.IsTrue(game.gameStatus == GameStatus.Completed);
        }
        [TestMethod]
        public void CheckScore()
        {
            Game game = new Game();
            game.Start();
            game.RaiseScore();
            Assert.IsTrue(game.Score == 100);
        }
        [TestMethod]
        public void CheckFire()
        {
            Game game = new Game();
            game.Start();
            game.Fire(game.Player);
            Bullet bullet = game.Bullets.Last();
            Assert.IsTrue(game.Player.X == bullet.X && game.Player.Y == bullet.Y && game.Player.Direction == bullet.Direction);
        }
        [TestMethod]
        public void TestLoadMap()
        {
            Assert.IsNotNull(World.MapArray);
        }
        [TestMethod]
        public void TestPlayerCheckMoveOn()
        {
            GameBoard board = new GameBoard();
            Player p1 = new Player(1, 1);
            board.AddObject(p1);
            p1.MoveOn(1, 1);
            Assert.IsTrue(p1.X== 2 && p1.Y == 2);
            Assert.IsTrue(p1.CheckMoveOn(1, 1));
        }
        [TestMethod]
        public void CheckWall()
        {
            Wall wall = new Wall(1, 1);
            Assert.IsTrue(wall.IsAlive == true);
            Assert.IsNotNull(wall);
            Assert.IsTrue(wall.X == 1 && wall.Y == 1);
        }
        [TestMethod]
        public void CheckConcrete()
        {
            Wall wall = new Wall(1, 1);
            Assert.IsTrue(wall.IsAlive == true);
            Assert.IsNotNull(wall);
            Assert.IsTrue(wall.X == 1 && wall.Y == 1);
        }
        [TestMethod]
        public void CheckBullet()
        {
            GameBoard board = new GameBoard();
            Bullet bullet = new Bullet(5, 5, Direction.Down, true);
            Wall wall = new Wall(6, 5);
            Concrete concrete = new Concrete(4, 5);
            board.AddObject(concrete);
            board.AddObject(wall);
            board.AddObject(bullet);            
            Assert.IsFalse(bullet.CheckMoveOn(6, 5));
            Assert.IsFalse(bullet.CheckMoveOn(4, 5));
            Assert.IsTrue(bullet.CheckMoveOn(5, 4));
        }
        [TestMethod]
        public void CheckPlayerBullet()
        {
            GameBoard board = new GameBoard();
            Player player = new Player(5, 5);
            Bullet bullet = new Bullet(4, 5, Direction.Right, false);
            board.AddObject(player);
            board.AddObject(bullet);
            bullet.MoveOn();
            Assert.IsTrue(player.IsAlive == false);
        }
        [TestMethod]
        public void CheckBulletEnemy()
        {
            GameBoard board = new GameBoard();
            Enemy enemy = new Enemy(5, 4);
            board.AddObject(enemy);
            Bullet bullet = new Bullet(5, 5, Direction.Down, true);
            board.AddObject(bullet);
            Assert.IsFalse(bullet.CheckMoveOn(5, 4));
        }
        [TestMethod]
        public void CheckEnemyFire()
        {
            Game game = new Game();
            game.Start();
            GameBoard board = new GameBoard();
            Enemy e = new Enemy(14,1);
            game.EnemyFire(e);
            Assert.IsTrue(game.Bullets.Count != 0);
        }
        [TestMethod]
        public void CheckBulletMove()
        {
            GameBoard board = new GameBoard();
            Bullet bullet = new Bullet(5, 5,Direction.Down, true);
            board.AddObject(bullet);
            bullet.MoveOn();
            Assert.IsTrue(bullet.Y == 6);
            bullet.Direction = Direction.Up;
            bullet.MoveOn();
            Assert.IsTrue(bullet.Y == 5);
            bullet.Direction = Direction.Left;
            bullet.MoveOn();
            Assert.IsTrue(bullet.X == 4);
            bullet.Direction = Direction.Right;
            bullet.MoveOn();
            Assert.IsTrue(bullet.X == 5);
        }
        [TestMethod]
        public void CheckAddEnemy()
        {
            Game game = new Game();
            game.Start();
            int start=game.Enemies.Count;
            game.AddEnemy();
            Assert.IsTrue(game.Enemies.Count != start);
        }
        [TestMethod]
        public void CheckEnemyIsAlive()
        {
            Game game = new Game();
            game.Start();
            int start = game.Enemies.Count;
            game.Enemies[1].IsAlive = false;
            game.CheckEnemiesAlive();
            Assert.IsFalse(game.Enemies.Count == start);
            Assert.IsTrue(game.Score == 100);
        }
        [TestMethod]
        public void CheckBulletIsAlive()
        {
            Game game = new Game();
            game.Start();
            game.Bullets.Add(new Bullet(3, 3, Direction.Down, true));
            game.Bullets[0].IsAlive = false;
            game.CheckBulletsAlive();
            Assert.IsTrue(game.Bullets.Count == 0);
        }
        [TestMethod]
        public void CheckEnemyMove()
        {
            GameBoard board=new GameBoard();
            Enemy e = new Enemy(5, 5);
            board.AddObject(e);
            e.Direction = Direction.Down;
            e.MoveOn();
            Assert.IsTrue(e.X == 5 && e.Y == 6);
            e.Direction = Direction.Left;
            e.MoveOn();
            Assert.IsTrue(e.X == 4 );
            e.Direction = Direction.Up;
            e.MoveOn();
            Assert.IsTrue(e.Y == 5);
            e.Direction = Direction.Right;
            e.MoveOn();
            Assert.IsTrue(e.X == 5 && e.Y == 5);
        }
        [TestMethod]
        public void TestCheckWallDestruction()
        {
            GameBoard board = new GameBoard();
            Game game = new Game();
            Wall wall = new Wall(5,5);
            Assert.IsFalse(game.CheckWallDestruction(wall));
            wall.IsAlive = false;
            Assert.IsTrue(game.CheckWallDestruction(wall));
        }
        [TestMethod]
        public void CheckDestructWall()
        {
            Game game = new Game();
            game.Start();
            int start = game.Walls.Count;
            Wall wall = new Wall(2, 1);
            game.Walls.Add(wall);
            game.DestructWall(wall);
            Assert.IsTrue(start == game.Walls.Count);
        }
        [TestMethod]
        public void CheckPlayerReborn()
        {
            Game game = new Game();
            game.Player = new Player(1,1);
            game.Player.Lives = 3;
            game.PlayerReborn();
            Assert.IsTrue(game.Player.X == 7 && game.Player.Y == 18);
            Assert.IsTrue(game.Player.Lives == 2);
        }
        [TestMethod]
        public void CheckPlayerAlive()
        {
            Game game = new Game();
            game.Player = new Player(1, 1);
            game.Player.IsAlive = false;
            Assert.IsTrue(game.CheckPlayerIsAlive());
        }
    }
}

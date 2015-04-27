using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine;
using Tanks.GameEngine.GameObjects;

namespace Tanks.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StartScreen();
        }
        static void StartScreen()
        {
            Console.WriteLine("Hello! Please Press key for action:");
            Console.WriteLine("Enter - play game");
            Console.WriteLine("Esc - exit");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                PlayGame();
                
            }
        }

        static void PlayGame()
        {
            int countIter = 0;
            ConsoleKeyInfo key;
            Game game = new Game();
            game.Start();
            View.DrawMap(game);
            while (!game.Stop())
            {
                countIter++;
                Console.CursorVisible = false;
                #region Unrender
                View.HideEnemy(game);
                View.HideBullet(game);
                
                #endregion
                #region CheckInput
                if (Console.KeyAvailable)
                {
                    
                    View.HidePlayer(game);
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        game.Fire(game.Player);
                    }
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: game.Player.MoveOn(0, -1); game.Player.Direction = Direction.Up; break;
                        case ConsoleKey.DownArrow: game.Player.MoveOn(0, 1); game.Player.Direction = Direction.Down; break;
                        case ConsoleKey.LeftArrow: game.Player.MoveOn(-1, 0); game.Player.Direction = Direction.Left; break;
                        case ConsoleKey.RightArrow: game.Player.MoveOn(1, 0); game.Player.Direction = Direction.Right; break;
                    }
                }
                #endregion
                #region UpdatePositions
                for (int i = 0; i < game.enemies.Count; i++)
                {
                    game.enemies[i].MoveOn();
                    if (countIter % 10 == 0 && i % 2 == 0)
                    {
                        game.EnemyFire(game.enemies[i]);
                    }
                    if (countIter % 15 == 0 && i % 2 == 1)
                    {
                        game.EnemyFire(game.enemies[i]);
                    }
                }
                foreach (var i in game.bullets)
                {
                    i.MoveOn();
                }
                
                game.CheckBulletsAlive();
                game.CheckEnemiesAlive();
                
                if (game.CheckPlayerIsAlive())
                {
                    View.HidePlayer(game);
                    game.PlayerReborn();
                }
                for (int i = 0; i < game.walls.Count; i++)
                {
                    if (game.CheckWallDestruction(game.walls[i])==true)
                    {
                        View.HideWall(game.walls[i]);
                        game.walls.Remove(game.walls[i]);
                    }
                }
                #endregion
                #region Render

                View.ShowStats(game);
                View.ShowPlayer(game);
                View.ShowEnemy(game);
                View.ShowBullet(game);
                
                #endregion
                System.Threading.Thread.Sleep(120);
            }
            EndGame(game);
        }
        static void EndGame(Game game)
        {
            Console.Clear();
            Console.WriteLine("GAME OVER! Your Score is:{0}", game.score);
            Console.WriteLine("Press Return To Exit...");
            Console.ReadLine();
        }
    }
}

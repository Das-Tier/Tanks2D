using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanks.GameEngine;
using Tanks.GameEngine.GameObjects.UnmovableObjects;

namespace Tanks.ConsoleUI
{
    public static class View
    {
        #region Info
        public static void ShowStats(Game game)
        {
            Console.SetCursorPosition(24, 1);
            Console.WriteLine("Lives:{0}; Score:{1}; Enemies:{2}", game.Player.Lives, game.score, game.enemiesCount); 
        }
        #endregion
        #region MapVisaulisation
        public static void DrawMap(Game game)
        {
            foreach (var i in game.GameBoard.GameObjects)
            {
                if (i.IsAlive == true)
                {
                    ConsoleColor color = ConsoleColor.Black;
                    if (i is Tanks.GameEngine.GameObjects.UnmovableObjects.Wall)
                    {
                        color = ConsoleColor.Yellow;
                    }
                    if (i is Tanks.GameEngine.GameObjects.UnmovableObjects.Concrete)
                    {
                        color = ConsoleColor.Magenta;
                    }
                    Console.BackgroundColor = color;
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
        #endregion
        #region Show-Hide Methods
        public static void ShowBullet(Game game)
        {
            foreach (var i in game.bullets)
            {
                if (i.IsAlive == true)
                {
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write("o");
                }
            }
        }
        public static void HideWall(Wall wall)
        {
            Console.SetCursorPosition(wall.X, wall.Y);
            Console.Write(' ');
        }    
        
        public static void HideBullet(Game game)
        {
            foreach (var i in game.bullets)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');
            }
        }

        public static void HidePlayer(Game game)
        {
            Console.SetCursorPosition(game.Player.X, game.Player.Y);
            Console.Write(' ');
        }

        public static void ShowPlayer(Game game)
        {
            Console.SetCursorPosition(game.Player.X, game.Player.Y);
            Console.Write('X');
        }

        public static void HideEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');
            }
        }

        public static void ShowEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                if (i.IsAlive == true)
                {
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write("E");
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tanks.GameEngine;
using Tanks.GameEngine.GameObjects;
using Tanks.GameEngine.GameObjects.UnmovableObjects;
using Tanks.GameEngine.GameObjects.DynamicObjects;
using Tanks.DesktopUI;
using Tanks.DesktopUI.Properties;
using System.Media;

namespace DesktopUI
{
    public partial class PlayForm : Form
    {
        #region Fields

        private SoundPlayer soundPlayer; 
        private int countIter;
        //private Graphics graphics;
        private Game game;

        #endregion

        #region Constructor

        public PlayForm()
        {
            InitializeComponent();
            countIter = 0;
            soundPlayer = new SoundPlayer();
            game = new Game();
            game.Start();
            PlayStartLevelSound();
            timer.Interval = 180;
            timer.Enabled = true;
            ShowPlayer(game);
        }

        #endregion

        #region Event Handlers

        private void timer_Tick(object sender, EventArgs e)
        {            
            HideEnemy(game);
            HideBullet(game);
            for (int i = 0; i < game.enemies.Count; i++)
            {
                countIter++;
                game.enemies[i].MoveOn();
                if (countIter % 10 == 0 && i % 2 == 0)
                {
                    game.EnemyFire(game.enemies[i]);
                }
                if (countIter % 7 == 0 && i % 2 == 1)
                {
                    game.EnemyFire(game.enemies[i]);
                }
            }
            foreach (var i in game.bullets)
            {
                i.MoveOn();
            }
            game.CheckBulletsAlive();
            if (game.CheckEnemiesAlive())
            {
                PlayExplodeSound();
            }

            if (game.CheckPlayerIsAlive())
            {
                PlayExplodeSound();
                HidePlayer(game);
                game.PlayerReborn();
            }
            for (int i = 0; i < game.walls.Count; i++)
            {
                if (game.CheckWallDestruction(game.walls[i]) == true)
                {
                    HideWall(game.walls[i]);
                    game.walls.Remove(game.walls[i]);
                }
            }
            ShowPlayer(game);
            ShowEnemy(game);
            ShowBullet(game);
            ShowInfo(game);
            if (game.Stop())
            {
                GameOver();
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            menuItem_pause.Enabled = false;
            menuItem_resume.Enabled = true;
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            PlayPauseSound();
        }

        private void menuItem_resume_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            menuItem_pause.Enabled = true;
            menuItem_resume.Enabled = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            PlayPauseSound();
        }

        private void menuItem_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            StartForm s = new StartForm();
            s.Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32)
            {
                game.Fire(game.Player);
                PlayFireSound();
            }
            switch (e.KeyValue)
            {
                case 38: HidePlayer(game); game.Player.MoveOn(0, -1); game.Player.Direction = Direction.Up; break;
                case 40: HidePlayer(game); game.Player.MoveOn(0, 1); game.Player.Direction = Direction.Down; break;
                case 37: HidePlayer(game); game.Player.MoveOn(-1, 0); game.Player.Direction = Direction.Left; break;
                case 39: HidePlayer(game); game.Player.MoveOn(1, 0); game.Player.Direction = Direction.Right; break;
            }
            ShowPlayer(game);
        }

        #endregion

        #region Visualization Methods

        private void ShowInfo(Game game)
        {
            sh_enemies.Text = game.enemiesCount.ToString();
            sh_lives.Text = game.Player.Lives.ToString();
            sh_score.Text = game.score.ToString();
        }
        
        private void HideWall(Wall wall)
        {
            Graphics graphics = pbx_GameSpace.CreateGraphics();
            Bitmap img = Resources.background; 
            graphics.DrawImage(img, new Rectangle(wall.X * 30, wall.Y * 30, 30, 30));
            PlayHitWallSound();
        }

        private void ShowBullet(Game game)
        {
            foreach (var i in game.bullets)
            {
                if (i.IsAlive)
                {
                    Graphics graphics = pbx_GameSpace.CreateGraphics();
                    Bitmap img = Resources.bullet;
                    graphics.DrawImage(img, new Rectangle(i.X * 30 + 8, i.Y * 30 + 8, 10, 10));
                }
            }
        }

        private void HideBullet(Game game)
        {
            foreach (var i in game.bullets)
            {
                Graphics graphics = pbx_GameSpace.CreateGraphics();
                Bitmap img = Resources.background;
                graphics.DrawImage(img, new Rectangle(i.X * 30, i.Y * 30, 30, 30));
            }
        }

        private void ShowEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                Graphics graphics = pbx_GameSpace.CreateGraphics();
                Bitmap img = null;
                switch (i.Direction)
                {
                    case Direction.Down: img = Resources.enemy_downx30; break;
                    case Direction.Up: img = Resources.enemy_upx30; break;
                    case Direction.Right: img = Resources.enemy_rightx30; break;
                    case Direction.Left: img = Resources.enemy_leftx30; break;
                    default: img = Resources.background; break;
                }
                graphics.DrawImage(img, new Rectangle(i.X * 30, i.Y * 30, 30, 30));
            }
        }

        private void HideEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                Graphics graphics = pbx_GameSpace.CreateGraphics();
                Bitmap img = Resources.background;
                graphics.DrawImage(img, new Rectangle(i.X * 30, i.Y * 30, 30, 30));
            }
        }
        
        private void ShowPlayer(Game game)
        {
            Graphics graphics = pbx_GameSpace.CreateGraphics();
            Bitmap img = null;
            switch (game.Player.Direction)
            {
                case Direction.Up: img = Resources.tank11; break;
                case Direction.Down: img = Resources.tank21; break;
                case Direction.Left: img = Resources.tank31; break;
                case Direction.Right: img = Resources.tank41; break;
            }
            graphics.DrawImage(img, new Rectangle(game.Player.X * 30, game.Player.Y * 30, 30, 30));
        }

        private void HidePlayer(Game game)
        {
            Graphics graphics = pbx_GameSpace.CreateGraphics();
            Bitmap img = Resources.background;
            graphics.DrawImage(img, new Rectangle(game.Player.X * 30, game.Player.Y * 30, 30, 30));
        }
                
        private void pbx_GameSpace_Paint(object sender, PaintEventArgs e)
        {
            foreach (var i in game.GameBoard.GameObjects)
            {
                if (i is Wall)
                {
                    Bitmap img = Resources.wall;
                    e.Graphics.DrawImage(img, i.X * 30, i.Y * 30);
                }
                else if (i is Concrete)
                {
                    Bitmap img = Resources.concrete;
                    e.Graphics.DrawImage(img, i.X * 30, i.Y * 30);
                }
                else if (i is PlayerBase)
                {
                    Bitmap img = Resources.player_base;
                    e.Graphics.DrawImage(img, i.X * 30, i.Y * 30);
                }
            }
        }

        #endregion

        #region Sound Methods

        private void PlayFireSound()
        {
            soundPlayer.Stream = Resources.shot;
            soundPlayer.Play();
        }

        private void PlayStartLevelSound()
        {
            soundPlayer.Stream = Resources.level_start;
            soundPlayer.PlaySync();
        }

        private void PlayExplodeSound()
        {
            soundPlayer.Stream=Resources.explode;
            soundPlayer.Play();
        }

        private void PlayGameOverSound()
        {
            soundPlayer.Stream = Resources.game_over;
            soundPlayer.Play();
        }

        private void PlayHitWallSound()
        {
            soundPlayer.Stream = Resources.hit_wall;
            soundPlayer.Play();
        }

        private void PlayPauseSound()
        {
            soundPlayer.Stream = Resources.pause;
            soundPlayer.Play();
        }

        #endregion        

        #region Helpers

        private void GameOver()
        {
            timer.Enabled = false;
            this.Dispose();
            PlayGameOverSound();
            string message = "Your score is " + game.score + ". Thanks for playing!";
            MessageBox.Show(message, "GAME OVER");
            new StartForm().Show();
        }

        #endregion
    }
}
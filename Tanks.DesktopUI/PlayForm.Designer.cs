namespace DesktopUI
{
    partial class PlayForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mnstrip_game = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_pause = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_resume = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.grbx_Info = new System.Windows.Forms.GroupBox();
            this.sh_enemies = new System.Windows.Forms.Label();
            this.sh_score = new System.Windows.Forms.Label();
            this.sh_lives = new System.Windows.Forms.Label();
            this.lbl_enemies = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_lives = new System.Windows.Forms.Label();
            this.pbx_GameSpace = new System.Windows.Forms.PictureBox();
            this.mnstrip_game.SuspendLayout();
            this.grbx_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GameSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mnstrip_game
            // 
            this.mnstrip_game.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mnstrip_game.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.mnstrip_game.Location = new System.Drawing.Point(0, 0);
            this.mnstrip_game.Name = "mnstrip_game";
            this.mnstrip_game.Size = new System.Drawing.Size(738, 24);
            this.mnstrip_game.TabIndex = 1;
            this.mnstrip_game.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_pause,
            this.menuItem_resume,
            this.menuItem_exit});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // menuItem_pause
            // 
            this.menuItem_pause.Name = "menuItem_pause";
            this.menuItem_pause.Size = new System.Drawing.Size(116, 22);
            this.menuItem_pause.Text = "Pause";
            this.menuItem_pause.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // menuItem_resume
            // 
            this.menuItem_resume.Enabled = false;
            this.menuItem_resume.Name = "menuItem_resume";
            this.menuItem_resume.Size = new System.Drawing.Size(116, 22);
            this.menuItem_resume.Text = "Resume";
            this.menuItem_resume.Click += new System.EventHandler(this.menuItem_resume_Click);
            // 
            // menuItem_exit
            // 
            this.menuItem_exit.Name = "menuItem_exit";
            this.menuItem_exit.Size = new System.Drawing.Size(116, 22);
            this.menuItem_exit.Text = "Exit";
            this.menuItem_exit.Click += new System.EventHandler(this.menuItem_exit_Click);
            // 
            // grbx_Info
            // 
            this.grbx_Info.Controls.Add(this.sh_enemies);
            this.grbx_Info.Controls.Add(this.sh_score);
            this.grbx_Info.Controls.Add(this.sh_lives);
            this.grbx_Info.Controls.Add(this.lbl_enemies);
            this.grbx_Info.Controls.Add(this.lbl_score);
            this.grbx_Info.Controls.Add(this.lbl_lives);
            this.grbx_Info.Location = new System.Drawing.Point(606, 27);
            this.grbx_Info.Name = "grbx_Info";
            this.grbx_Info.Size = new System.Drawing.Size(119, 93);
            this.grbx_Info.TabIndex = 2;
            this.grbx_Info.TabStop = false;
            this.grbx_Info.Text = "Info";
            // 
            // sh_enemies
            // 
            this.sh_enemies.AutoSize = true;
            this.sh_enemies.Location = new System.Drawing.Point(56, 64);
            this.sh_enemies.Name = "sh_enemies";
            this.sh_enemies.Size = new System.Drawing.Size(13, 13);
            this.sh_enemies.TabIndex = 5;
            this.sh_enemies.Text = "0";
            // 
            // sh_score
            // 
            this.sh_score.AutoSize = true;
            this.sh_score.Location = new System.Drawing.Point(56, 39);
            this.sh_score.Name = "sh_score";
            this.sh_score.Size = new System.Drawing.Size(13, 13);
            this.sh_score.TabIndex = 4;
            this.sh_score.Text = "0";
            // 
            // sh_lives
            // 
            this.sh_lives.AutoSize = true;
            this.sh_lives.Location = new System.Drawing.Point(56, 16);
            this.sh_lives.Name = "sh_lives";
            this.sh_lives.Size = new System.Drawing.Size(13, 13);
            this.sh_lives.TabIndex = 3;
            this.sh_lives.Text = "0";
            // 
            // lbl_enemies
            // 
            this.lbl_enemies.AutoSize = true;
            this.lbl_enemies.Location = new System.Drawing.Point(6, 64);
            this.lbl_enemies.Name = "lbl_enemies";
            this.lbl_enemies.Size = new System.Drawing.Size(47, 13);
            this.lbl_enemies.TabIndex = 2;
            this.lbl_enemies.Text = "Enemies";
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Location = new System.Drawing.Point(6, 39);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(35, 13);
            this.lbl_score.TabIndex = 1;
            this.lbl_score.Text = "Score";
            // 
            // lbl_lives
            // 
            this.lbl_lives.AutoSize = true;
            this.lbl_lives.Location = new System.Drawing.Point(6, 16);
            this.lbl_lives.Name = "lbl_lives";
            this.lbl_lives.Size = new System.Drawing.Size(32, 13);
            this.lbl_lives.TabIndex = 0;
            this.lbl_lives.Text = "Lives";
            // 
            // pbx_GameSpace
            // 
            this.pbx_GameSpace.BackColor = System.Drawing.Color.Black;
            this.pbx_GameSpace.Location = new System.Drawing.Point(0, 27);
            this.pbx_GameSpace.Name = "pbx_GameSpace";
            this.pbx_GameSpace.Size = new System.Drawing.Size(600, 600);
            this.pbx_GameSpace.TabIndex = 0;
            this.pbx_GameSpace.TabStop = false;
            this.pbx_GameSpace.Paint += new System.Windows.Forms.PaintEventHandler(this.pbx_GameSpace_Paint);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 628);
            this.ControlBox = false;
            this.Controls.Add(this.grbx_Info);
            this.Controls.Add(this.pbx_GameSpace);
            this.Controls.Add(this.mnstrip_game);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnstrip_game;
            this.Name = "PlayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanks 2D";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mnstrip_game.ResumeLayout(false);
            this.mnstrip_game.PerformLayout();
            this.grbx_Info.ResumeLayout(false);
            this.grbx_Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GameSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbx_GameSpace;
        private System.Windows.Forms.MenuStrip mnstrip_game;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_pause;
        private System.Windows.Forms.ToolStripMenuItem menuItem_resume;
        private System.Windows.Forms.ToolStripMenuItem menuItem_exit;
        private System.Windows.Forms.GroupBox grbx_Info;
        private System.Windows.Forms.Label sh_enemies;
        private System.Windows.Forms.Label sh_score;
        private System.Windows.Forms.Label sh_lives;
        private System.Windows.Forms.Label lbl_enemies;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_lives;
    }
}


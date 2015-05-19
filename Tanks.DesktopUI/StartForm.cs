using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DesktopUI;
using System.Windows.Forms;

namespace Tanks.DesktopUI
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            PlayForm p = new PlayForm();
            p.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            string message = "Tanks 2D (version 1.0.0.0) \nAuthor: Vitalii Mohola \n©IT EPAM Lab, 2015";
            MessageBox.Show(message, "About");    
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            string message = "Save your base and kill all enemies\nUp: UpArrow\nDown: DownArrow\nLeft:LeftArrow\nRight: RightArrow\nFire: Spacebar";
            MessageBox.Show(message, "Help");                
        }
    }
}

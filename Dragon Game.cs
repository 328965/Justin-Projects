using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dragon_game_ACTUAL
{
    public partial class Form1 : Form
    {
        int score = 0;
        PictureBox[] rings = new PictureBox[4];
        PictureBox[] Missiles = new PictureBox[2];
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Restart();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (pic_dragon.Bounds.IntersectsWith(rings[i].Bounds) && rings[i].Visible)
                {
                    rings[i].Hide();
                    score = score + 1;  
                    score1.Text = score1.ToString();
                }
            }
            pic_dragon.Left += 7;
            if (pic_dragon.Right >= playground.Right)
            {
                pic_dragon.Left = 1;
            }
            if (score >= 4)
            {
                Endgame();
            }

            for (int i = 0; i < 4; i++)
            {
                if (Missiles[i].Bounds.IntersectsWith(pic_dragon.Bounds) && Missiles[i].Visible)
                {
                    Endgame();
                    timer1.Enabled = true;
                    tmrMissile.Enabled = false;
                    tmrMissile2.Enabled = false;
                    ringstart();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                pic_dragon.Top += 5;
            }
            else if (e.KeyCode == Keys.Up)
            {
                pic_dragon.Top -= 5;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1) { Restart(); }
        }
        public void Endgame()
        {
            lbl_end.Show();
            pic_dragon.Left = 0;
        }
        public void Restart()
        {
            lbl_end.Hide();
            timer1.Enabled = true;
            timer1.Interval = 10;
            Random r = new Random();
            pic_ring.Top = r.Next(40, playground.Height - 40);
            pic_ring.Left = r.Next(40, playground.Width - 40);
            pic_ring1.Top = r.Next(40, playground.Height - 40);
            pic_ring1.Left = r.Next(40, playground.Width - 40);
            pic_ring2.Top = r.Next(40, playground.Height - 40);
            pic_ring2.Left = r.Next(40, playground.Width - 40);
            pic_ring0.Top = r.Next(40, playground.Height - 40);
            pic_ring0.Left = r.Next(40, playground.Width - 40);
            rings[0] = pic_ring;
            rings[1] = pic_ring0;
            rings[2] = pic_ring1;
            rings[3] = pic_ring2;
            score = 0;
            score1.Text = "0";
            for (int f = 0; f < 4; f++)
            {
                rings[f].Visible = true;
            }
            r.Next(1, 100);
            ringstart();

            Missiles[0] = pic_missile;
            Missiles[1] = pic_missile2;

            for (int i = 0; i < 4; i++)
            {
                Missiles[i].Visible = false;
            }
            
            for (int i = 0; i<4; i++)
            {
                Missiles[i].Visible = true;
            }

            lbl_end.Hide();
            score = 0;
            score1.Text = "0";
            Missiles[0].Visible= true;
            Missiles[0].Left = playground.Left + 20;
            Missiles[0].Top = playground.Height - 50;
            timer1.Enabled = true;
            timer1.Interval = 10;
            tmrMissile.Enabled = true;

        }
        public void ringstart()
        {
            pic_ring.Top = r.Next(40, playground.Height - 40);
            pic_ring.Left = r.Next(40, playground.Width - 40);
            pic_ring1.Top = r.Next(40, playground.Height - 40);
            pic_ring1.Left = r.Next(40, playground.Width - 40);
            pic_ring2.Top = r.Next(40, playground.Height - 40);
            pic_ring2.Left = r.Next(40, playground.Width - 40);
            pic_ring0.Top = r.Next(40, playground.Height - 40);
            pic_ring0.Left = r.Next(40, playground.Width - 40);
            rings[0] = pic_ring;
            rings[1] = pic_ring0;
            rings[2] = pic_ring1;
            rings[3] = pic_ring2;
        }
    }
}

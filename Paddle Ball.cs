using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_2_Actual
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int point = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            racket.Top = playground.Bottom - 30;
            lbl_gameover.Hide();
            lbl_gameover.Left = playground.Width / 2 - lbl_gameover.Width / 2;
            lbl_gameover.Top = playground.Height / 2 - lbl_gameover.Height / 2;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                point = 0;
                lbl_points.Text = "0";
                ball.Top = 30;
                ball.Left = 30;
                speed_left = 4;
                speed_top = 4;
                timer1.Enabled = true;
                lbl_gameover.Hide();
                playground.BackColor = Color.White;

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                point += 1;
                lbl_points.Text = point.ToString();
                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150,255), r.Next(150, 255), r.Next(150, 255));

            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }

            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }

            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

             if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                MessageBox.Show("Game Over");
                lbl_gameover.Show();
            }
        }
    }
}

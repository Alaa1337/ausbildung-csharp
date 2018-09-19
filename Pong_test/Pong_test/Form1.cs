using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_test
{
    
    public partial class Form1 : Form
    {
        
        enum Position
        {
            Up,Down,Left,Right,Stop
        }

        Random rnd = new Random();
        int score1;
        int score2;

        private int p1x;
        private int p1y;
        private int p1form;
        private Position p1_position;

        private int p2x;
        private int p2y;
        private int p2form;
        private Position p2_position;

        private int ballx;
        private int bally;
        private Position ball_position;

        private int pwidth;
        private int pheight;
        private int ballwh;
        private int ballVX;
        private int ballVY;

        public Form1()
        {
            InitializeComponent();

            p1x = 148;
            p1y = 145;
            p1form = p1x + p1y;

            p2x = 527;
            p2y = 145;
            p2form = p2x + p2y;

            p1_position = Position.Stop;
            p2_position = Position.Stop;

            ballx = 333;
            bally = 190;

            ball_position = Position.Stop;
            pwidth = 21;
            pheight = 100;
            ballwh = 30;

            ballVX =  5;
            ballVY = 5;



            score1 = 0;
            score2 = 0;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (e.KeyCode == Keys.W)
            {
                p1_position = Position.Up;
            }
            else if (e.KeyCode == Keys.S)
            {
                p1_position = Position.Down;
            }

            if (e.KeyCode == Keys.Up)
            {
                p2_position = Position.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                p2_position = Position.Down;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, p1x, p1y, pwidth, pheight);


            e.Graphics.FillRectangle(Brushes.White, p2x, p2y, pwidth, pheight);


            e.Graphics.FillRectangle(Brushes.AliceBlue, ballx, bally, ballwh, ballwh);

        }

        private void move1_Tick(object sender, EventArgs e)
        {
            if (p1_position == Position.Up)
            {
                p1y -= 10;
            }
            else if (p1_position == Position.Down)
            {
                p1y += 10;
            }
            else if (p1_position == Position.Stop)
            {
               
            }
            
            if (p1y <= 55)
            {
                p1y = 55;
            }
            if (p1y >= 255)
            {
                p1y = 255;
            }

            if (p2_position == Position.Up)
            {
                p2y -= 10;
            }
            else if (p2_position == Position.Down)
            {
                p2y += 10;
            }
            else if (p2_position == Position.Stop)
            {
                p2y = p2y;
            }



            
            if (p2y <= 55)
            {
                p2y = 55;
            }

           if (p2y >= 255)
            {
                p2y = 255;
            }

            

            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                p1_position = Position.Stop;
            }

            if (e.KeyCode == Keys.S)
            {
                p1_position = Position.Stop;
            }

            if (e.KeyCode == Keys.Up)
            {
                p2_position = Position.Stop;
            }

            if (e.KeyCode == Keys.Down)
            {
                p2_position = Position.Stop;
            }
        }



        private void move2_Tick(object sender, EventArgs e)
        {
            if (ball_position == Position.Stop) {
                ballx += ballVX;
                bally += ballVY;
                    }

            if (bally <= 55  )
            {
                ballVY *= -1;
            }

            if (bally >= 325)
            {

                ballVY *= -1;
            }

            if (ballx < p1x+pwidth && ballx<p1y+pheight && bally+ballwh >p1y && bally <p1y+pheight && ballx>p1x-pwidth )
            {
                ballVX *= -1;

                ballVY = rnd.Next(-7, 7);
                ballVX ++;

            }

            if (ballx + ballwh > p2x && ballx>p2y+pheight && bally+ballwh >p2y && bally <p2y +pheight &&ballx+ballwh <p2x+pwidth )
            {


                ballVX *= -1;

                ballVY = rnd.Next(-7, 7);
                ballVX ++; 


               
            }



            if (ballx < 115 )
            {
                ballx = 333;
                bally = 190;
 

                score2++;
                scoretwo.Text = (""+score2);
            }
            else if ( ballx > 570)
            {
                ballx = 333;
                bally = 190;

                score1++;
                scoreone.Text = ("" + score1);
            }

            Invalidate();

        }
    }
}

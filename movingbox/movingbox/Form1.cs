using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movingbox
{
    public partial class Form1 : Form
    {

        enum Position
        {
            Left,Right,Up,Down
        }



        private int _x;
        private int _y;
        private Position _boxPosition;
        Random random = new Random();

        int x; 
            int y; 


        public Form1()
        {
            InitializeComponent();

            _x = 50;
            _y = 50;
            _boxPosition = Position.Right;

            x = random.Next(50 , 250)/10;
            y = random.Next(50 , 250)/10;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue,_x,_y,30,30 );



            e.Graphics.FillRectangle(Brushes.Violet, x , y ,30,30);
        }



        private void move_Tick(object sender, EventArgs e)
        {

            if (_boxPosition == Position.Right)
            {
                _x += 10;
            }
            else if (_boxPosition == Position.Left)
            {
                _x -= 10;
            }
            else if (_boxPosition == Position.Up)
            {
                _y -= 10;
            }
            else if (_boxPosition == Position.Down)
            {
                _y += 10;
            }


            if (_x > 270)
            {
                _x = 50;
            }
            else if (_x < 50)
            {
                _x = 270;
            }
            else if (_y > 270)
            {
                _y = 50;
            }
            else if (_y < 50)
            {
                _y = 270;
            }

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _boxPosition = Position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _boxPosition = Position.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _boxPosition = Position.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _boxPosition = Position.Down;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
 
        }
    }
}

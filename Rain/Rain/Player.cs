using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Rain
{
    class Player:GenericObject
    {
        public KeyEventHandler k;
        Form1 canvas;
        enum Position
        {
            left, Right, Stop
        }
        public int playerx = 400;
        public int playery = 400;
        public int sizex = 5 ;
        public int sizey = 20 ;
        int movespeed = 15;
         int rightBorder = 775;
        int leftBorder = 0;
  


        

        System.Drawing.SolidBrush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.SolidBrush greyBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;

       
       
        public Player(Form1 Canvas)
        {
            canvas = Canvas;
            Canvas.KeyDown += new KeyEventHandler(playerKeys);
            formGraphics = Canvas.CreateGraphics();
            greyBrush.Color = canvas.BackColor;


            Draw();

      
        }

        void playerKeys(object sender, KeyEventArgs e)
        {
          //  Console.WriteLine(e.KeyCode.ToString());
            //Console.WriteLine(playerx);


            Clear();


            if (e.KeyCode == Keys.Left) {
                playerx -= movespeed;
                if (playerx < leftBorder)
                {
                    playerx = rightBorder;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerx += movespeed;
                if (playerx > rightBorder)
                {
                    playerx = leftBorder;
                }
            }


            Draw();


        }

        public void Move()
        {

            
           
            


        }


        public void Clear()
        {
            formGraphics.FillRectangle(greyBrush, new Rectangle(playerx, playery, sizex, sizey));
        }
        public void Draw()
        {
            formGraphics.FillRectangle(redBrush, new Rectangle(playerx, playery, sizex, sizey));

        }


    }
}

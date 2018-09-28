using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Rain
{
    class Bullet : GenericObject
    {
        public KeyEventHandler k;

        private int yMin = +50;
        private int minSize = 10;
        private int maxSize = 30;
        private int minSpeed = 25;
        private int maxSpeed = 50;
        private Form1 canvas;
        private int screenwidth;
        private int screenheight;
        private Random r;

        System.Drawing.SolidBrush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.SolidBrush greyBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;

        public int size = 5;
        public int speed = 10;
        public int active = 1;

        


        public Bullet(Form1 Canvas, Random RandomGenerator, int ScreenWidth, int ScreenHeight, Player player)
        {
            
            r = RandomGenerator;
            canvas = Canvas;
            screenwidth = ScreenWidth;
            screenheight = ScreenHeight;
            formGraphics = canvas.CreateGraphics();
            greyBrush.Color = canvas.BackColor;


            x = player.playerx;
            y = player.playery;
          
        }


        public void fly()
        {
                clearbullet();
           y -= speed;
            shoot();


            if (y < 0)
            {
                // Kill me
                active = 0;

            }

            //Console.WriteLine("Fly: "+x.ToString()+":"+ y.ToString()+":"+active);

        }



      public  void Space(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                
                
               

            }

          

        }
        

        public void clearbullet()
        {
            formGraphics.FillRectangle(greyBrush, new Rectangle(x, y, size, size));
        }
        public void shoot()
        {
            formGraphics.FillRectangle(redBrush, new Rectangle(x, y, size, size));

        }
       

    }
}

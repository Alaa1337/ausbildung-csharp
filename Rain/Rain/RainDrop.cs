using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Rain
{
    class RainDrop : GenericObject 
    {
        private int yMin = -50;
        private int minSize = 10;
        private int maxSize = 30;
        private int minSpeed = 3;
        private int maxSpeed = 9;
        private int minwind = -15;
        private int maxwind = 15;
        private Form1 canvas;
        private int screenwidth;
        private int screenheight;
        private Random r;
        
        System.Drawing.SolidBrush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        System.Drawing.SolidBrush greyBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;


        

        public int size;
        public int speed;
        public int windspeed;
        public int age;

        /**
         * Constructor
         */
        public RainDrop (Form1 Canvas, Random RandomGenerator, int ScreenWidth, int ScreenHeight)
        {

            r = RandomGenerator;
            canvas = Canvas;
            screenwidth = ScreenWidth;
            screenheight = ScreenHeight;
            formGraphics = canvas.CreateGraphics();
            greyBrush.Color = canvas.BackColor;
            age = 0;

            InitMe();
        }

        /**
         * Meine Position bestimmen
         */
        void InitMe()
        {

            x = r.Next(0, screenwidth-size);
            y = yMin;
            size = r.Next(minSize, maxSize);
            speed = r.Next(minSpeed, maxSpeed);
            windspeed = r.Next(minwind, maxwind);
            age++;

        }

        public void Die()
        {
            Clear();
        }

        public void Drop()
        {
            Clear();
            y += speed;
          x += windspeed;


            Draw();

            if (y>screenheight)
            {
                InitMe();

            }
        }

        public void Clear()
        {
            formGraphics.FillRectangle(greyBrush, new Rectangle(x, y, size, size));
        }
        public void Draw()
        {
            formGraphics.FillRectangle(redBrush, new Rectangle(x, y, size, size));
            
        }
    }
}

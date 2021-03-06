﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Rain
{
    class Alien : GenericObject
    {
        private int yMin = -50;
        private int minSize = 40;
        private int maxSize = 50;
        private int minSpeed = 10;
        private int maxSpeed = 15;
        private int minwind = -15;
        private int maxwind = 15;
        private int healthcolor = 5;
        public int Alienhealth = 300;
        private Form1 canvas;
        private int screenwidth;
        private int screenheight;
        private Random r;

       private System.Drawing.SolidBrush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        System.Drawing.SolidBrush redBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        System.Drawing.SolidBrush greyBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
       


       
        public int newcolor;
        public int size;
        public int speed;
        public int windspeed;
        public int age;

        /**
         * Constructor
         */
        public Alien(Form1 Canvas, Random RandomGenerator, int ScreenWidth, int ScreenHeight)
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

            x = r.Next(0, screenwidth - size);
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

            if (y > screenheight)
            {
                InitMe();

            }
        }
        public void Hit()
        {
            System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(redBrush.Color.R+healthcolor, redBrush.Color.G-healthcolor, redBrush.Color.B+healthcolor));
            redBrush.Color = blackBrush.Color;

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


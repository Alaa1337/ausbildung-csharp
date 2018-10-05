using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    public partial class Form1 : Form
    {
        int maxRainDrops = 40;
        int maxBullets = 50;
        int maxaliens = 3;
        int gameSpeed = 40;
        int points = 0;

       private Cheatcode cheat = new Cheatcode();
        
        Random r = new Random();

        Timer rainTimer = new Timer();
        private List<RainDrop> rainDrops = new List<RainDrop>();
        private List<Bullet> gun = new List<Bullet>();
        private List<Alien> alien = new List<Alien>();
        private List<EasterEgg> Boss = new List<EasterEgg>();
        private Player player;
       





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /**
             * Unser Player
             */
            player = new Player (this);

            /**
            * Unser Regen
            */
            for (int i = 0; i < maxRainDrops; i++)
            {
                rainDrops.Add(new RainDrop(this, r, this.Width, this.Height));

            }
            for (int i = 0; i < maxBullets; i++)
            {

            }
            /**
* Unser Alien
*/

            for (int i = 0; i < maxaliens; i++)
            {
                alien.Add(new Alien(this, r, this.Width, this.Height));
            }


                /**
                 * Unser Timer
                 */
                rainTimer.Enabled = true;
            rainTimer.Interval = gameSpeed;
            rainTimer.Tick += new EventHandler(MyTimer);



        }
        private void Respawn()
        {
            if (alien.Count == 0)
            {
                for (int i = 0; i < maxaliens; i++)
                {
                    alien.Add(new Alien(this, r, this.Width, this.Height));

                }
            }

            if (rainDrops.Count == 0)
            {
                for (int i = 0; i < maxRainDrops; i++)
                {
                    rainDrops.Add(new RainDrop(this, r, this.Width, this.Height));

                }
            }
        }

        private void checkBossColission()
        {
            for (int b = 0; b < gun.Count(); b++)
            {
                for (int a = 0; a < Boss.Count(); a++)
                {
                    var bulletX = gun[b].x + gun[b].size / 2;
                    var bulletY = gun[b].y + gun[b].size / 2;

                    if (bulletX > Boss[a].x && bulletX < Boss[a].x + Boss[a].size &&
                             bulletY > Boss[a].y && bulletY < Boss[a].y + Boss[a].size &&
                             bulletY < Boss[a].y + Boss[a].size)
                    {
                        Boss[a].Hit();
                        Boss[a].Clear();
                        Boss[a].Teleport();
                        

                        Boss[a].windspeed *= -1;
                        Boss[a].Bosshealth -= 75;

                        Console.WriteLine(Boss[a].Bosshealth.ToString());

                        if (Boss[a].Bosshealth <= 0)
                        {
                            Boss[a].Die();
                            Boss.RemoveAt(a);
                            
                            easteregg.Text =("Credits: Alaa, Margus");
                        }
                    }

                }
            }

        }


        private void checkalienColission()
        {
            for (int b = 0; b < gun.Count(); b++)
            {
                for (int a = 0; a < alien.Count(); a++)
                {
                    var bulletX = gun[b].x + gun[b].size / 2;
                    var bulletY = gun[b].y + gun[b].size / 2;

                    if (bulletX > alien[a].x && bulletX < alien[a].x + alien[a].size &&
                             bulletY > alien[a].y && bulletY < alien[a].y + alien[a].size &&
                             bulletY < alien[a].y + alien[a].size)
                    {
                        alien[a].Hit();
                        
                        alien[a].windspeed *= -1;
                        alien[a].Alienhealth-=15;
                       
                        Console.WriteLine(alien[a].Alienhealth.ToString());

                     if (alien[a].Alienhealth <= 0)
                        {
                            alien[a].Die();
                            alien.RemoveAt(a);
                            points += 15;
                        }   
                    }

                }
            }

        }


        private void checkrainCollision()
        {
            for (int b = 0; b < gun.Count(); b++)
            {
                for (int r = 0; r < rainDrops.Count(); r++)
                {
                        var bulletX = gun[b].x + gun[b].size / 2;
                        var bulletY = gun[b].y + gun[b].size / 2;

                        if (bulletX > rainDrops[r].x && bulletX < rainDrops[r].x + rainDrops[r].size &&
                            bulletY > rainDrops[r].y && bulletY < rainDrops[r].y + rainDrops[r].size &&
                            bulletY < rainDrops[r].y + rainDrops[r].size)
                        {
                   
                        rainDrops[r].Die();
                             rainDrops.RemoveAt(r);
                          //  Console.WriteLine("COLLISION");
                            points++;
                        }

                  

                }
            }
        }

        /**
         * Hier findet die Animation statt
         */
        private void MyTimer(object sender, EventArgs e)
        {

            // Let it rain...

            int totalAgeOfAllRainDrops = 0;

            for (int i = 0; i < rainDrops.Count(); i++)
            {
                //checkCollision(Player, rainDrops[i]);
                rainDrops[i].Drop();
                totalAgeOfAllRainDrops += rainDrops[i].age;
            }
            
            for (int i = 0; i < gun.Count(); i++)
            {

                gun[i].fly();
                if (gun[i].active == 0)
                    {

                        gun.RemoveAt(i);
                    }
            }
            for (int i = 0; i < alien.Count; i++)
            {
                alien[i].Drop();
            }

            for (int i = 0; i < Boss.Count; i++)
            {
                Boss[i].Drop();
            }



            // Checkt Bullet->Raindrop Kollisionen
            checkrainCollision();
            checkalienColission();
            checkBossColission();

            Respawn();

            score.AutoSize = true;
            score.Text = ("Score: " + points);
           
            statss.AutoSize = true;
            statss.Text=("Total Age: " + totalAgeOfAllRainDrops);
          //  Console.WriteLine("Total Age: "+ totalAgeOfAllRainDrops);

            //Console.WriteLine("Number of Bullets alive: "+ rainDrops.Count());

            // Player debug
            //Console.WriteLine(p.playerx);
            //player.Move();
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
            
            gun.Add(new Bullet(this, r, this.Width, this.Height, player));
                    



                

            }

            if (cheat.IsCompletedBy(e.KeyCode))
            {
               
                maxRainDrops = 0;
                maxaliens = 0;
              
                

                for (int i = 0; i < rainDrops.Count(); i++)
                {
                     rainDrops[i].Die();
                  //  rainDrops.RemoveAll(i);
                }
                for (int i = 0; i< alien.Count(); i++)
                {
                    alien[i].Die();
                }

                alien.Clear();
               rainDrops.Clear();
                
                MessageBox.Show("THAT WAS A MISTAKE");
                Boss.Add(new EasterEgg(this, r, this.Width, this.Height));
                gameSpeed = 150;

            }


        }

    }
}

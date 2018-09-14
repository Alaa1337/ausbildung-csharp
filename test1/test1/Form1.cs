using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{

    public partial class Form1 : Form
    {

        int speedLimiter = 100;
        int startposition = 352;
        int winmoney;

        Dog dogOne;
        Dog dogTwo;

        public Form1()
        {
            InitializeComponent();

            // Variablen im Constructor initialisieren
            winmoney = trackBar1.Value + trackBar2.Value;




            // Dogs
            dogOne = new Dog();
            dogTwo = new Dog();

            dogOne.create();

            dogTwo.create();

            dogs.AppendText("Speed von ("+dogOne.name+") = "+dogOne.speed+"\n Gewicht= "+dogOne.weight+"\n");
            dogs.AppendText("Speed von (" + dogTwo.name + ")  = " + dogTwo.speed+"\n Gewicht= " + dogTwo.weight+ "\n");



            label3.Text = ("" +dogOne.betmoney);
            label5.Text = ("" +dogTwo.betmoney);

            trackBar1.Maximum = dogOne.betmoney;

            trackBar2.Maximum = dogTwo.betmoney;

            if (trackBar1.Value == 0 && trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            if (trackBar1.Value == 0 || trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }


            if (winmoney >0)
            {
                startbutton.Enabled = true;
            }
            else
            {
                startbutton.Enabled = false;
            }

            if (trackBar1.Value <= 0 && trackBar2.Value <= 0)
            {
                bet1.Enabled = false;
            }
            else
            {
                bet1.Enabled = true;
            }


            if  (dogOne.betmoney == trackBar1.Maximum + trackBar2.Maximum)
            {
                label6.Text = ("loser");
            }


        }
        


        private void colorchooser_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }






 


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void startbutton_Click(object sender, EventArgs e)
        {
            pic.Enabled = true;
            pic2.Enabled = true;
            timer2.Enabled = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (pic.Location.X >= 1072 || pic2.Location.X >= 1072)
            {
                restart.Enabled = true;
                pic.Enabled = false;
                pic2.Enabled = false;
                timer2.Stop();
                startbutton.Enabled = false;
            }
            if (pic.Location.X >= 1072)
            {
                dogOne.wins++;
                textBox7.Text = (+dogOne.wins+"Win(s)\n");
                dogOne.betmoney = winmoney + dogOne.betmoney;
                label3.Text = (""+dogOne.betmoney );

                if (dogOne.betmoney == trackBar1.Maximum + trackBar2.Maximum)
                {
                    label6.Text = ("loser");
                }

            }

            if (pic2.Location.X >= 1072)
            {
                dogTwo.wins++;
                textBox8.Text = (+dogTwo.wins + "Win(s)\n");
                dogTwo.betmoney = winmoney + dogTwo.betmoney;
                label5.Text = ("" + dogTwo.betmoney);
            }

            pic.Location =  new Point(pic.Location.X+dogOne.speed/speedLimiter+dogOne.weight/2, pic.Location.Y);
            pic2.Location =  new Point(pic2.Location.X + dogTwo.speed/speedLimiter+dogTwo.weight/2, pic2.Location.Y);



        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {
            startbutton.Enabled = true;
            dogs.Text = (String.Empty);
           pic.Location = new Point(startposition , pic.Location.Y);
           pic2.Location = new Point(startposition, pic2.Location.Y);
           dogOne.create();
           dogTwo.create();

            dogs.AppendText("\n\nSpeed von (" + dogOne.name + ") = " + dogOne.speed + "\n Gewicht= " + dogOne.weight + "\n");
            dogs.AppendText("\n\nSpeed von (" + dogTwo.name + ")  = " + dogTwo.speed + "\n Gewicht= " + dogTwo.weight + "\n");
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            bet1.Enabled = true;
            winmoney = 0;
            money.Text = ("" + winmoney);

            trackBar1.Maximum = dogOne.betmoney;

            trackBar2.Maximum = dogTwo.betmoney;

            trackBar1.Value = 0;
            trackBar2.Value = 0;
            label1.Text = trackBar1.Value.ToString();
            label2.Text = trackBar2.Value.ToString();


            if (trackBar1.Value == 0 && trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            if (trackBar1.Value == 0 || trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }

            if (winmoney > 0)
            {
                startbutton.Enabled = true;
            }
            else
            {
                startbutton.Enabled = false;


            }

            restart.Enabled = false;
            if (trackBar1.Maximum == 0)
            {
                label6.Text = ("loser");
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {


        }

        private void Player1box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();


            if (trackBar1.Value == 0 && trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            else
            {
                bet1.Enabled = true;
            }
            if (trackBar1.Value == 0 || trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            else
            {
                bet1.Enabled = true;
            }


            winmoney = trackBar1.Value + trackBar2.Value;




        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();

            winmoney = trackBar1.Value + trackBar2.Value;

            if (trackBar1.Value == 0 && trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            else
            {
                bet1.Enabled = true;
            }
            if (trackBar1.Value == 0 || trackBar2.Value == 0)
            {
                bet1.Enabled = false;
            }
            else
            {
                bet1.Enabled = true;
            }
        }

        private void bet1_Click(object sender, EventArgs e)
        {
            dogOne.betmoney = dogOne.betmoney - trackBar1.Value;

            label3.Text = ("" + dogOne.betmoney);

            bet1.Enabled = false;

            money.Text = ("" + winmoney);
            trackBar1.Enabled = false;

            if (winmoney > 0)
            {
                startbutton.Enabled = true;
            }
            else
            {
                startbutton.Enabled = false;
            }

            dogTwo.betmoney = dogTwo.betmoney - trackBar2.Value;
            label5.Text = ("" + dogTwo.betmoney);
            money.Text = ("" + winmoney);
            trackBar2.Enabled = false;

            if (winmoney > 0)
            {
                startbutton.Enabled = true;
            }
            else
            {
                startbutton.Enabled = false;
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}

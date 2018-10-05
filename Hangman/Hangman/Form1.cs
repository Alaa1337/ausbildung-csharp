using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        Words wrd = new Words();
        int stage = 0;
        public List<Label> labels = new List<Label>();
        private bool button1clicked = false;

        
        
        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            lines();
        }


        public void restartFunction()
        {
            stage = 0;
            guess.Enabled = true;
            wrd.restart();
            Array.ForEach(this.Controls.OfType<Label>().ToArray(), lbl => lbl.Dispose());
            labels = new List<Label>();
            lines();
            Invalidate();
        }

        public void checkFunction()
        {

            bool functionOn = false;

            for (int i = 0; i < wrd.Guessword.Length; i++)
            {
                if (labels[i].Tag.ToString() == textBox2.Text)
                {
                    functionOn = true;
                    labels[i].Text = textBox2.Text;
                }

            }

            if (functionOn == false)
            {
                stage++;
                Invalidate();
            }

            if (stage >= 10)
            {
                guess.Enabled = false;
            }
            
        }


        public void lines()
        {
            int startX = 14;
            int n = 1;
            foreach (char c in wrd.Guessword)
            {
                Label lbl = new Label();
                lbl.Text = "   "; //c.ToString(); 
                lbl.Font = new Font(this.Font.Name, 35, FontStyle.Underline);
                lbl.Location = new Point(startX, 250);
                lbl.Tag = c.ToString();
                lbl.Name = "Label"+n.ToString();
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
                labels.Add(lbl);
                startX = lbl.Right;
                n++;
               
                Console.WriteLine(c);

            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (stage >= 1)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);
            }
            if (stage >= 2)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
            }
            if (stage >= 3)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
            }
            if (stage >= 4)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
            }
            if (stage >= 5)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
            }
            if (stage >= 6)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);
            }
            if (stage >= 7)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
            }
            if (stage >= 8)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
            }
            if (stage >= 9)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
            }
            if (stage >= 10)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
            }
            
        }


        private void guess_Click(object sender, EventArgs e)
        {
            button1clicked = true;
            lines();

            checkFunction();

           

            //if (labels.Tag.ToString() != textBox2.Text)



                
            Invalidate();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restartFunction();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Pressed enter.");
            }
        }
    }
}

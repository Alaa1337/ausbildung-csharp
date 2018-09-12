using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
     class Dog
    {
        int id;
        private static Random r;
        public string name;
        int minSpeed = 100;
        int maxSpeed = 300;
        public int speed;
        int minWeight = 20;
        int maxWeight = 50;
        public int weight;
        private string[] names = { "Fiffi", "Max", "Tom", "Bunny","Duke","Dooby-Scoo"};
        public int wins;
        public int betmoney = 10000;

        // Constructor
        public Dog()
        {
            r = new Random();

        }

        public void create()
        {

            this.weight = r.Next(minWeight, maxWeight);
            this.speed = r.Next(minSpeed, maxSpeed);
            this.name = this.names[r.Next(0,6)];






        }




        

        public int mySpeed ()
        {
            return this.betmoney;
            return this.weight;
            return this.speed;
        }




    }
}

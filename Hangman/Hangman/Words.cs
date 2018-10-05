using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Words 
    {
        private string[] Wordbank = { "Junge", "Daten", "Haare", "Artzt", "Weihnachtsmann", "Atmosphaere", "Rhythmus", "Lokomotiv", "Heizoel", "druckventil", "versicherung", "Kommunismus", "Ratzefummel", "Migrationsvordergrund", "Eselsbrücke", "Schadenfreude" };
            Random r = new Random();
        
        public string Guessword;
     
        public Words()
        {
            
        Guessword = Wordbank[r.Next(0,Wordbank.Length)].ToUpper();
            Guessword.ToUpper();
 

        }

        public void restart()
        {
            this.Guessword = Wordbank[r.Next(0, Wordbank.Length)].ToUpper();
            this.Guessword.ToUpper();
        }

    }
}

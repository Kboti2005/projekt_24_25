using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    internal class Sportolo
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public string SportAg { get; set; }
        public double Eredmeny { get; set; }

        public Sportolo(string nev, int eletkor, string sportAg, double eredmeny)
        {
            Nev = nev;
            Eletkor = eletkor;
            SportAg = sportAg; 
            Eredmeny = eredmeny;
        }
    }
}
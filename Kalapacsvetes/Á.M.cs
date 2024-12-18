using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sportolók adatainak beolvasása
            List<Sportolo> sportolok = new List<Sportolo>();
            string[] sorok = File.ReadAllLines("kalapacsvetes.txt");
            for (int i = 1; i < sorok.Length; i++) // Az első sor a fejléc
            {
                string[] adatok = sorok[i].Split(';'); //a fájlban elválasztja az adatokat
                Sportolo sportolo = new Sportolo(adatok[0], int.Parse(adatok[1]), adatok[2], double.Parse(adatok[3]));
                sportolok.Add(sportolo);
            }

            //statisztika
            double atlagEredmeny = sportolok.Average(s => s.Eredmeny);
            double maxEredmeny = sportolok.Max(s => s.Eredmeny);
            double minEredmeny = sportolok.Min(s => s.Eredmeny);

            //kiírás a konzolra
            Console.WriteLine("Statisztika:");
            Console.WriteLine($"Átlag eredmény: {atlagEredmeny}");
            Console.WriteLine($"Legjobb eredmény: {maxEredmeny}");
            Console.WriteLine($"Legrosszabb eredmény: {minEredmeny}");

            //felhasználói bevitel és szűrés
            Console.WriteLine("Adj meg egy sportágot:");
            string SportAg = Console.ReadLine();

            //1. szűrés: egy adott sportágban versenyzők
            var sportolokAzAdottSportban = sportolok.Where(s => s.SportAg == SportAg);

            //2. szűrés: egy adott sportágban versenyzők közül a legjobb 3
            var legjobbHarom = sportolokAzAdottSportban.OrderByDescending(s => s.Eredmeny).Take(3);

            // Kiírás fájlba
            string outputFile = "eredmenyek.txt";
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.WriteLine("Legjobb 3 eredmény az adott sportágban:");
                foreach (var sportolo in legjobbHarom)
                {
                    sw.WriteLine($"{sportolo.Nev}: {sportolo.Eredmeny}");
                }
            }

            Console.WriteLine($"Az eredményeket elmentettem: {outputFile}");
            Console.WriteLine("VÉGE - Üss ENTER-t a befejezéshez.");
            Console.ReadLine();
        }
    }
}
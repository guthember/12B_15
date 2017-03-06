using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace kektura
{
    class Program
    {
        static List<string> indulo = new List<string>();
        static List<string> vegzo = new List<string>();
        static List<double> hossz = new List<double>();
        static List<int> emelkedes = new List<int>();
        static List<int> lejtes = new List<int>();
        static List<bool> pecsetelo = new List<bool>();

        static void Beolvas()
        {
            FileStream file = new FileStream("kektura.csv", FileMode.Open);
            StreamReader be = new StreamReader(file);

            string[] adatok = new string[6];
            string adat = "";
            int magassag;

            // magasság beolvasása és egésszé konvertálása
            magassag = Convert.ToInt32(be.ReadLine());
            // Console.WriteLine("A magassag: {0}",magassag);

            // adatsorok beolvasása
            while (!be.EndOfStream)
            {
                adat = be.ReadLine();
                adatok = adat.Split(';');
                indulo.Add(adatok[0]);
                vegzo.Add(adatok[1]);
                hossz.Add(Convert.ToDouble(adatok[2]));
                emelkedes.Add(Convert.ToInt32(adatok[3]));
                lejtes.Add(Convert.ToInt32(adatok[4]));
                if (adatok[5] == "i")
                {
                    pecsetelo.Add(true);
                }
                else
                {
                    pecsetelo.Add(false);
                }
            }

            be.Close();
            file.Close();
        }

        static void Kiiras()
        {
            int darab = indulo.Count;
            for (int i = 0; i < darab; i++)
            {
                Console.WriteLine("{0}--{1}--{2}--{3}--{4}--{5}",
                    indulo[i],
                    vegzo[i],
                    hossz[i].ToString(),
                    emelkedes[i].ToString(),
                    lejtes[i].ToString(),
                    pecsetelo[i].ToString()
                    );
            }
        }

        static void Harmadik() 
        {
            Console.Write("3. feladat: ");
            Console.WriteLine("A szakaszok szama: {0} db", indulo.Count);
        }

        static void Negyedik()
        {
            double teljesHossz = 0.0;
            for (int i = 0; i < hossz.Count; i++)
            {
                // teljesHossz = teljesHossz + hossz[i];
                teljesHossz += hossz[i];
            }
            Console.Write("4. feladat: ");
            Console.WriteLine("A tura teljes hossza: {0} km",teljesHossz);
        }

        static void Otodik()
        {
            // feltételezzük, hogy az első elem a legkisebb
            double min = hossz[0];
            int hely = 0;
            for (int i = 1; i < hossz.Count; i++)
            {
                if (hossz[i] < min)
                {
                    min = hossz[i];
                    hely = i;
                }
            }
            Console.WriteLine("5. feladat: A legrovidebb szakasz adatai:");
            Console.WriteLine("\tKezdete: {0}",indulo[hely]);
            Console.WriteLine("\tVege: {0}",vegzo[hely]);
            Console.WriteLine("\tTavolsag: {0} km",hossz[hely]);
        }

        static void Main()
        {
            Beolvas();
            // Kiiras();
            Harmadik();
            Negyedik();
            Otodik();
            Console.WriteLine("Tovabb barmilyen billentyure...");
            Console.ReadKey();
        }
    }
}

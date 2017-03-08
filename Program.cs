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
        static int magassag;
        static void Beolvas()
        {
            FileStream file = new FileStream("kektura.csv", FileMode.Open);
            StreamReader be = new StreamReader(file);

            string[] adatok = new string[6];
            string adat = "";
            
            // magasság beolvasása és egésszé konvertálása
            adat = be.ReadLine();
            magassag = Convert.ToInt32(adat);
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

        static bool HianyosNev(int melyik) 
        {
            if (vegzo[melyik].Contains("pecsetelohely"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Hetedik()
        {
            Console.WriteLine("7. feladat: Hianyos allomasnevek:");
            int db = 0;
            for (int i = 0; i < vegzo.Count; i++)
            {
                if (pecsetelo[i])
                {
                    if (HianyosNev(i))
                    {
                        Console.WriteLine("\t{0}",vegzo[i]);
                        db++;
                    }
                }
            }
            if (db == 0)
            {
                Console.WriteLine("Nincs hianyos allomasnev!");
            }
        }

        static void Nyolcadik() 
        {
            List<int> magassagok = new List<int>();
            magassagok.Add(magassag);
            int max = magassagok[0];
            int hely = 0; ;
            for (int i = 1; i < lejtes.Count; i++)
            {
                magassagok.Add(magassagok[i - 1] + emelkedes[i - 1] - lejtes[i - 1]);
                if (magassagok[i] > max)
                {
                    max = magassagok[i];
                    hely = i;
                }
            }
            Console.WriteLine("8. feladat: Legmagasabb vegpont:");
            Console.WriteLine("\tA vegpont neve: {0}",indulo[hely]);
            Console.WriteLine("\tA magassaga: {0} m",magassagok[hely]);
        }

        static void Main()
        {
            Beolvas();
            // Kiiras();
            Harmadik();
            Negyedik();
            Otodik();
            Hetedik();
            Nyolcadik();
            Console.WriteLine("Tovabb barmilyen billentyure...");
            Console.ReadKey();
        }
    }
}

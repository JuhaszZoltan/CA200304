using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CA200304
{
    class Program
    {
        static List<Adatsor> adatsorok;
        static void Main()
        {
            Beolvas();
            F03(); F04(); F05();
            F07(); F08(); F09();
            Console.ReadKey();
        }

        private static void F09()
        {
            Console.Write("F9: ");
            var lh = adatsorok
                .GroupBy(a => a.Sofor, a => a.Db)
                .OrderByDescending(x => x.Sum())
                .First();
            Console.WriteLine(lh.Key + " " + lh.Sum());
        }

        private static void F08()
        {
            Console.Write("F8: ");
            int ss = adatsorok
                .Select(a => a.Sofor)
                .Distinct()
                .Count();
            Console.WriteLine(ss);
        }

        private static void F07()
        {
            var sw = new StreamWriter(
                @"..\..\res\cb2.txt", false, Encoding.UTF8);
            sw.WriteLine("Kezdes;Nev;AdasDb");
            adatsorok.ForEach(
                a => sw.WriteLine($"{a.OsszPerc};{a.Sofor};{a.Db}"));
            sw.Close();
        }

        private static void F05()
        {
            Console.Write("f5: nev: ");
            var nev = Console.ReadLine();
            int haszn = adatsorok
                .Where(a => a.Sofor == nev)
                .Sum(a => a.Db);
            Console.WriteLine(
                haszn != 0 ? $"\t{haszn}" : $"\tnincs");
        }

        private static void F04()
        {
            Console.Write("f4: ");
            bool van4 = adatsorok.Exists(a => a.Db == 4);
            Console.WriteLine(van4 ? "van" : "nincs");
        }

        private static void F03()
        {
            Console.Write("f3: ");
            Console.WriteLine(adatsorok.Count);
        }

        private static void Beolvas()
        {
            adatsorok = new List<Adatsor>();
            var sr = new StreamReader(
                @"..\..\res\cb.txt", Encoding.UTF8);
            sr.ReadLine(); //skip
            while (!sr.EndOfStream)
                adatsorok.Add(new Adatsor(sr.ReadLine()));
            sr.Close();
        }
    }
}

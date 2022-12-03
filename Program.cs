using System.Globalization;

namespace Cseveges
{
    internal class Program
    {
        static List<Beszelgetes> Beszel_Lista = new();
        static List<string> TagokLs = new();
        static void Main(string[] args)
        {
            Feladat03();
            /* Feladat04();
             Feladat05();
             Feladat06();
             Feladat07();*/
            Feladat08();
        }

        private static void Feladat08()
        {
            Console.WriteLine("8. feladat: Leghosszabb csendes időszak 15h-tól");
            DateTime Kezdido = new DateTime(2021, 9, 27, 15, 0, 0);
            DateTime maxCsendVege = Beszel_Lista[0].Kezdet;
            TimeSpan maxCsendHossz = maxCsendVege - Kezdido;
            DateTime aktCsendVege = Beszel_Lista[0].Veg;

            foreach (var b in Beszel_Lista.Skip(1))
            {
                if (b.Kezdet > aktCsendVege)  
                {
                    TimeSpan aktCsendHossz = b.Kezdet - aktCsendVege;
                    if (aktCsendHossz > maxCsendHossz)
                    {
                        maxCsendHossz = aktCsendHossz;
                        Kezdido = aktCsendVege;
                        maxCsendVege = b.Kezdet;
                    }
                }
                if (b.Veg > aktCsendVege) aktCsendVege = b.Veg;
            }
            Console.WriteLine($"\tKezdete: {Kezdido.ToString("yy.MM.dd-HH:mm:ss")}");
            Console.WriteLine($"\tVége:    {maxCsendVege.ToString("yy.MM.dd-HH:mm:ss")}");
            Console.WriteLine($"\tHossza:  {maxCsendHossz}");
        }

        private static void Feladat07()
        {
            Console.WriteLine("7. feladat: Nem beszéltek senkivel");
            foreach (var t in TagokLs)
            {
                int Alkalom = Beszel_Lista.Count(x => x.Kezdemenyezo == t || x.Fogado == t);
                if (Alkalom == 0)
                {
                    Console.WriteLine($"\t{t}");
                }
            }
        }

        private static void Feladat06()
        {
            Console.Write("6. feladat: Adja meg egy tag nevét: ");
            string Nev = Console.ReadLine();
            TimeSpan Osszido = new TimeSpan(0, 0, 0);
            foreach (var b in Beszel_Lista)
            {
                if (b.Kezdemenyezo == Nev || b.Fogado == Nev)
                {
                    Osszido = Osszido + (b.Veg - b.Kezdet);
                }
            }
            Console.WriteLine($"\tA beszélgetések összes ideje: {String.Format(Osszido.ToString(), "00.00.00")}");
        }

        private static void Feladat05()
        {
            TimeSpan MaxIdo = new TimeSpan(0, 0, 0);
            Beszelgetes MaxBeszel = null;
            foreach (var b in Beszel_Lista)
            {
                TimeSpan kul = b.Veg - b.Kezdet;
                if (kul > MaxIdo)
                {
                    MaxIdo = kul;
                    MaxBeszel = b;
                }
            }
            Console.WriteLine($"5. feladat: Leghosszabb beszélgetés adatai:\n" +
                $"\tKezeményező:    {MaxBeszel.Kezdemenyezo}\n" +
                $"\tFogadó:         {MaxBeszel.Fogado}\n" +
                $"\tKezdete:        {MaxBeszel.Kezdet.ToString("yy.MM.dd-HH:mm:ss")}\n" +
                $"\tVége:           {MaxBeszel.Veg.ToString("yy.MM.dd-HH:mm:ss")}\n" +
                $"\tHossz:          {MaxIdo.TotalSeconds}mp");
        }

        private static void Feladat04()
        {
            Console.WriteLine($"4. feladat: Tagok száma {TagokLs.Count}fő - Beszélgetések: {Beszel_Lista.Count}db");
        }

        private static void Feladat03()
        {
            StreamReader sr = new(@"..\..\..\src\csevegesek.txt");
            StreamReader sr2 = new(@"..\..\..\src\tagok.txt");
            int sz = 0;
            while (!sr.EndOfStream)
            {
                try
                { Beszel_Lista.Add(new Beszelgetes(sr.ReadLine())); }
                catch (Exception)
                { }

            }
            while (!sr2.EndOfStream)
            {
                TagokLs.Add(sr2.ReadLine());
            }
        }
    }
}
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Cseveges
{
    internal class Program
    {
        static List<Beszelgetes> Beszel_List = new();
        static List<string> TagokLs = new();
        static void Main(string[] args)
        {
            Feladat03();
            Feladat04();

        }

        private static void Feladat04()
        {
            
        }

        private static void Feladat03()
        {
            StreamReader sr = new(@"..\..\..\src\csevegesek.txt");
            StreamReader sr2 = new(@"..\..\..\src\tagok.txt"); 
            int sz = 0;
            while (!sr.EndOfStream)
            {
                try
                {Beszel_List.Add(new Beszelgetes(sr.ReadLine()));}
                catch (Exception)
                {}
                
            }
            while (!sr2.EndOfStream)
            {
                TagokLs.Add(sr2.ReadLine());
            }
        }
    }
}
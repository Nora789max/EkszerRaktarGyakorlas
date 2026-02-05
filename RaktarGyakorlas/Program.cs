using System;
using RaktarGyakorlas.Modell;
using RaktarGyakorlas.Repository;


namespace RaktarGyakorlas
{
    internal class Program
    {
        static AruNyilvantartas Ekszerek;
        static UgyfelNyilvantartas Ugyfelek;
        static void Main(string[] args)
        {
            Ekszerek = new AruNyilvantartas();
            Ugyfelek = new UgyfelNyilvantartas();
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("=== RAKTÁR NYILVÁNTARTÁS ===");
                Console.WriteLine("1 - Új áru felvétele");
                Console.WriteLine("2 - Összes áru listázása");
                Console.WriteLine("3 - Áru keresése ID alapján");
                Console.WriteLine("4 - Áru keresése név alapján");
                Console.WriteLine("5 - Áru módosítása");
                Console.WriteLine("6 - Áru törlése");
                Console.WriteLine("ESC - Kilépés");
                Console.WriteLine(); 
                Console.Write("Választás: ");

                key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.D1:
                        UjAru();
                        break;

                    case ConsoleKey.D2:
                        OsszesAru();
                        break;

                    case ConsoleKey.D3:
                        KeresesId();
                        break;

                    case ConsoleKey.D4:
                        KeresesTitle();
                        break;

                    case ConsoleKey.D5:
                        Modositas();
                        break;

                    case ConsoleKey.D6:
                        Torles();
                        break;
                }

                if (key != ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tovább: bármely billentyű...");
                    Console.ReadKey();
                }

            } while (key != ConsoleKey.Escape);
        }

        static void UjAru()
        {
            Console.Write("Megnevezés: ");
            string title = Console.ReadLine();

            Console.Write("Leírás: ");
            string description = Console.ReadLine();

            Console.Write("Ár: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Ekszerek.UjaruFelvesz(title, description, price);
            Console.WriteLine("✔ Áru felvéve");
        }

        static void OsszesAru()
        {
            List<Aru> lista = new List<Aru>();
            lista = Ekszerek.OsszesAruLekerdez();

            if (!lista.Any())
            {
                Console.WriteLine("Nincs rögzített áru.");
                return;
            }

            foreach (var aru in lista)
            {
                Console.WriteLine(aru);
            }
        }

        static void KeresesId()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Aru aru = null;
            aru = Ekszerek.AruLekerdezIdAlapjan(id);
            if (aru == null)
            {
                Console.WriteLine("Nincs ilyen áru.");
                return;
            }

            Console.WriteLine(aru);
        }

        static void KeresesTitle()
        {
            Console.Write("Név részlet: ");
            string title = Console.ReadLine();
            Aru aru = null;
            aru = Ekszerek.AruLekerdezTitleAlapjan(title);
            if (aru == null)
            {
                Console.WriteLine("Nincs találat.");
                return;
            }

            Console.WriteLine(aru);
        }

        static void Modositas()
        {
            Console.Write("Módosítandó ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Új megnevezés: ");
            string title = Console.ReadLine();

            Console.Write("Új leírás: ");
            string description = Console.ReadLine();

            Console.Write("Új ár: ");
            decimal price = decimal.Parse(Console.ReadLine());
            bool siker = false;
            siker = Ekszerek.AruModositasaIdAlapjan(id, title, description, price);
            Console.WriteLine(siker ? "✔ Sikeres módosítás" : "✖ Nincs ilyen áru");
        }

        static void Torles()
        {
            Console.Write("Törlendő ID: ");
            int id = int.Parse(Console.ReadLine());
            bool siker = false;
            siker = Ekszerek.AruTorleseIdAlapjan(id);
            Console.WriteLine(siker ? "✔ Áru törölve" : "✘ Nincs ilyen áru");
        }
    }
}

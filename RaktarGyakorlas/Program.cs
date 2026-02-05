using System;
using RaktarGyakorlas.Modell;
using RaktarGyakorlas.Repository;


namespace RaktarGyakorlas
{
    internal class Program
    {
        static AruNyilvantartas Ekszerek;
        static UgyfelNyilvantartas Ugyfelek;
        static DolgozoNyilvantartas Dolgozok;
        static void Main(string[] args)
        {
            Ekszerek = new AruNyilvantartas();
            Ugyfelek = new UgyfelNyilvantartas();
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("=== NYILVÁNTARTÁS ===");
                Console.WriteLine("1 - ÁRUK");
                Console.WriteLine("2 - ÜGYFELEK");
                Console.WriteLine("3 - DOLGOZÓK");
                key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.D1:
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
                        break;
                    case ConsoleKey.D2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("=== ÜGYFÉL NYILVÁNTARTÁS ===");
                            Console.WriteLine("1 - Új ügyfél felvétele");
                            Console.WriteLine("2 - Összes ügyfél listázása");
                            Console.WriteLine("3 - Ügyfél keresése ID alapján");
                            Console.WriteLine("4 - Ügyfél keresése név alapján");
                            Console.WriteLine("5 - Ügyfél módosítása");
                            Console.WriteLine("6 - Ügyfél törlése");
                            Console.WriteLine("ESC - Kilépés");
                            Console.WriteLine();
                            Console.Write("Választás: ");

                            key = Console.ReadKey().Key;
                            Console.WriteLine();

                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    UjUgyfel();
                                    break;

                                case ConsoleKey.D2:
                                    OsszesUgyfel();
                                    break;

                                case ConsoleKey.D3:
                                    KeresUgyfelId();
                                    break;

                                case ConsoleKey.D4:
                                    KeresUgyfelNev();
                                    break;

                                case ConsoleKey.D5:
                                    ModositasUgyfel();
                                    break;

                                case ConsoleKey.D6:
                                    TorlesUgyfel();
                                    break;
                            }

                            if (key != ConsoleKey.Escape)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tovább: bármely billentyű...");
                                Console.ReadKey();
                            }

                        } while (key != ConsoleKey.Escape);
                        break;
                    case ConsoleKey.D3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("=== DOLGOZÓK NYILVÁNTARTÁS ===");
                            Console.WriteLine("1 - Új dolgozó felvétele");
                            Console.WriteLine("2 - Összes dolgozó listázása");
                            Console.WriteLine("3 - Dolgozó keresése ID alapján");
                            Console.WriteLine("4 - Dolgozó keresése név alapján");
                            Console.WriteLine("5 - Dolgozó módosítása");
                            Console.WriteLine("6 - Dolgozó törlése");
                            Console.WriteLine("ESC - Kilépés");
                            Console.WriteLine();
                            Console.Write("Választás: ");

                            key = Console.ReadKey().Key;
                            Console.WriteLine();

                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    UjDolgozo();
                                    break;

                                case ConsoleKey.D2:
                                    OsszesDolgozo();
                                    break;

                                case ConsoleKey.D3:
                                    KeresDolgozoId();
                                    break;

                                case ConsoleKey.D4:
                                    KeresDolgozoNev();
                                    break;

                                case ConsoleKey.D5:
                                    ModositasDolgozo();
                                    break;

                                case ConsoleKey.D6:
                                    TorlesDolgozo();
                                    break;
                            }

                            if (key != ConsoleKey.Escape)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Tovább: bármely billentyű...");
                                Console.ReadKey();
                            }

                        } while (key != ConsoleKey.Escape);
                        break;
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

                static void UjUgyfel()
                {
                    Console.Write("Név: ");
                    string name = Console.ReadLine();

                    Console.Write("Emali-cím: ");
                    string email = Console.ReadLine();

                    Console.Write("Telefon: ");
                    string phone = Console.ReadLine();

                    Console.Write("Telefon: ");
                    string address = Console.ReadLine();

                    Ugyfelek.UjUgyfelFelvesz(name, email, phone, address);
                    Console.WriteLine("✔ Ügyfél felvéve");
                }

                static void OsszesUgyfel()
                {
                    List<Ugyfel> lista = new List<Ugyfel>();
                    lista = Ugyfelek.OsszesUgyfelLekerdez();

                    if (!lista.Any())
                    {
                        Console.WriteLine("Nincs rögzített ügyfél.");
                        return;
                    }

                    foreach (var ugyfel in lista)
                    {
                        Console.WriteLine(ugyfel);
                    }
                }

                static void KeresUgyfelId()
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Aru ugyfel = null;
                    ugyfel = Ekszerek.AruLekerdezIdAlapjan(id);
                    if (ugyfel == null)
                    {
                        Console.WriteLine("Nincs ilyen ugyfél.");
                        return;
                    }

                    Console.WriteLine(ugyfel);
                }

                static void KeresUgyfelNev()
                {
                    Console.Write("Név részlet: ");
                    string name = Console.ReadLine();
                    Ugyfel ugyfel = null;
                    ugyfel = Ugyfelek.UgyfelLekerdezNameAlapjan(name);
                    if (ugyfel == null)
                    {
                        Console.WriteLine("Nincs találat.");
                        return;
                    }

                    Console.WriteLine(ugyfel);
                }

                static void ModositasUgyfel()
                {
                    Console.Write("Módosítandó ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Új név: ");
                    string name = Console.ReadLine();

                    Console.Write("Új email: ");
                    string email = Console.ReadLine();

                    Console.Write("Új telefon: ");
                    string phone = Console.ReadLine();

                    Console.Write("Új lakcím: ");
                    string address = Console.ReadLine();

                    bool siker = false;
                    siker = Ugyfelek.UgyfelModositasaIdAlapjan(id, name, email, phone, address);
                    Console.WriteLine(siker ? "✔ Sikeres módosítás" : "✖ Nincs ilyen ügyfél");
                }

                static void TorlesUgyfel()
                {
                    Console.Write("Törlendő ID: ");
                    int id = int.Parse(Console.ReadLine());
                    bool siker = false;
                    siker = Ugyfelek.UgyfelTorleseIdAlapjan(id);
                    Console.WriteLine(siker ? "✔ Ügyfél törölve" : "✘ Nincs ilyen ügyfél");
                }

                static void UjDolgozo()
                {
                    Console.Write("Név: ");
                    string name = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    Console.Write("Pozíció: ");
                    string position = Console.ReadLine();

                    Dolgozok.UjDolgozoFelvesz(name, email, phone, position);
                    Console.WriteLine("✔ Dolgozó felvéve");
                }

                static void OsszesDolgozo()
                {
                    List<Dolgozo> lista = new List<Dolgozo>();
                    lista = Dolgozok.OsszesDolgozoLekerdez();

                    if (!lista.Any())
                    {
                        Console.WriteLine("Nincs rögzített dolgozó.");
                        return;
                    }

                    foreach (var dolgozo in lista)
                    {
                        Console.WriteLine(dolgozo);
                    }
                }

                static void KeresDolgozoId()
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Dolgozo dolgozo = null;
                    dolgozo = Dolgozok.DolgozoLekerdezIdAlapjan(id);
                    if (dolgozo == null)
                    {
                        Console.WriteLine("Nincs ilyen dolgozó.");
                        return;
                    }

                    Console.WriteLine(dolgozo);
                }

                static void KeresDolgozoNev()
                {
                    Console.Write("Név részlet: ");
                    string name = Console.ReadLine();
                    Dolgozo dolgozo = null;
                    dolgozo = Dolgozok.DolgozoLekerdezNameAlapjan(name);
                    if (dolgozo == null)
                    {
                        Console.WriteLine("Nincs találat.");
                        return;
                    }

                    Console.WriteLine(dolgozo);
                }

                static void ModositasDolgozo()
                {
                    Console.Write("Módosítandó ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Új név: ");
                    string name = Console.ReadLine();

                    Console.Write("Új email: ");
                    string email = Console.ReadLine();

                    Console.Write("Új telefon: ");
                    string phone = Console.ReadLine();

                    Console.Write("Új pzíció: ");
                    string position = Console.ReadLine();

                    bool siker = false;
                    siker = Dolgozok.DolgozoModositasaIdAlapjan(id, name, email, phone, position);
                    Console.WriteLine(siker ? "✔ Sikeres módosítás" : "✖ Nincs ilyen dolgozó");
                }

                static void TorlesDolgozo()
                {
                    Console.Write("Törlendő ID: ");
                    int id = int.Parse(Console.ReadLine());
                    bool siker = false;
                    siker = Dolgozok.DolgozoTorleseIdAlapjan(id);
                    Console.WriteLine(siker ? "✔ Dolgozó törölve" : "✘ Nincs ilyen dolgozó");
                }
            }
            while(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Artikli
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int i;
            char unos = ' ';
            List<string> sifra = new List<string>();
            List<string> naziv = new List<string>();
            List<int> cena = new List<int>();
            List<int> kolicina = new List<int>();

            while (unos != '6')
            {
                Console.Clear();
                Console.WriteLine("[MENI]\n");

                Console.WriteLine("---------------------");
                Console.WriteLine("1 - Dodaj artikal");
                Console.WriteLine("2 - Lista artikala");
                Console.WriteLine("3 - Promena artikla");
                Console.WriteLine("4 - Pretraga");
                Console.WriteLine("5 - Brisanje artikla");
                Console.WriteLine("6 - Izlaz");
                Console.WriteLine("---------------------");
                Console.Write("Izaberite :");

                unos = Console.ReadKey().KeyChar;
                Console.Write("\n");

                Console.Clear();

                switch (unos)
                {
                    case '1':

                        Console.WriteLine("[UNOS]\n");

                        string zaUnos;

                        do
                        {
                            Console.Write("Unesite ime artikla ( 0 za izlazak ) :");
                            zaUnos = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(zaUnos));
                        if (zaUnos == "0")
                        {
                            break;
                        }
                        naziv.Add(zaUnos);

                        do
                        {
                            Console.Write("Unesite cenu artikla :");
                            zaUnos = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(zaUnos));
                        cena.Add(int.Parse(zaUnos));


                        do
                        {
                            Console.Write("Unesite sifru artikla :");
                            zaUnos = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(zaUnos));
                        sifra.Add(zaUnos);


                        do
                        {
                            Console.Write("Unesite kolicinu artikla :");
                            zaUnos = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(zaUnos));
                        kolicina.Add(int.Parse(zaUnos));

                        break;

                    case '2':
                        Console.WriteLine("[LISTA]\n");
                        for (i = 0; i < cena.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}:{naziv[i]} --- {cena[i]} rsd --- {sifra[i]} --- {kolicina[i]} komada ");
                        }
                        Console.Write("\nPritisnite bilo koji taster za povratak na meni :");
                        Console.ReadKey();
                        break;

                    case '3':
                        Console.WriteLine("[PROMENA ARTIKALA]\n");
                        char stanje;

                        int indeksZaPromenu;
                        int promena;

                        do
                        {
                            Console.Write("Unesite indeks prozivoda :");
                            indeksZaPromenu = int.Parse(Console.ReadLine()) - 1;
                        } while (indeksZaPromenu < 0 || indeksZaPromenu > naziv.IndexOf(naziv.Last()));
                        Console.WriteLine($"\nMenjate artikl :{indeksZaPromenu + 1}:{naziv[indeksZaPromenu]} --- {cena[indeksZaPromenu]} rsd --- {sifra[indeksZaPromenu]} --- {kolicina[indeksZaPromenu]} komada\n");

                        do
                        {
                            Console.Write("Unesite 1 za promenu cene, a 2 za promenu kolicine, 0 za izlazak :");
                            stanje = Console.ReadKey().KeyChar;
                            Console.Write("\n");
                        } while (stanje != '2' && stanje != '1' && stanje != '0');

                        if( stanje == '0')
                        {
                            break;
                        }

                        if (stanje == '1')
                        {
                            do
                            {
                                Console.Write($"Unesite novu cenu ( trenutna cena {cena[indeksZaPromenu]} ) :");
                                promena = int.Parse(Console.ReadLine());
                            } while (promena <= 0);
                           
                            cena[indeksZaPromenu] = promena;
                        }
                        if(stanje == '2')
                        {
                            do
                            {
                                Console.Write($"Unesite promenu u kolicini ( trenutna kolicina {kolicina[indeksZaPromenu]} ):");
                                promena = int.Parse(Console.ReadLine());
                            } while (kolicina[indeksZaPromenu] + promena < 0);
                            kolicina[indeksZaPromenu] += promena;
                            
                        }

                        break;

                    case '4':
                        Console.WriteLine("[PRETAGA]\n");
                        string pretraga;
                        Console.Write("Unesite ime artikla :");
                        pretraga = Console.ReadLine();

                        for(i = 0; i < naziv.Count; i++)
                        {
                            if (naziv[i].ToLower().Contains(pretraga.ToLower()))
                            {
                                Console.WriteLine($"{i + 1}:{naziv[i]} --- {cena[i]} rsd --- {sifra[i]} --- {kolicina[i]} komada ");
                            }
                        }

                        Console.Write("\nPritisnite bilo koji taster za povratak na meni :");
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.WriteLine("[BRISANJE]\n");
                        int indeksZaBrisanje;
                        char daLiBrisati;
                        string zaBrisanje;
                        do
                        {
                            Console.Write("Unesite ime artikla kojeg zelite da izbrisete :");
                            zaBrisanje = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(zaBrisanje));
                        
                        for(i = 0; i < naziv.Count; i++)
                        {
                            if (naziv[i].ToLower().Contains(zaBrisanje.ToLower()))
                            {
                                do
                                {
                                    Console.Write($"Da li zelite da izbrisete artikl {naziv[i]} ? (D/N/0) :");
                                    daLiBrisati = Console.ReadKey().KeyChar;
                                    Console.Write("\n");
                                } while (daLiBrisati != 'D' && daLiBrisati != 'N' && daLiBrisati != '0');

                                if(daLiBrisati == 'D')
                                {
                                    naziv.RemoveAt(i);
                                    cena.RemoveAt(i);
                                    kolicina.RemoveAt(i);
                                    sifra.RemoveAt(i);

                                    break;
                                }

                                if(daLiBrisati == '0')
                                {
                                    break;
                                }

                            }
                        }

                        break;
                    case '6':
                        Console.WriteLine("Bye :)");
                        break;
                }

            }
            
            Console.ReadKey();
        }
    }
}

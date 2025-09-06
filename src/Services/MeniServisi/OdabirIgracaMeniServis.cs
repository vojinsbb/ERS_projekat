using Domain.Modeli;
using Domain.Servisi;

namespace Services.MeniServisi
{
    public class OdabirIgracaMeniServis : IOdabirIgracaServis
    {
        private static List<Igrac> izabraniIgraci = new List<Igrac>();

        public void ClearList()
        {
            izabraniIgraci.Clear();
        }

        public int[] Odaberi(int brojIgraca, List<Igrac> sviIgraci, bool test)
        {
            int[] indexes = new int[brojIgraca];

            int i = 0;
            if (!test)
            {
                while (i < brojIgraca)
                {
                    Console.WriteLine();
                    Console.WriteLine("IZABERITE " + (i + 1) + ". OD " + brojIgraca + " IGRACA\n");
                    Console.WriteLine("\tONLINE IGRACI:");

                    int rBr = 1;
                    foreach (Igrac ig in sviIgraci)
                    {
                        if (!izabraniIgraci.Contains(ig) && ig.Online)
                            Console.WriteLine("\tIGRAC BROJ " + rBr + ": " + ig.KorisnickoIme);
                        rBr++;

                    }

                    Console.Write("KOMANDA: ");


                    try
                    {
                        int idx = Convert.ToInt32(Console.ReadLine());
                        if (!izabraniIgraci.Contains(sviIgraci[idx - 1]) && sviIgraci[idx - 1].Online)
                        {
                            izabraniIgraci.Add(sviIgraci[idx - 1]);
                            indexes[i] = idx - 1;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("NEISPRAVAN UNOS. UNESITE PONOVO.");
                            Console.WriteLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("NEISPRAVAN UNOS. UNESITE PONOVO.");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                while (i < brojIgraca)
                {
                    Console.WriteLine();
                    Console.WriteLine("IZABERITE " + (i + 1) + ". OD " + brojIgraca + " IGRACA\n");
                    Console.WriteLine("\tONLINE IGRACI:");

                    int rBr = 1;
                    foreach (Igrac ig in sviIgraci)
                    {
                        if (!izabraniIgraci.Contains(ig) && ig.Online)
                            Console.WriteLine("\tIGRAC BROJ " + rBr + ": " + ig.KorisnickoIme);
                        rBr++;
                    }

                    Console.Write("KOMANDA: ");
                    int idx = new Random().Next(1, 25);
                    Thread.Sleep(400);
                    Console.WriteLine(idx);
                    Thread.Sleep(300);

                    try
                    {
                        if (!izabraniIgraci.Contains(sviIgraci[idx - 1]) && sviIgraci[idx - 1].Online)
                        {
                            izabraniIgraci.Add(sviIgraci[idx - 1]);
                            indexes[i] = idx - 1;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("NEISPRAVAN UNOS. UNESITE PONOVO.");
                            Console.WriteLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("NEISPRAVAN UNOS. UNESITE PONOVO.");
                        Console.WriteLine();
                    }
                    Thread.Sleep(300);
                }

            }

            return indexes;
        }
    }
}

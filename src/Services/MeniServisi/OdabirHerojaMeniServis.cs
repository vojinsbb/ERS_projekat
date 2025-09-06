using Domain.Modeli;
using Domain.Servisi;

namespace Services.MeniServisi
{
    public class OdabirHerojaMeniServis : IOdabirHerojaServis
    {
        private static List<Heroj> izabraniHeroji = new List<Heroj>();

        public void ClearList()
        {
            izabraniHeroji.Clear();
        }

        public int[] Odaberi(int brojHeroja, List<Heroj> ponudjeniHeroji, bool test)
        {

            int[] indexes = new int[brojHeroja];

            int i = 0;
            if (!test)
            {
                while (i < brojHeroja)
                {
                    Console.WriteLine();
                    Console.WriteLine("IZABERITE " + (i + 1) + ". OD " + brojHeroja + " HEROJA\n");
                    Console.WriteLine("\tDOSTUPNI HEROJI:");

                    int rBr = 1;
                    foreach (Heroj h in ponudjeniHeroji)
                    {
                        if (!izabraniHeroji.Contains(h))
                            Console.WriteLine("\tHEROJ BROJ " + rBr + ": " + h.Naziv + " (ATK " + h.JacinaNapada + ")");
                        rBr++;
                    }

                    Console.Write("KOMANDA: ");

                    try
                    {
                        int idx = Convert.ToInt32(Console.ReadLine());
                        if (!izabraniHeroji.Contains(ponudjeniHeroji[idx - 1]))
                        {
                            izabraniHeroji.Add(ponudjeniHeroji[idx - 1]);
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
                while (i < brojHeroja)
                {
                    Console.WriteLine();
                    Console.WriteLine("IZABERITE " + (i + 1) + ". OD " + brojHeroja + " HEROJA\n");
                    Console.WriteLine("\tDOSTUPNI HEROJI:");

                    int rBr = 1;
                    foreach (Heroj h in ponudjeniHeroji)
                    {
                        if (!izabraniHeroji.Contains(h))
                            Console.WriteLine("\tHEROJ BROJ " + rBr + ": " + h.Naziv + " (ATK " + h.JacinaNapada + ")");
                        rBr++;
                    }

                    Console.Write("KOMANDA: ");
                    int idx = new Random().Next(1, 25);
                    Thread.Sleep(400);
                    Console.WriteLine(idx);
                    Thread.Sleep(300);

                    try
                    {
                        if (!izabraniHeroji.Contains(ponudjeniHeroji[idx - 1]))
                        {
                            izabraniHeroji.Add(ponudjeniHeroji[idx - 1]);
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

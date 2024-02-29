using ConsoleProject;
using Ulamki;
namespace Ulamki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ulamek a = new Ulamek(8,42);
            Ulamek b = new Ulamek(5,7);
            a.Uprosc();
            Console.WriteLine(a.Equals(a));

            Ulamek[] zbiorUlamkow = new Ulamek[10];
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int licznik = rand.Next(1, 6);
                int mianownik = rand.Next(6, 12);

                Ulamek ulamek = new Ulamek(licznik, mianownik);
                zbiorUlamkow[i] = ulamek;
            }

            foreach (var value in zbiorUlamkow) { Console.Write(value + ", "); }
            Console.WriteLine();
            Array.Sort(zbiorUlamkow);
            foreach (var value in zbiorUlamkow) { Console.Write(value + ", "); }
        }
    }
}

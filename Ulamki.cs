using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Ulamek : IComparable<Ulamek>, IEquatable<Ulamek>
    {
        private int licznik;
        private int mianownik;

        public Ulamek(int Ilicznik, int Imianownik)
        {
            licznik = Ilicznik;
            mianownik = Imianownik;
        }
        public static Ulamek operator *(Ulamek valueA, Ulamek valueB) => new Ulamek(valueA.licznik * valueB.licznik, valueA.mianownik * valueB.mianownik);
        public static Ulamek operator /(Ulamek valueA, Ulamek valueB) => new Ulamek(valueA.licznik * valueB.mianownik, valueA.mianownik * valueB.licznik);
        public static bool operator !=(Ulamek valueA, Ulamek valueB) => (valueA.ToString() != valueB.ToString());
        public static bool operator ==(Ulamek valueA, Ulamek valueB) => (valueA.ToString() == valueB.ToString());
        public static Ulamek operator +(Ulamek valueA, Ulamek valueB)
        {
            int nowyMianownik = valueA.mianownik * valueB.mianownik;
            int nowyLiczebnik = (valueA.licznik * valueB.mianownik)+(valueB.licznik * valueA.mianownik);
            Ulamek nowyUlamek = new Ulamek(nowyLiczebnik, nowyMianownik);
            nowyUlamek.Uprosc();
            return nowyUlamek;
        }
        public static Ulamek operator -(Ulamek valueA, Ulamek valueB)
        {
            if (valueA == valueB) return new Ulamek(0,0);
            int newMianownik = valueA.mianownik * valueB.mianownik;
            int newLiczebnik = (valueA.licznik * valueB.mianownik) - (valueB.licznik * valueA.mianownik);
            Ulamek newUlamek = new Ulamek(newLiczebnik, newMianownik);
            newUlamek.Uprosc();
            return newUlamek;
        }
        public Ulamek Polowa()
        {
            Ulamek newUlamek = new Ulamek(licznik, mianownik * 2);
            newUlamek.Uprosc();
            return newUlamek;
        }
        public Ulamek Cwiark()
        {
            Ulamek newUlamek = new Ulamek(licznik, mianownik * 4);
            newUlamek.Uprosc();
            return newUlamek;
        }
        public void Uprosc()
        {
            int nod = GCD();
            licznik = licznik/nod;
            mianownik = mianownik/nod;
        }
        private int GCD()
        {
            int a, b;
            if (licznik > mianownik)
            {
                a = licznik;
                b = mianownik;
            }
            else
            {
                a = mianownik;
                b = licznik;
            }
            int nod, remainder;
            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            nod = a;
            return nod;
        }

        public override string ToString() { return $"{licznik.ToString()}/{mianownik.ToString()}"; }
        public int CompareTo(Ulamek? other)
        {
            if ((float)licznik/mianownik > (float)other.licznik/other.mianownik) return 1;
            if ((float)licznik/mianownik == (float)other.licznik/other.mianownik) return 0;
            return -1;
        }

        public bool Equals(Ulamek? other)
        {
            return this.licznik == other.licznik && other.mianownik==this.mianownik;
        }
        public override bool Equals(object? other)
        {
            if (other is Ulamek)
            {
                return this.Equals(other);
            }
            return false;
        }
    }
}
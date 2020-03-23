using System;

namespace Bank
{
    /// <summary>
    /// Bank fiók demo osztály.
    /// </summary>
    public class BankFiok
    {
        private readonly string m_ugyfelNev;
        private double m_egyenleg;

        public const string TerhelesTullepiAzEgyenlegetUzenet = "A terhelés összeg meghaladja az egyenleget.";
        public const string TerhelesKisebbMintNullaUzenet = "A terhelési összeg kisebb, mint nulla";

        private BankFiok() { }

        public BankFiok(string ugyfelNev, double egyenleg)
        {
            m_ugyfelNev = ugyfelNev;
            m_egyenleg = egyenleg;
        }

        public string UgyfelNev
        {
            get { return m_ugyfelNev; }
        }

        public double Egyenleg
        {
            get { return m_egyenleg; }
        }

        public void Terheles(double osszeg)
        {
            if (osszeg > m_egyenleg)
            {
                throw new ArgumentOutOfRangeException("osszeg", osszeg, TerhelesTullepiAzEgyenlegetUzenet);
            }

            if (osszeg < 0)
            {
                throw new ArgumentOutOfRangeException("osszeg ", osszeg, TerhelesKisebbMintNullaUzenet);
            }

            m_egyenleg -= osszeg;
        }

        public void Jovairas(double osszeg)
        {
            if (osszeg < 0)
            {
                throw new ArgumentOutOfRangeException("osszeg");
            }

            m_egyenleg += osszeg;
        }

        public static void Main()
        {
            BankFiok bf = new BankFiok("Mr. Bryan Walton", 11.99);

            bf.Jovairas(5.77);
            bf.Terheles(11.22);
            Console.WriteLine("Jelenlegi egyenlege: ${0}", bf.Egyenleg);
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankFiokTests
    {
        [TestMethod]
        public void Terheles_ErvenyesOsszeggel_EgyenlegFrissites()
        {
            // Elrendez�s
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = 4.55;
            double elvartErtek = 7.44;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // M�velet
            fiok.Terheles(terhelesOsszeg);

            // Ellen�rz�s
            double jelenlegiOsszeg = fiok.Egyenleg;
            Assert.AreEqual(elvartErtek, jelenlegiOsszeg, 0.001, "A sz�mla terhel�se nem megfelel�.");
        }

        [TestMethod]
        public void Terheles_OsszegKevesebbNullanal_ArgumentumHiba()
        {
            // Elrendez�s
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = -100.00;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // M�velet �s ellen�rz�s
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => fiok.Terheles(terhelesOsszeg));
        }

        [TestMethod]
        public void Terheles_OsszegNagyobbAzEgyenlegnel_ArgumentumHiba()
        {
            // Elrendez�s
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = 15;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // M�velet
            try
            {
                fiok.Terheles(terhelesOsszeg);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Ellen�rz�s
                StringAssert.Contains(e.Message, BankFiok.TerhelesTullepiAzEgyenlegetUzenet);
                return;
            }

            Assert.Fail("A v�rt kiv�tel nem ker�lt el�.");
        }
    }
}

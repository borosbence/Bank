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
            // Elrendezés
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = 4.55;
            double elvartErtek = 7.44;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // Mûvelet
            fiok.Terheles(terhelesOsszeg);

            // Ellenõrzés
            double jelenlegiOsszeg = fiok.Egyenleg;
            Assert.AreEqual(elvartErtek, jelenlegiOsszeg, 0.001, "A számla terhelése nem megfelelõ.");
        }

        [TestMethod]
        public void Terheles_OsszegKevesebbNullanal_ArgumentumHiba()
        {
            // Elrendezés
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = -100.00;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // Mûvelet és ellenõrzés
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => fiok.Terheles(terhelesOsszeg));
        }

        [TestMethod]
        public void Terheles_OsszegNagyobbAzEgyenlegnel_ArgumentumHiba()
        {
            // Elrendezés
            double kezdoEgyenleg = 11.99;
            double terhelesOsszeg = 15;
            BankFiok fiok = new BankFiok("Mr. Bryan Walton", kezdoEgyenleg);

            // Mûvelet
            try
            {
                fiok.Terheles(terhelesOsszeg);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Ellenõrzés
                StringAssert.Contains(e.Message, BankFiok.TerhelesTullepiAzEgyenlegetUzenet);
                return;
            }

            Assert.Fail("A várt kivétel nem került elõ.");
        }
    }
}

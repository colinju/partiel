using BankTranfertLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bankTransfert = new BankTransfert();
            bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");
        }
    }
}

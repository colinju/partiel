using BankTranfertLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTransfertOK()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            var result = bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestFromIbanEmpty()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "", "8546129856"));
        }

        [TestMethod]
        public void TestFromIbanEmptyMessage()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "", "8546129856"), "Both IBAN should have a value");
        }

        [TestMethod]
        public void TestFromIbanIncorrect()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "+-5/58415", "8546129856"));
        }

        [TestMethod]
        public void TestFromIbanIncorrectMessage()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "+-5/58415", "8546129856"), "Incorrect iban");
        }

        [TestMethod]
        public void TestToIbanEmpty()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "78654786313", ""));
        }

        [TestMethod]
        public void TestToIbanEmptyMessage()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "78654786313", ""), "Both IBAN should have a value");
        }

        [TestMethod]
        public void TestToIbanIncorrect()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "78654786313", "+-5/58415"));
        }

        [TestMethod]
        public void TestToIbanIncorrectMessage()
        {
            //Arrange
            var bankTransfert = new BankTransfert();

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => bankTransfert.Transfert(1, 12.2m, "78654786313", "+-5/58415"), "Incorrect iban");
        }

        [TestMethod]
        public void TestLogTxt()
        {
            //Arrange
            var logger = new LoggerTxt();
            var title = $"Logs_{ DateTime.Now.ToString("dd_MM_yy")}.txt";
            //Act
            logger.Log(Severity.Info, "log de test");

            //Assert
            string[] lines = System.IO.File.ReadAllLines(title);
            Assert.AreEqual("Info - log de test", lines[lines.Length -1]); 
        }

        [TestMethod]
        public void TestLogtransactionTxt()
        {
            //Arrange
            var logger = new LoggerTxt();
            var title = $"Transction_{ DateTime.Now.ToString("dd_MM_yy")}.txt";

            //Act
            Assert.ThrowsException<NotImplementedException>(() => logger.LogTransaction(1,10,"123","321"));
        }

        [TestMethod]
        public void TestLogCsv()
        {
            //Arrange
            var logger = new LoggerCsv();
            var title = $"Logs_{ DateTime.Now.ToString("dd_MM_yy")}.csv";

            //Act
            Assert.ThrowsException<NotImplementedException>(() => logger.Log(Severity.Info, "log de test"));
        }


        [TestMethod]
        public void TestLogTransactionCSV()
        {
            //Arrange
            var logger = new LoggerCsv();
            var title = $"Transaction_{ DateTime.Now.ToString("dd_MM_yy")}.csv";
            //Act
            logger.LogTransaction(1, 10, "123", "321");

            //Assert
            string[] lines = System.IO.File.ReadAllLines(title);
            Assert.AreEqual("1;10;123;321", lines[lines.Length - 1]);
        }


    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankTranfertLibrary
{
    public class BankTransfert
    {
        public LoggerCsv CSVLogger { get; set; } = new LoggerCsv();
        public LoggerTxt TXTLogger { get; set; } = new LoggerTxt();

        public bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {

            if (string.IsNullOrEmpty(fromBankIban) || string.IsNullOrEmpty(toBankIban))
            {
                TXTLogger.Log(Severity.Error, "Both IBAN should have a value");
                throw new ArgumentNullException();
            }

            if (!fromBankIban.All(c => Char.IsLetterOrDigit(c)) || !toBankIban.All(c => Char.IsLetterOrDigit(c)))
            {
                TXTLogger.Log(Severity.Error, "Incorrect iban");
                throw new ArgumentNullException("Incorrect iban");
            }

            

            var hasTransfered = EmulateTransfert(amount, fromBankIban, toBankIban);

            if (!hasTransfered)
            {
                TXTLogger.Log(Severity.Error, "Transfert interrupted");
                throw new InvalidOperationException();
            }


            CSVLogger.LogTransaction(transactionId, amount, fromBankIban, toBankIban);

            return true;
        }

        /// <summary>
        /// Cette méthode émule une transfert bancaire vers un tiers
        /// Elle se compose d'un timeout et renvoie true
        /// Tester le temps d'execution de la méthod transfert car elle doit toujours être inférieur à 5sec
        /// </summary>
        /// <returns></returns>
        public bool EmulateTransfert(decimal amount, string fromBankIban, string toBankIban)
        {
            System.Threading.Thread.Sleep((int)TimeSpan.FromSeconds(4).TotalMilliseconds);

            return true;
        }


    }
}

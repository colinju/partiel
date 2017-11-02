using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankTranfertLibrary
{
    public class BankTransfert
    {
        Logger log = new Logger();

        public bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            if (string.IsNullOrEmpty(fromBankIban) || string.IsNullOrEmpty(toBankIban))
            {
                log.Log(Severity.Error, "Both IBAN should have a value");
                throw new ArgumentNullException();
            }

            var hasTransfered = EmulateTransfert(amount, fromBankIban, toBankIban);

            if (!hasTransfered)
            {
                log.Log(Severity.Error, "Transfert interrupted");
                throw new InvalidOperationException();
            }

            //write csv
            var csv = new StringBuilder();
            // chemin : BankTranfertLibrary\BankTransfertLibraryTest\bin\Debug\netcoreapp2.0
            var csvTitle = $"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv";

            if (!File.Exists(csvTitle))
            {
                using (StreamWriter sw = File.CreateText(csvTitle))
                {
                    sw.WriteLine("Transaction;Amount;From;To");
                }
            }

            var line = $"{transactionId};{amount};{fromBankIban};{toBankIban}";
            using (StreamWriter sw = File.AppendText(csvTitle))
            {
                sw.WriteLine(line);
            }


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

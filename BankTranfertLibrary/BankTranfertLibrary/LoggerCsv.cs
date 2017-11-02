using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankTranfertLibrary
{
    public class LoggerCsv : ILogger
    {
        public void Log(Severity severity, string message)
        {
            throw new NotImplementedException();
            
        }

        public void LogTransaction(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
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
        }
    }
}

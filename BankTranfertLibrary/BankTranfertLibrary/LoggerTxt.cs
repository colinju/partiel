using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankTranfertLibrary
{
    public class LoggerTxt : ILogger
    {
        public void Log(Severity severity, string message)
        {
            //write txt
            var txt = new StringBuilder();
            // chemin : BankTranfertLibrary\BankTransfertLibraryTest\bin\Debug\netcoreapp2.0
            var txtTitle = $"Logs_{DateTime.Now.ToString("dd_MM_yy")}.txt";

            if (!File.Exists(txtTitle))
            {
                using (StreamWriter sw = File.CreateText(txtTitle))
                {
                    sw.WriteLine("Fichier de logs");
                }
            }

            using (StreamWriter sw = File.AppendText(txtTitle))
            {
                sw.WriteLine($"{severity.ToString()} - {message}");
            }
        }

        public void LogTransaction(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            throw new NotImplementedException();
        }
    }
}

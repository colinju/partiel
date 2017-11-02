using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary
{
    interface ILogger
    {
        void Log(Severity severity, string message);
        void LogTransaction(uint transactionId, decimal amount, string fromBankIban, string toBankIban);
    }
}

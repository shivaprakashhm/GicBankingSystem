using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GicBankingSystem
{
    internal class Customer
    {
        public decimal BankBalanceAmount { get; set; } = 0;

        private List<CustomerTransactionLog> tranactionLogs;

        public Customer()
        {
            tranactionLogs = new List<CustomerTransactionLog>();
        }

        public void Deposit(decimal depositAmount)
        {
            BankBalanceAmount += depositAmount;
            tranactionLogs.Add(new CustomerTransactionLog(depositAmount, BankBalanceAmount));
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            if(BankBalanceAmount < withdrawalAmount)
            {
                //Invalid withdraw Request
                return;
            }
                
            BankBalanceAmount -= withdrawalAmount;
            tranactionLogs.Add(new CustomerTransactionLog(-withdrawalAmount, BankBalanceAmount));
        }

        public void PrintStatement()
        {
            //Console.WriteLine("Date                  | Amount  | Balance");
            Console.WriteLine($"{"Date",-25}| {"Amount",20}  | {"Balance",20}");
            foreach (CustomerTransactionLog log in tranactionLogs.OrderBy(x => x.LogDateTime))
            {
                Console.WriteLine($"{log.LogDateTime,-25:d MMM yyyy hh:mm:sstt}| {log.InputAmount,20:0.00}  | {log.BalanceAmount,20:0.00}");
            }
        }
    }
}

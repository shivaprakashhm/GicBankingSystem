using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicBankingSystem
{
    internal class CustomerTransactionLog
    {
        public DateTimeOffset LogDateTime { get; set; } = DateTimeOffset.Now;
        public decimal InputAmount { get; set; }
        public decimal BalanceAmount { get; set; }

        public CustomerTransactionLog(decimal inputAmount, decimal balanceAmount)
        {
            InputAmount = inputAmount;
            BalanceAmount = balanceAmount;
        }
    }
}

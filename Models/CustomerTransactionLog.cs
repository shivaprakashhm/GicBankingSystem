using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GicBankingSystem.Models
{
    public class CustomerTransactionLog
    {
        [Key]
        public Guid TransactionLogId { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }
        public DateTimeOffset LogDateTime { get; set; } = DateTimeOffset.Now;
        public decimal InputAmount { get; set; }
        public decimal BalanceAmount { get; set; }

        public CustomerTransactionLog(Guid customerId, decimal inputAmount, decimal balanceAmount)
        {
            CustomerId = customerId;
            InputAmount = inputAmount;
            BalanceAmount = balanceAmount;
        }
    }
}

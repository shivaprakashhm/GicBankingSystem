using System.ComponentModel.DataAnnotations;

namespace GicBankingSystem.Models
{
    public class Customer: ICustomer
    {
        [Key]
        public Guid CustomerId { get; set; }

        public decimal BankBalanceAmount { get; set; } = 0;

        public Customer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public void Deposit(decimal depositAmount)
        {
            BankBalanceAmount += depositAmount;
            
        }

        public bool Withdraw(decimal withdrawalAmount)
        {
            if (BankBalanceAmount < withdrawalAmount)
            {
                //Invalid withdraw Request
                return false;
            }

            BankBalanceAmount -= withdrawalAmount;
            return true;
            
        }
    }
}


namespace GicBankingSystem.Models
{
    public interface ICustomer
    {
        void Deposit(decimal depositAmount);
        bool Withdraw(decimal withdrawalAmount);
    }
}

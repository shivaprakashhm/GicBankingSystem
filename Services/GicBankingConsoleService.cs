using GicBankingSystem.Constants;
using GicBankingSystem.DataAccess;
using GicBankingSystem.Models;

namespace GicBankingSystem.Services
{
    public class GicBankingConsoleService
    {
        public GicBankingConsoleService() { }

        public void LaunchService(Customer customer, GicBankingDbContext dbContext)
        {
            Console.WriteLine("Welcome to AwesomeGIC Bank! What would you like to do?");

            char inputAction;

            do
            {
                inputAction = GetCustomerActionInput();

                switch (inputAction)
                {
                    case CustomerInputAction.Deposit:
                        Console.WriteLine("Please enter the amount to deposit:");
                        decimal inputDepositAmount;
                        if (decimal.TryParse(Console.ReadLine(), out inputDepositAmount) && inputDepositAmount > 0)
                        {
                            customer.Deposit(inputDepositAmount);

                            dbContext.Customers.Update(customer);
                            dbContext.CustomerTransactionLogs.Add(new CustomerTransactionLog(customer.CustomerId, inputDepositAmount, customer.BankBalanceAmount));
                            dbContext.SaveChanges();

                            Console.WriteLine($"Thank you. ${inputDepositAmount:0.00} has been deposited to your account.\r\nIs there anything else you'd like to do?");
                        }

                        break;

                    case CustomerInputAction.Withdraw:
                        Console.WriteLine("Please enter the amount to withdraw:");
                        decimal inputWithdrawAmount;
                        if (decimal.TryParse(Console.ReadLine(), out inputWithdrawAmount) && inputWithdrawAmount > 0)
                        {
                            bool isWithdrawSuccessful = customer.Withdraw(inputWithdrawAmount);

                            if (!isWithdrawSuccessful)
                            {
                                Console.WriteLine($"Invalid withdraw Request.\r\nIs there anything else you'd like to do?");
                                break;
                            }

                            dbContext.CustomerTransactionLogs.Add(new CustomerTransactionLog(customer.CustomerId, -inputWithdrawAmount, customer.BankBalanceAmount));
                            dbContext.Customers.Update(customer);
                            dbContext.SaveChanges();

                            Console.WriteLine($"Thank you. ${inputWithdrawAmount:0.00} has been withdrawn.\r\nIs there anything else you'd like to do?");
                        }
                        break;

                    case CustomerInputAction.PrintStatement:
                        var tranactionLogs = dbContext.CustomerTransactionLogs.Where(x => x.CustomerId == customer.CustomerId).ToList();
                        Console.WriteLine($"{"Date",-25}| {"Amount",20}  | {"Balance",20}");
                        foreach (CustomerTransactionLog log in tranactionLogs.OrderBy(x => x.LogDateTime))
                        {
                            Console.WriteLine($"{log.LogDateTime,-25:d MMM yyyy hh:mm:sstt}| {log.InputAmount,20:0.00}  | {log.BalanceAmount,20:0.00}");
                        }

                        Console.WriteLine("Is there anything else you'd like to do?");
                        break;

                    case CustomerInputAction.Quit:
                        Console.WriteLine("Thank you for banking with AwesomeGIC Bank.\r\nHave a nice day!");
                        break;
                }

            } while (inputAction != CustomerInputAction.Quit);

        }

        private char GetCustomerActionInput()
        {
            Console.WriteLine("[D]eposit");
            Console.WriteLine("[W]ithdraw");
            Console.WriteLine("[P]rint statement");
            Console.WriteLine("[Q]uit");
            char inputAction;

            List<char> customerInputActions = new List<char>() { CustomerInputAction.Deposit, CustomerInputAction.Withdraw, CustomerInputAction.PrintStatement, CustomerInputAction.Quit };
            while (!char.TryParse(Console.ReadLine(), out inputAction) && !customerInputActions.Any(input => input == char.ToUpper(inputAction)))
            {
                Console.WriteLine("Please Enter valid Input:");
            }

            return char.ToUpper(inputAction);
        }
    }
}

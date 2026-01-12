using GicBankingSystem;

Console.WriteLine("Welcome to AwesomeGIC Bank! What would you like to do?");

char inputAction;
Customer customer = new();

do
{
    inputAction = GetCustomerActionInput();

    switch(inputAction)
    {
        case 'D':
            Console.WriteLine("Please enter the amount to deposit:");
            decimal inputDepositAmount;
            if(decimal.TryParse(Console.ReadLine(), out inputDepositAmount) && inputDepositAmount > 0)
            {
                customer.Deposit(inputDepositAmount);
                Console.WriteLine($"Thank you. ${inputDepositAmount:0.00} has been deposited to your account.\r\nIs there anything else you'd like to do?");
            }
            
            break;

        case 'W':
            Console.WriteLine("Please enter the amount to withdraw:");
            decimal inputWithdrawAmount;
            if (decimal.TryParse(Console.ReadLine(), out inputWithdrawAmount) && inputWithdrawAmount > 0)
            {
                customer.Withdraw(inputWithdrawAmount);
                Console.WriteLine($"Thank you. ${inputWithdrawAmount:0.00} has been withdrawn.\r\nIs there anything else you'd like to do?");
            }
            break;

        case 'P':
            customer.PrintStatement();
            Console.WriteLine("Is there anything else you'd like to do?");
            break;

        case 'Q':
            Console.WriteLine("Thank you for banking with AwesomeGIC Bank.\r\nHave a nice day!");
            break;
    }    
} while (inputAction !='Q');


static char GetCustomerActionInput()
{
    Console.WriteLine("[D]eposit");
    Console.WriteLine("[W]ithdraw");
    Console.WriteLine("[P]rint statement");
    Console.WriteLine("[Q]uit");
    char inputAction;

    List<char> allowedActions = new List<char>() { 'D', 'W', 'P', 'Q' };
    while(!char.TryParse(Console.ReadLine(), out inputAction) && !allowedActions.Any(input => input== char.ToUpper(inputAction)))
    {
        Console.WriteLine("Please Enter valid Input:");
    }

    return char.ToUpper(inputAction);
}

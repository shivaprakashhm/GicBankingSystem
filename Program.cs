using GicBankingSystem.DataAccess;
using GicBankingSystem.Models;
using GicBankingSystem.Services;

Guid customerid = Guid.NewGuid();
var dbContext = new GicBankingDbContext();
GicBankingConsoleService gicBankingConsoleService = new GicBankingConsoleService();
Customer customer = new Customer(customerid);
dbContext.Customers.Add(customer);
dbContext.SaveChanges();

gicBankingConsoleService.LaunchService(customer, dbContext);
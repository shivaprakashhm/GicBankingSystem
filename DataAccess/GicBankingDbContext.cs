using GicBankingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GicBankingSystem.DataAccess
{
    public class GicBankingDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\GIC\\GicBankingSystem\\GicBankingDb.mdf;Integrated Security=True");
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerTransactionLog> CustomerTransactionLogs { get; set; }
    }
}

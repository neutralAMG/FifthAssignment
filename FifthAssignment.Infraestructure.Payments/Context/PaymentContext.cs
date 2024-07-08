
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Infraestructure.Persistence.Context
{
    public class PaymentContext : DbContext
	{
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) 
        {
           
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("", m => m.MigrationsAssembly(typeof(PaymentContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Payment_Transactions");
		}
	}
}

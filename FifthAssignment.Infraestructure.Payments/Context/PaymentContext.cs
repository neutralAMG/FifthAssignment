
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Infraestructure.Persistence.Context
{
    public class PaymentContext : DbContext
	{
		public DbSet<Payment> Payments { get; set; }
		public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
		public DbSet<BeneficiaryPayment> BeneficiaryPayments { get; set; }
		public DbSet<LoanPayment> LoanPayments { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		public DbSet<PaymentType> PaymentTypes { get; set; }
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

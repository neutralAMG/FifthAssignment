
using FifthAssignment.Core.Domain.Entities.PaymentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FifthAssignment.Infraestructure.Persistence.Context
{
    public class PaymentContext : DbContext
	{
		public DbSet<Transaction> Payments { get; set; }
		public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
		public DbSet<BeneficiaryPayment> BeneficiaryPayments { get; set; }
		public DbSet<LoanPayment> LoanPayments { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		public DbSet<MoneyAdvance> MoneyAdvances { get; set; }
		public DbSet<TransactionType> PaymentTypes { get; set; }
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) 
        {
           
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=fifthAssingnment; Integrated Security=true; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(PaymentContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Payment_Transactions");

			modelBuilder.Entity<Transaction>(p =>
			{
				p.HasKey(p => p.Id);

				p.HasOne(p => p.TransactionDetail);
				p.HasOne(p => p.TransactionType).WithMany(p => p.Transactions).HasForeignKey(p => p.PaymentTypeId);

				p.HasIndex(p => p.TransactionDetail).IsClustered(false);
				p.HasIndex(p => p.TransactionType).IsClustered(false);


				p.Property(p => p.Amount).IsRequired();
				p.Property(p => p.DateCreated).IsRequired();
			});

			modelBuilder.Entity<CreditcardPayment>(c =>
			{
				c.HasKey(p => p.Id);

				c.Property(p => p.Amount).IsRequired();
				c.Property(p => p.DateCreated).IsRequired();
			});

			modelBuilder.Entity<BeneficiaryPayment>(b =>
			{
				b.HasKey(p => p.Id);

				b.Property(p => p.Amount).IsRequired();
				b.Property(p => p.DateCreated).IsRequired();
			});

			modelBuilder.Entity<LoanPayment>(l =>
			{
				l.HasKey(p => p.Id);

				l.Property(p => p.Amount).IsRequired();
				l.Property(p => p.DateCreated).IsRequired();
			});

			modelBuilder.Entity<Transfer>(t =>
			{
				t.HasKey(p => p.Id);

				t.Property(p => p.Amount).IsRequired();
				t.Property(p => p.DateCreated).IsRequired();
			});
			modelBuilder.Entity<MoneyAdvance>(m =>
			{
				m.HasKey(p => p.Id);

				m.Property(p => p.Amount).IsRequired();
				m.Property(p => p.DateCreated).IsRequired();
			});
			modelBuilder.Entity<TransactionType>(p =>
			{
				p.HasKey(p => p.Id);

			});
		}
	}
}

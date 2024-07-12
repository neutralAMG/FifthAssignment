using FifthAssignment.Core.Domain.Entities.PaymentContext;
using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Context
{
    public class fifthAssignmentContext : DbContext
	{

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Loan> Loans { get; set; }
		public DbSet<CreditCard> CreditCards { get; set; }
		public DbSet<Beneficiary> Beneficiaries { get; set; }
		public DbSet<FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction> Transactions { get; set; }
		public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
		public DbSet<ExpressPayment> ExpressPayments { get; set; }
		public DbSet<BeneficiaryPayment> BeneficiaryPayments { get; set; }
		public DbSet<LoanPayment> LoanPayments { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		public DbSet<MoneyAdvance> MoneyAdvances { get; set; }
		public DbSet<TransactionType> PaymentTypes { get; set; }
		public DbSet<TransactionDetail> TransactionDetails { get; set; }

		public fifthAssignmentContext()
        {
            
        }
        public fifthAssignmentContext(DbContextOptions<fifthAssignmentContext> options) : base(options) 
        {
           
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=fifthAssingnment; Integrated Security=true; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(fifthAssignmentContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			
			modelBuilder.Entity<Beneficiary>(b =>
			{
				b.HasKey(b => b.Id);
			//	b.HasOne<ApplicationUser>().WithMany( u => u.Beneficiaries).HasForeignKey(b => b.UserBeneficiaryId);

				
				b.HasIndex(b => b.UserId).IsClustered(false);
				b.HasIndex(b => b.UserBeneficiaryId).IsClustered(false);
			});

			modelBuilder.Entity<Loan>(l =>
			{
				l.HasKey(l => l.Id);

				//l.HasOne().WithMany(u => u.Loans).IsRequired().HasForeignKey( l => l.UserId);
				l.HasIndex(l => l.UserId).IsClustered(false);

				l.Property(l => l.IdentifierNumber).IsRequired();
				l.Property(l => l.Amount).IsRequired();
				l.Property(l => l.DateCreated).IsRequired();
				
			});
			modelBuilder.Entity<CreditCard>(c =>
			{
				c.HasKey(c => c.Id);

				//c.HasOne().WithMany(u => u.CreditCards).IsRequired().HasForeignKey(l => l.UserId);
				c.HasIndex(c => c.UserId).IsClustered(false);

				c.Property(c => c.Amount).IsRequired();
				c.Property(c => c.IdentifierNumber).IsRequired();
				c.Property(c => c.CVV).IsRequired();
				c.Property(c => c.CreditLimit).IsRequired();
			});

			modelBuilder.Entity<BankAccount>(b =>
			{
				b.HasKey(b => b.Id);

			//	b.HasOne().WithMany(u => u.BankAccoounts).IsRequired().HasForeignKey(l => l.UserId);
				b.HasIndex(b => b.UserId).IsClustered(false);

				b.Property(b => b.Amount).IsRequired();
				b.Property(b => b.IdentifierNumber).IsRequired();
				b.Property(b => b.DateCreated).IsRequired();
			});


			modelBuilder.HasDefaultSchema("Transaction");


			modelBuilder.Entity<Transaction>(t =>
			{

			});

			modelBuilder.Entity<CreditcardPayment>(c =>
			{

			});


			modelBuilder.Entity<ExpressPayment>(c =>
			{

			});

			modelBuilder.Entity<BeneficiaryPayment>(c =>
			{

			});


			modelBuilder.Entity<LoanPayment>(c =>
			{

			});

			modelBuilder.Entity<Transfer>(c =>
			{

			});
			modelBuilder.Entity<MoneyAdvance>(c =>
			{

			});
			modelBuilder.Entity<TransactionType>(c =>
			{

			});
			modelBuilder.Entity<TransactionDetail>(c =>
			{

			});

			base.OnModelCreating(modelBuilder);
		}
	}
}

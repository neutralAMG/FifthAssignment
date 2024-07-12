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

				l.HasMany(l => l.LoansPayments).WithOne(l => l.UserLoan).HasForeignKey(l => l.UserLoanId);
				l.HasIndex(l => l.UserId).IsClustered(false);

				l.Property(l => l.IdentifierNumber).IsRequired();
				l.Property(l => l.Amount).IsRequired();
				l.Property(l => l.DateCreated).IsRequired();
				
			});
			modelBuilder.Entity<CreditCard>(c =>
			{
				c.HasKey(c => c.Id);

				//c.HasOne().WithMany(u => u.CreditCards).IsRequired().HasForeignKey(l => l.UserId);
				c.HasMany(c => c.CreditCardPayments).WithOne(c => c.UserCreditCard).HasForeignKey(c => c.UserCreditCardId);
				c.HasMany(c => c.MoneyAdvances).WithOne(c => c.UserCreditCard).HasForeignKey(c => c.UserCreditCardId);

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
			
				b.HasMany(b => b.CreditCardPayments).WithOne(b => b.UserBankAccount).HasForeignKey(b => b.UserBankAccountId);

				b.HasMany(b => b.ExpressPaymentsFrom).WithOne(b => b.BankAccountFrom).HasForeignKey(b => b.BankAccountFromId);
				b.HasMany(b => b.ExpressPaymentsTo).WithOne(b => b.BankAccountTo).HasForeignKey(b => b.BankAccountToId);
				b.HasMany(b => b.LoansPayments).WithOne(b => b.UserBankAccount).HasForeignKey(b => b.UserBankAccountId);
				b.HasMany(b => b.MoneyAdvances).WithOne(b => b.UserBankAccount).HasForeignKey(b => b.UserBankAccountId);
				b.HasMany(b => b.TransfersFrom).WithOne(b => b.UserAccountFrom).HasForeignKey(b => b.UserAccountFromId);
				b.HasMany(b => b.TransfersTo).WithOne(b => b.UserAccountTo).HasForeignKey(b => b.UserAccountToId);

				b.HasMany(b => b.UserPayments).WithOne(b => b.UserBankAccount).HasForeignKey(b => b.UserBankAccountId).OnDelete(DeleteBehavior.ClientCascade);
				b.HasMany(b => b.BeneficiaryPayments).WithOne(b => b.BeneficiaryAccount).HasForeignKey(b => b.BeneficiaryBankAccountId).OnDelete(DeleteBehavior.ClientCascade);
	
				b.HasIndex(b => b.UserId).IsClustered(false);

				b.Property(b => b.Amount).IsRequired();
				b.Property(b => b.IdentifierNumber).IsRequired();
				b.Property(b => b.DateCreated).IsRequired();
			});


			modelBuilder.HasDefaultSchema("Transaction");


			modelBuilder.Entity<Transaction>(t =>
			{
				t.HasKey(c => c.Id);
				t.HasOne(t => t.TransactionDetail).WithOne( u => u.Transaction).HasForeignKey<TransactionDetail>(t => t.TransactionIdId);
				t.HasOne(t => t.TransactionType).WithMany( u => u.Transactions).HasForeignKey(t => t.TransactionTypeId);

				t.HasIndex(b => b.TransactionDetailId).IsClustered(false);
				t.HasIndex(b => b.TransactionTypeId).IsClustered(false);

				t.Property(b => b.Amount).IsRequired();
				t.Property(b => b.DateCreated).IsRequired();

			});

			modelBuilder.Entity<CreditcardPayment>(c =>
			{
				c.HasKey(c => c.Id);

				c.HasOne(t => t.UserCreditCard).WithMany(u => u.CreditCardPayments).HasForeignKey(c => c.UserCreditCardId).OnDelete(DeleteBehavior.NoAction); ;
				c.HasOne(t => t.UserBankAccount).WithMany(u => u.CreditCardPayments).HasForeignKey(t => t.UserBankAccountId).OnDelete(DeleteBehavior.NoAction); ;

				c.HasIndex(b => b.UserCreditCardId).IsClustered(false);
				c.HasIndex(b => b.UserBankAccountId).IsClustered(false);

				c.Property(b => b.Amount).IsRequired();
				c.Property(b => b.DateCreated).IsRequired();
			});


			modelBuilder.Entity<ExpressPayment>(e =>
			{
				e.HasKey(c => c.Id);

				e.HasOne(t => t.BankAccountFrom).WithMany(u => u.ExpressPaymentsFrom).HasForeignKey(c => c.BankAccountFromId).OnDelete(DeleteBehavior.NoAction); ;
				e.HasOne(t => t.BankAccountTo).WithMany(u => u.ExpressPaymentsTo).HasForeignKey(t => t.BankAccountToId).OnDelete(DeleteBehavior.NoAction); ;

				e.HasIndex(b => b.BankAccountFromId).IsClustered(false);
				e.HasIndex(b => b.BankAccountToId).IsClustered(false);

				e.Property(b => b.Amount).IsRequired();
				e.Property(b => b.DateCreated).IsRequired();
			});

			modelBuilder.Entity<BeneficiaryPayment>(c =>
			{
				c.HasKey(c => c.Id);

				c.HasOne(t => t.UserBankAccount).WithMany(u => u.UserPayments).HasForeignKey(c => c.UserBankAccountId).OnDelete(DeleteBehavior.NoAction);
				c.HasOne(t => t.BeneficiaryAccount).WithMany(u => u.BeneficiaryPayments).HasForeignKey(t => t.BeneficiaryBankAccountId).OnDelete(DeleteBehavior.NoAction); 

				c.HasIndex(b => b.UserBankAccountId).IsClustered(false);
				c.HasIndex(b => b.BeneficiaryBankAccountId).IsClustered(false);

				c.Property(b => b.Amount).IsRequired();
				c.Property(b => b.DateCreated).IsRequired();

			});


			modelBuilder.Entity<LoanPayment>(l =>
			{
				l.HasKey(c => c.Id);
				l.HasOne(t => t.UserBankAccount).WithMany(u => u.LoansPayments).HasForeignKey(c => c.UserBankAccountId).OnDelete(DeleteBehavior.NoAction); ;
				l.HasOne(t => t.UserLoan).WithMany(u => u.LoansPayments).HasForeignKey(t => t.UserLoanId).OnDelete(DeleteBehavior.NoAction); ;

				l.HasIndex(b => b.UserBankAccountId).IsClustered(false);
				l.HasIndex(b => b.UserLoanId).IsClustered(false);

				l.Property(b => b.Amount).IsRequired();
				l.Property(b => b.DateCreated).IsRequired();
			});

			modelBuilder.Entity<Transfer>(t =>
			{
				t.HasKey(c => c.Id);

				t.HasOne(t => t.UserAccountFrom).WithMany(u => u.TransfersFrom).HasForeignKey(c => c.UserAccountFromId).OnDelete(DeleteBehavior.NoAction); ;
				t.HasOne(t => t.UserAccountTo).WithMany(u => u.TransfersTo).HasForeignKey(t => t.UserAccountToId).OnDelete(DeleteBehavior.NoAction); ;

				t.HasIndex(b => b.UserAccountFromId).IsClustered(false);
				t.HasIndex(b => b.UserAccountToId).IsClustered(false);

				t.Property(b => b.Amount).IsRequired();
				t.Property(b => b.DateCreated).IsRequired();
			});
			modelBuilder.Entity<MoneyAdvance>(m =>
			{
				m.HasKey(c => c.Id);

				m.HasOne(t => t.UserCreditCard).WithMany(u => u.MoneyAdvances).HasForeignKey(c => c.UserCreditCardId).OnDelete(DeleteBehavior.NoAction); ;
				m.HasOne(t => t.UserBankAccount).WithMany(u => u.MoneyAdvances).HasForeignKey(t => t.UserBankAccountId).OnDelete(DeleteBehavior.NoAction); ;

				m.HasIndex(b => b.UserCreditCardId).IsClustered(false);
				m.HasIndex(b => b.UserBankAccountId).IsClustered(false);
				m.Property(b => b.Amount).IsRequired();
				m.Property(b => b.DateCreated).IsRequired();
			});
			modelBuilder.Entity<TransactionType>(t =>
			{
				t.HasKey(c => c.Id);
				t.HasMany(t => t.Transactions).WithOne(t => t.TransactionType).HasForeignKey(t => t.TransactionTypeId);
				t.HasMany(t => t.TransactionDetails).WithOne(t => t.TransactionType).HasForeignKey(t => t.TransactionTypeId);

				t.HasData(new TransactionType[] {
					 new() { Id = 1, Name = "Express Payment"},
					 new() { Id = 2, Name = "Beneficiary Payment"},
					 new() { Id = 3, Name = "CreditCard Payment"},
					 new() { Id = 4, Name = "Loan Payment"},
					 new() { Id = 5, Name = "Transfer"},
					 new() { Id = 6, Name = "Money Advance"},
				});

				t.Property(t => t.Name).IsRequired();
			});
			modelBuilder.Entity<TransactionDetail>(t =>
			{
				t.HasKey(c => c.Id);
				t.HasOne(t => t.Transaction).WithOne(t => t.TransactionDetail).HasForeignKey<Transaction>(t => t.TransactionDetailId);
				t.HasOne(t => t.TransactionType).WithMany(t => t.TransactionDetails).HasForeignKey(t => t.TransactionTypeId);
				
				t.HasIndex( t => t.TransactionTypeId).IsClustered(false);
				t.HasIndex( t => t.SpecificTransactionDetailId).IsClustered(false);

			});

			base.OnModelCreating(modelBuilder);
		}
	}
}

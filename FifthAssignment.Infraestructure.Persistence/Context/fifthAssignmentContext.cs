using FifthAssignment.Core.Domain.Entities.PersistanceContext;
using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace FifthAssignment.Infraestructure.Persistence.Context
{
    public class fifthAssignmentContext : DbContext
	{

		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Loan> Loans { get; set; }
		public DbSet<CreditCard> CreditCards { get; set; }
		public DbSet<Beneficiary> Beneficiaries { get; set; }
        public fifthAssignmentContext(DbContextOptions<fifthAssignmentContext> options) : base(options) 
        {
           
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=fifthAssingnment; Integrated Security=true; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(fifthAssignmentContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Beneficiary>(b =>
			{
				b.HasKey(b => b.Id);
				b.HasOne<ApplicationUser>().WithMany( u => u.Beneficiaries).HasForeignKey(b => b.UserBeneficiaryId);

				
				b.HasIndex(b => b.UserId).IsClustered(false);
				b.HasIndex(b => b.UserBeneficiaryId).IsClustered(false);
			});

			modelBuilder.Entity<Loan>(l =>
			{
				l.HasKey(l => l.Id);

				l.HasOne<ApplicationUser>().WithMany(u => u.Loans).IsRequired().HasForeignKey( l => l.UserId);
				l.HasIndex(l => l.UserId).IsClustered(false);

				l.Property(l => l.IdentifierNumber).IsRequired();
				l.Property(l => l.Amount).IsRequired();
				l.Property(l => l.DateCreated).IsRequired();
				
			});
			modelBuilder.Entity<CreditCard>(c =>
			{
				c.HasKey(c => c.Id);

				c.HasOne<ApplicationUser>().WithMany(u => u.CreditCards).IsRequired().HasForeignKey(l => l.UserId);
				c.HasIndex(c => c.UserId).IsClustered(false);

				c.Property(c => c.Amount).IsRequired();
				c.Property(c => c.IdentifierNumber).IsRequired();
				c.Property(c => c.CVV).IsRequired();
				c.Property(c => c.CreditLimit).IsRequired();
			});

			modelBuilder.Entity<BankAccount>(b =>
			{
				b.HasKey(b => b.Id);

				b.HasOne<ApplicationUser>().WithMany(u => u.BankAccoounts).IsRequired().HasForeignKey(l => l.UserId);
				b.HasIndex(b => b.UserId).IsClustered(false);

				b.Property(b => b.Amount).IsRequired();
				b.Property(b => b.IdentifierNumber).IsRequired();
				b.Property(b => b.DateCreated).IsRequired();
			});
		
		}
	}
}

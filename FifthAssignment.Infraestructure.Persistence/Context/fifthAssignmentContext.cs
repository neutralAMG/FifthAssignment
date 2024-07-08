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
			optionsBuilder.UseSqlServer("", m => m.MigrationsAssembly(typeof(fifthAssignmentContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Beneficiary>(b =>
			{
				b.HasOne<ApplicationUser>().WithMany( u => u.Beneficiaries).HasForeignKey(b => b.UserBeneficiaryId);
			});

			modelBuilder.Entity<Loan>(l =>
			{
				l.HasOne<ApplicationUser>().WithMany(u => u.Loans).HasForeignKey( l => l.UserId);
			});
		}
	}
}

using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FifthAssignment.Infraestructure.Identity.Context
{
	public class IdentityAppContext : IdentityDbContext<ApplicationUser>
	{
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("", m => m.MigrationsAssembly(typeof(IdentityAppContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.HasDefaultSchema("Identity");

			builder.Entity<ApplicationUser>(user =>
			{
				user.ToTable(name: "Users");

				user.HasMany(u =>u.Beneficiaries).WithOne().HasForeignKey(b => b.UserBeneficiaryId);
				user.HasMany(u =>u.Loans).WithOne().HasForeignKey(b => b.UserId);
				user.HasMany(u =>u.CreditCards).WithOne().HasForeignKey(b => b.UserId);
				user.HasMany(u =>u.BankAccoounts).WithOne().HasForeignKey(b => b.UserId);
			});


			builder.Entity<IdentityUserRole<string>>(role =>
			{
				role.ToTable(name: "Roles");
			});

			builder.Entity<IdentityUserLogin<string>>(login =>
			{
				login.ToTable(name: "UserLogins");
			});
		}
	}
}

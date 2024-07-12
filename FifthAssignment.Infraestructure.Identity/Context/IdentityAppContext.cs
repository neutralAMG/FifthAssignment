using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FifthAssignment.Infraestructure.Identity.Context
{
	public class IdentityAppContext : IdentityDbContext<ApplicationUser>
	{
        public IdentityAppContext()
        {
            
        }
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=fifthAssingnment; Integrated Security=true; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(IdentityAppContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Identity");

			builder.Entity<ApplicationUser>(user =>
			{
				user.ToTable(name: "Users");
			});

			builder.Entity<IdentityRole>(role =>
			{
				role.ToTable(name: "Rolls");
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

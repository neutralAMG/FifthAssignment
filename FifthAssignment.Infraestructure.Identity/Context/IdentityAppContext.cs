using FifthAssignment.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

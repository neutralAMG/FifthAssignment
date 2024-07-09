﻿

using FifthAssignment.Core.Application.Interfaces.Contracts;
using FifthAssignment.Core.Application.Interfaces.Identity;
using FifthAssignment.Core.Domain.Settings;
using FifthAssignment.Infraestructure.Identity.Context;
using FifthAssignment.Infraestructure.Identity.Entities;
using FifthAssignment.Infraestructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAssignment.Infraestructure.Identity
{
    public static class ServiceRegistration
	{
		public static void AddInfraestructureIdentityLayer(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<IdentityAppContext>(options =>
			{
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(IdentityAppContext).Assembly.FullName));
			});

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityAppContext>().AddDefaultTokenProviders();

			services.AddAuthentication();

			services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));

			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IUserRepository, UserRepository>();
		

		}
	}
}

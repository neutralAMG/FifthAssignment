
using FifthAssignment.Infraestructure.Identity;
using FifthAssignment.Infraestructure.Identity.Entities;
using FifthAssignment.Infraestructure.Identity.Seeds;
using FifthAssignment.Infraestructure.Persistence;
using FifthAssignment.Core.Application;
using FifthAssignment.Presentation.WebApp;
using Microsoft.AspNetCore.Identity;
using FifthAssignment.Core.Application.Interfaces.Contracts.Core;
using Microsoft.AspNetCore.Builder;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddInfraestructurePercistanceLayer(builder.Configuration);
builder.Services.AddInfraestructureIdentityLayer(builder.Configuration);
builder.Services.AddCoreAplicationLayer(builder.Configuration);
builder.Services.AddPresentationLayer();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("CustomPolicy", policy =>
	{
		policy.RequireAuthenticatedUser(); // Requires an authenticated user

	});
});
builder.Services.AddSession();




var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
		var bankAccountService = services.GetRequiredService<IBankAccountService>();

		await DefaultsRoles.AddDefaultRolesAsync(userManager, roleManager);
		await DefaultAdminUser.AddAdminUser(userManager, roleManager);
		await DefaultClientUser.AddDefaultClientUser(bankAccountService, userManager, roleManager);

	}
	catch
	{

	}
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=LogIn}/{id?}");




app.Run();

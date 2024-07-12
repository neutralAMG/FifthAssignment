
using FifthAssignment.Infraestructure.Identity;
using FifthAssignment.Infraestructure.Identity.Entities;
using FifthAssignment.Infraestructure.Identity.Seeds;
using FifthAssignment.Infraestructure.Persistence;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfraestructureIdentityLayer(builder.Configuration);
builder.Services.AddInfraestructurePercistanceLayer(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

		await DefaultsRoles.AddDefaultRolesAsync(userManager, roleManager);
		await DefaultAdminUser.AddAdminUser(userManager, roleManager);
		await DefaultClientUser.AddDefaultClientUser(userManager, roleManager);

	}
	catch
	{

	}
}

app.Run();

using Application;
using Domain.Authentication;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Context;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var configuration = builder.Configuration;

configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services
    .AddApplication()
    .AddInfrastructure(configuration)
    .AddPersistence(configuration);

builder.Services.AddProblemDetails();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/login");
    options.AccessDeniedPath = new PathString("/login");
});

var app = builder.Build();

app.UseExceptionHandler(app => { });

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    await SeedData.Initialize(services, userManager, roleManager);
}

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

app.Run();

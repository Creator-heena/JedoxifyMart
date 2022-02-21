using Duende.IdentityServer.Services;
using JedoxifyMart.Services.Identity;
using JedoxifyMart.Services.Identity.Data;
using JedoxifyMart.Services.Identity.Initialiser;
using JedoxifyMart.Services.Identity.Models;
using JedoxifyMart.Services.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JedoxifyMartIdentityServer")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var identityServerBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(StaticDetails.IdentityResources)
           .AddInMemoryApiScopes(StaticDetails.ApiScopes)
           .AddInMemoryClients(StaticDetails.Clients)
           .AddAspNetIdentity<ApplicationUser>();
identityServerBuilder.AddDeveloperSigningCredential();
builder.Services.AddScoped<IDbInitialiser,DbInitialiser>();
builder.Services.AddScoped<IProfileService, ProfileService>();

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
app.UseIdentityServer();

app.UseAuthorization();
SeedDatabase();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<IDbInitialiser>();
        dbInitialiser.Initialise();
    }
}

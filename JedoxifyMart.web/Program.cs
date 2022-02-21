using JedoxifyMart.web;
using JedoxifyMart.web.Services;
using JedoxifyMart.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<IShoppingCartService, ShoppingCartService>();
StaticDetails.ProductsAPIBase = builder.Configuration["ServiceUrls:ProductsAPI"];
StaticDetails.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
     {
         options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
         options.GetClaimsFromUserInfoEndpoint = true;
         options.ClientId = "jedoxifymart";
         options.ClientSecret = "secret";
         options.ResponseType = "code";
         options.ClaimActions.MapJsonKey("role", "role", "role");
         options.ClaimActions.MapJsonKey("sub", "sub", "sub");
         options.TokenValidationParameters.NameClaimType = "name";
         options.TokenValidationParameters.RoleClaimType = "role";
         options.Scope.Add("jedoxifymart");
         options.SaveTokens = true;

     });
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();

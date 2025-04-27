using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using WebApplication7.Data;
using WebApplication7.Helper;
using WebApplication7.Models;
using WebApplication7.Repository;
using WebApplication7.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<BookStoreContext>(
    options => options.UseSqlServer("Server=DEEPAK-THAKUR\\MSSQLSERVER01;Database=BookStore;" +
    "User Id=sa;Password=sa;Integrated Security=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false; 
    options.Password.RequireNonAlphanumeric= false;
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedEmail = true;
});
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/login";
});
// Add the NotificationCountFilter globally
var app = builder.Build();
app.Services.GetRequiredService<IWebHostEnvironment>();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.MapControllers();
app.Run();
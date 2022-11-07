using Eazii_Foods.Database;
using Eazii_Foods.Helper;
using Eazii_Foods.IHelper;
using Eazii_Foods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
  builder.Configuration.GetConnectionString("EazB")
  ));
   builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
   {

            Options.Password.RequireDigit = false;
            Options.Password.RequireLowercase = false;
            Options.Password.RequiredUniqueChars = 0;
            Options.Password.RequireNonAlphanumeric = false;
            Options.Password.RequireUppercase = false;
            Options.Password.RequiredLength = 3;

   }).AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
//builder.Services.AddTransient<IEmailServices, EmailServices>();
//builder.Services.AddSingleton<IGeneralConfiguration>(builder.Configuration.GetSection("GeneralConfiguration").Get<GeneralConfiguration>());

builder.Services.AddScoped<IUserHelper, UserHelper>();
//builder.Services.AddScoped<IAccountHelper, AccountHelper>();
//builder.Services.AddScoped<IEmailHelper, EmailHelper>();
//builder.Services.AddScoped<IAdminHelper, AdminHelper>();



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

app.Run();

using Microsoft.Extensions.Configuration;
using Law_Connect.Common.Repositories;
using Law_Connect.IAM.Infrastructure.Persistence;
using Law_Connect.Cases.Infrastructure.Persistence;
using Law_Connect.Notifications.Infrastructure.Persistence;
using Law_Connect.Payments.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("Startup/appsettings.json", optional: false, reloadOnChange: true);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (string.IsNullOrEmpty(environment))
{
    builder.Environment.EnvironmentName = "Development";
}

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Law_Connect.IAM.Infrastructure.Persistence.AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<Law_Connect.Cases.Infrastructure.Persistence.AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<Law_Connect.Notifications.Infrastructure.Persistence.AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<Law_Connect.Payments.Infrastructure.Persistence.AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secret = builder.Configuration["JwtSettings:Secret"];
        var issuer = builder.Configuration["JwtSettings:Issuer"];
        var audience = builder.Configuration["JwtSettings:Audience"];

        if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
        {
            throw new ArgumentNullException("JWT settings are not properly configured.");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
        };
    });

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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

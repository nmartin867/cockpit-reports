using Microsoft.EntityFrameworkCore;
using ServerReports.Api.Extensions;
using ServerReports.Api.Routes;
using ServerReports.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("ServerReports.Infrastructure")
        )
    );

builder.Services.RegisterServices();

var app = builder.Build();
app.MapExportsApi();


app.Run();

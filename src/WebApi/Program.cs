using DataAccessLayer;
using DataAccessLayer.ORM;
using DataContracts.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// todo fing out how to get connection string from apssettings.json
builder.Services.AddDbContext<PricesDataBaseContext>(o => o.UseSqlServer(""));

builder.Services.AddTransient<DbInitializer>();
// builder.Services.AddTransient<IPriceRepository, RawSqlPriceRepository>();
builder.Services.AddTransient<IPriceRepository, RawSqlPriceRepository>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Services.GetService<DbInitializer>().Init();
app.Services.GetService<IPriceRepository>().GetPricesData("Podolsk");

app.Run();

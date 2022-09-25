using DataAccessLayer;
using DataContracts.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

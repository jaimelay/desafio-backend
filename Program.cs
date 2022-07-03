global using desafio;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
  var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
  context.Database.EnsureCreated();
}

app.Run();

void ConfigureServices(IServiceCollection services)
{
  services.AddScoped<IMoneyChangeTransactionRepository, MoneyChangeTransactionRepository>();
  services.AddTransient<IMoneyChangeTransactionService, MoneyChangeTransactionService>();
}
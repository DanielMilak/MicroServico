using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MovtoFinanceiro.Infra;
using Tizza;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IServPizza, ServPizza>();
builder.Services.AddScoped<IPizzariaHelper, PizzariaHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();
RabbitMqManager.Iniciar();

app.Run();

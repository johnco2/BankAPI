using BankAPI;
using BankAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//INYECCION DE DEPENDENCIA DEL REPOSITORIO SU INTERFAZ
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("BankAppCon")));


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

app.Run();

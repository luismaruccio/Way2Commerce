using Microsoft.EntityFrameworkCore;
using Way2Commerce.Data.Models;
using Way2Commerce.Domain.Repositories;
using Way2Commerce.Domain.Repositories.Interfaces;
using Way2Commerce.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Way2Commerce.Data.Contexts.DatabaseContext>((DbContextOptionsBuilder options) =>
        options.UseSqlServer(Environment.GetEnvironmentVariable("cs"), b => b.MigrationsAssembly("Way2Commerce.API")));

builder.Services.AddScoped<IRepository<Product>,ProductRepository>();
builder.Services.AddScoped<ProductService>();


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

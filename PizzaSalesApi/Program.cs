using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Data;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaPlaceConnStr")));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IPizzasService, PizzaService>();
builder.Services.AddScoped<IPizzaTypesService, PizzaTypesService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();

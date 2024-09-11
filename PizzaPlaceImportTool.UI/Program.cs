using PizzaPlace.Core.ServiceContracts;
using PizzaPlace.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("pizzaPlaceApi", c => c.BaseAddress = new System.Uri("http://localhost:5098//api"));
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
//builder.Services.AddScoped<IPizzasService, PizzaService>();
//builder.Services.AddScoped<IPizzaTypesService, PizzaTypesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

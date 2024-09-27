using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
    )
);

builder.Services.AddScoped<InterfaceCategoriaService, CategoriaService>();
builder.Services.AddScoped<InterfaceClienteService, ClienteService>();
builder.Services.AddScoped<InterfaceProveedorService, ProveedorService>();
builder.Services.AddScoped<InterfaceProductoService, ProductoService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categoria}/{action=Index}/{id?}");

app.Run();

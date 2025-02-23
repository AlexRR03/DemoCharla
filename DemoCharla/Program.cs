using Microsoft.EntityFrameworkCore;
using DemoCharla.Data;
using DemoCharla.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<RepositoryProducto>();
var cnString = builder.Configuration.GetConnectionString("CnSql");
builder.Services.AddDbContext<ProductoContext>(options=> options.UseSqlServer(cnString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

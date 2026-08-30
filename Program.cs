using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar SQLite de manera limpia
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=tecnogas.db"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Inicializador automático de la base de datos para Render
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error de inicialización de BD: {ex.Message}");
    }
}

if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

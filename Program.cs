using Microsoft.EntityFrameworkCore;
using servicios.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext"));
});


var app = builder.Build();


app.MapGet("/servicios/productos", async (DataContext context) =>
{
    var productos = await context.Productos.ToListAsync();
    return Results.Ok(productos);
});

app.MapGet("/servicios/productos/{id}", async (DataContext context, long id) =>
{
    var producto = await context.Productos.FindAsync(id);
    if (producto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(producto);
});

app.MapPost("/servicios/productos", async (DataContext context, Producto producto) =>
{
    await context.Productos.AddAsync(producto);
    await context.SaveChangesAsync();
    return Results.Created($"/servicios/productos/{producto.Id}", producto);
});

app.MapGet("/", () => "Hello World!");


app.Run();

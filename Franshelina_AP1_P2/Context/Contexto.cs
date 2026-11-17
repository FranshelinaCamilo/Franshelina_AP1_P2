using Microsoft.EntityFrameworkCore;
using Franshelina_AP1_P2.Models;

namespace Franshelina_AP1_P2.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Ventas> Ventas { get; set; } = null!;
    public DbSet<VentasDetalle> VentasDetalles { get; set; } = null!;
    public DbSet<Productos> Productos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Productos>().HasData(

            new Productos
            {

                ProductoId = 1,

                Descripcion = "Mocca",

                Precio = 150.0,

                Stock = 10
            }, 
            new Productos
            {

                ProductoId = 2,

                Descripcion = "Cappuccino",

                Precio = 120.0,

                Stock = 10
            },
            new Productos
            {

                ProductoId = 3,

                Descripcion = "Latte",

                Precio = 130.0,

                Stock = 10
            },
            new Productos
            {

                ProductoId = 4,

                Descripcion = "Espresso",

                Precio = 200.0,

                Stock = 10
            },
            new Productos
            {

                ProductoId = 5,

                Descripcion = "Machiatto",

                Precio = 220.0,

                Stock = 10
            }
        );
    }
}
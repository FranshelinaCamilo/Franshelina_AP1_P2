using Microsoft.EntityFrameworkCore;
using Franshelina_AP1_P2.Models;

namespace Franshelina_AP1_P2.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Model1> Model1s { get; set; } = null!;
}
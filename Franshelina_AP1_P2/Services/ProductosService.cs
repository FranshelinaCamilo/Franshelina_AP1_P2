using Aplicada1.Core;
using Franshelina_AP1_P2.Context;
using Franshelina_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Franshelina_AP1_P2.Services;

public class ProductosService(IDbContextFactory<Contexto> contextFactory) : IServiceResult<Productos, int>
{
    public Task<Result> Guardar(Productos entidad)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Productos?>> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<Productos>>> GetList(Expression<Func<Productos, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

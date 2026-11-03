using Aplicada1.Core;
using Franshelina_AP1_P2.Context;
using Franshelina_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Franshelina_AP1_P2.Services;

public class Model1Service(IDbContextFactory<Contexto> contextFactory) : IServiceResult<Model1, int>
{
    public Task<Result> Guardar(Model1 entidad)
    {
        throw new NotImplementedException();
    }
    public Task<Result<Model1?>> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Model1>>> GetList(Expression<Func<Model1, bool>> criterio)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Eliminar(int id)
    {
        throw new NotImplementedException();
    }
}

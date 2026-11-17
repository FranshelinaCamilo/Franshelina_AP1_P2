using Aplicada1.Core;
using Franshelina_AP1_P2.Context;
using Microsoft.EntityFrameworkCore;
using Franshelina_AP1_P2.Models;
using System.Linq.Expressions;

namespace Franshelina_AP1_P2.Services;

public class VentasService(IDbContextFactory<Contexto> contextFactory) : IServiceResult<Ventas, int>
{
    public async Task<Result> Guardar(Ventas venta)
    {
        if (!await Existe(venta.VentaId))
        {
            var inserto = await Insertar(venta);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(venta);
            return Result.Success(modifico);
        }
    }

    public async Task<bool> Existe(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AnyAsync(v => v.VentaId == ventaId);
    }

    private async Task<bool> Insertar(Ventas venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        foreach (var detalle in venta.VentasDetalle)
        {
            detalle.Producto = null;
        }
        contexto.Ventas.Add(venta);
        await AfectarProductos(venta.VentasDetalle.ToArray(), TipoOperacion.Resta);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Ventas venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var ventaAnterior = await contexto.Ventas
            .Include(v => v.VentasDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.VentaId == venta.VentaId);

        if (ventaAnterior != null)
        {
            await AfectarProductos(ventaAnterior.VentasDetalle.ToArray(), TipoOperacion.Suma);
        }

        await AfectarProductos(venta.VentasDetalle.ToArray(), TipoOperacion.Resta);

        await contexto.VentasDetalles
            .Where(d => d.VentaId == venta.VentaId)
            .ExecuteDeleteAsync();

        foreach (var detalle in venta.VentasDetalle)
        {
            detalle.Producto = null;
            detalle.DetalleId = 0;
        }

        contexto.Update(venta);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task AfectarProductos(VentasDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        foreach (var item in detalle)
        {
            var producto = await contexto.Productos.SingleAsync(p => p.ProductoId== item.ProductoId);
            if (tipoOperacion == TipoOperacion.Suma)
                producto.Stock += item.Cantidad;
            else
                producto.Stock -= item.Cantidad;
        }
        await contexto.SaveChangesAsync();
    }

    public async Task<Result<Ventas?>> Buscar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(v => v.VentasDetalle)
                .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(e => e.VentaId == ventaId);
    }

    public async Task<Result<List<Ventas>>> GetList(Expression<Func<Ventas, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(v => v.VentasDetalle)
            .ThenInclude(d => d.Producto)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Result> Eliminar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var venta = await contexto.Ventas
            .Include(v => v.VentasDetalle)
            .FirstOrDefaultAsync(e => e.VentaId == ventaId);

        if (venta == null)
            return Result.Failure(new Error("VentaNoEncontrada", "La venta no fue encontrada."));

        await AfectarProductos(venta.VentasDetalle.ToArray(), TipoOperacion.Suma);

        contexto.VentasDetalles.RemoveRange(venta.VentasDetalle);
        contexto.Ventas.Remove(venta);
        var cantidad = await contexto.SaveChangesAsync();
        return Result.Success(cantidad > 0);
    }

    public async Task<List<Ventas>> Listar(Expression<Func<Ventas, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(v => v.VentasDetalle)
            .ThenInclude(d => d.Producto)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

public enum TipoOperacion
{
    Suma = 1,
    Resta = 2
}

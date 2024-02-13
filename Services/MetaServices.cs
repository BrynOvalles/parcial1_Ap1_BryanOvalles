using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using parcial1_Ap1_BryanOvalles.DAL;
using parcial1_Ap1_BryanOvalles.Models;

namespace parcial1_Ap1_BryanOvalles.Services;

public class MetaServices
{
	private readonly Contexto _contexto;
	public MetaServices(Contexto contexto)
	{
		_contexto = contexto;
	}
	public async Task<bool> Existe(int id)
	{
		return await _contexto.Metas.AnyAsync(m => m.MetaId == id);
	}
	public async Task<bool> Crear(Metas meta)
	{
		if (!await Existe(meta.MetaId))
			return await Insertar(meta);
		else
			return await Modificar(meta);
	}
	public async Task<bool> Insertar(Metas meta)
	{
		_contexto.Metas.Add(meta);
		return await _contexto.SaveChangesAsync() > 0;
	}
	public async Task<bool> Modificar(Metas meta)
	{
		_contexto.Metas.Update(meta);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(meta).State = EntityState.Detached;
		return modificado;
	}
	public async Task<bool> Eliminar(Metas metas)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.Where(m => m.MetaId == metas.MetaId)
			.ExecuteDeleteAsync() > 0;
	}
	public async Task<Metas?> Buscar(int id)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.MetaId == id);
	}
	public async Task<Metas?> BuscarDescripcion(string descripcion)
	{
		return await _contexto.Metas
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.Descripcion == descripcion);
	}
	public List<Metas> ObtenerLista(Expression<Func<Metas, bool>> criterio)
	{
		return _contexto.Metas.AsNoTracking()
			.Where(criterio)
			.ToList();
	}
}
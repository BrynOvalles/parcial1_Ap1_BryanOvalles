using Microsoft.EntityFrameworkCore;
using parcial1_Ap1_BryanOvalles.Models;

namespace parcial1_Ap1_BryanOvalles.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options) { }
	public DbSet<Metas> Metas { get; set; }
}

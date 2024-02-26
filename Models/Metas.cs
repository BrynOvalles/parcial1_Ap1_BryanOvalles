using System.ComponentModel.DataAnnotations;
namespace parcial1_Ap1_BryanOvalles.Models;

public class Metas
{
	[Key]
	public int MetaId { get; set; }
	[Required(ErrorMessage = "Es requerido intruducir una fecha")]
	public DateTime Fecha { get; set; } = DateTime.Now;
	[Required(ErrorMessage = "Es requerido que tenga una descripción")]
	public string? Descripcion { get; set; }
	[Required(ErrorMessage = "Es requerido que ingreses un monto para tu meta")]
	[Range(minimum: 0.1, maximum: 10000000000000000000, ErrorMessage = "El monto debe ser mayor a 0 o es demasiado alto para el sistema")]
	public decimal Monto { get; set; }
}

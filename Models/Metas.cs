using System.ComponentModel.DataAnnotations;

namespace parcial1_Ap1_BryanOvalles.Models
{
	public class Metas
	{
		[Key]
		public int MetaId { get; set; }
		[Required(ErrorMessage = "Es requerido intruducir una fecha")]
		public DateOnly Fecha { get; set; } = new DateOnly();
		[Required(ErrorMessage = "Es requerido que tenga una descripción")]
		public string? Descripcion { get; set; }
		[Required(ErrorMessage ="Es requerido que ingreses un monto para tu meta")]
		public decimal Monto { get; set; }

	}
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[StringLength(40)]
		public string Nombre { get; set; }

		[Required]
		[StringLength(40)]
		public string Apellido { get; set; }

		[Required]
		[StringLength(240)]
		public string Email { get; set; }

		[Required]
		[StringLength(20)]
		public string Contrasena { get; set; }

	}
}

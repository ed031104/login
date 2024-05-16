using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
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

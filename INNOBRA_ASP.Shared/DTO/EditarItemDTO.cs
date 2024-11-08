using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
	public class EditarItemDTO
	{
        public int Id { get; set; }

        public DateTime Tiempo_estimado { get; set; }

		[Required(ErrorMessage = "El material estimado es obligatorio.")]
		public int Material_estimado { get; set; }

		// Clave Foranea

		public int Item_Tipos_Id { get; set; }

		public int Presupuesto_Id { get; set; }
	}
}

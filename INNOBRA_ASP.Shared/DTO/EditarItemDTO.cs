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

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        public int Tiempo_estimado { get; set; }

        [Required(ErrorMessage = "La unidad de tiempo es obligatoria.")]
        public string Unidad_Tiempo { get; set; }

        [Required(ErrorMessage = "El material estimado es obligatorio.")]
        public int Material_estimado { get; set; }
    }
}

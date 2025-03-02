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
        [Range(1, int.MaxValue, ErrorMessage = "El tiempo estimado debe ser mayor a 0")]
        public int Tiempo_estimado { get; set; }

        [Required(ErrorMessage = "La unidad de tiempo es obligatoria.")]
        public string Unidad_Tiempo { get; set; }

        [Required(ErrorMessage = "El material estimado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El material estimado debe ser mayor a 0")]
        public int Material_estimado { get; set; }

        [Required(ErrorMessage = "El item tipo es obligatorio.")]
        public int Item_Tipos_Id { get; set; }
    }
}

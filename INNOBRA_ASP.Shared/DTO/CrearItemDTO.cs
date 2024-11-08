using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearItemDTO
    {
        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        public int Tiempo_estimado { get; set; }

        [Required(ErrorMessage = "La unidad de tiempo es obligatoria.")]
        public string Unidad_Tiempo { get; set; }

        [Required(ErrorMessage = "El material estimado es obligatorio.")]
        public int Material_estimado { get; set; }

        // clave foranea

        public int Item_Tipos_Id{ get; set; }

        public int Presupuesto_Id { get; set; }
    }
}

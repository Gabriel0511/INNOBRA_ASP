using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearUnidadDTO
    {
        [Required(ErrorMessage = "El Codigo es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }
    }
}

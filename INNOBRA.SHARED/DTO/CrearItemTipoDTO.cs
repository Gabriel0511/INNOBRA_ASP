using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA.SHARED.DTO
{
    public class CrearItemTipoDTO
    {

        [Required(ErrorMessage = "El Código es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        public string Unidad_Id { get; set; }
    }
}

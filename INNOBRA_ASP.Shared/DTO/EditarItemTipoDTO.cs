using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class EditarItemTipoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Código es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La unidad es obligatoria")]
        public int Unidad_Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class EditarUnidadDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }
    }
}

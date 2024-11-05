using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class ItemTipo : EntityBase
    {

        [Required(ErrorMessage = "El Código es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        public int Unidad_Id { get; set; }

    }
}

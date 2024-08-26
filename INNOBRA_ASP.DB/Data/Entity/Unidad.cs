using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Unidad : EntityBase
    {
        [Required(ErrorMessage = "El Codigo es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }
    }
}

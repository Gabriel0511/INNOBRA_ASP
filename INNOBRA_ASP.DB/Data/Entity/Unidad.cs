using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Unidad : EntityBase // Asegúrate de que herede de EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
    }
}

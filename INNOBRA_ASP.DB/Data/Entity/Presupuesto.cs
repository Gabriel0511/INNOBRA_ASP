using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Presupuesto : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de inicio prevista es obligatoria.")]
        public DateTime FechaInicioPrevista { get; set; }

        [Required(ErrorMessage = "La fecha de fin prevista es obligatoria.")]
        public DateTime FechaFinPrevista { get; set; }

        public int Obra_Id { get; set; }

        public Obra Obra { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
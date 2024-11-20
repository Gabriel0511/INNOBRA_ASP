using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Obra : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFin { get; set; }

        public byte[]? Imagen { get; set; }  // Atributo para almacenar la imagen

        public ICollection<Presupuesto> Presupuestos { get; set; }
    }
}


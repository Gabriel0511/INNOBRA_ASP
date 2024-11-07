using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Avance : EntityBase
    {
        [Required(ErrorMessage = "La Fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El Material ejecutado es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string MaterialEjecutado { get; set; }

        [Required(ErrorMessage = "La fecha de finalizacion real es obligatoria.")]
        public DateTime FechaFinalizacionReal { get; set; }

        //CLAVES FORANEAS
        public int Item_Id { get; set; }

        public Item Item { get; set; }

        public int Recurso_Id { get; set; }

        public Recurso Recurso { get; set; }
    }
}
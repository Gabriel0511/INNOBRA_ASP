using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Recurso : EntityBase
    {
        public enum TipoRecurso
        {
            Humano,
            Maquinaria,
            Material
        }

        public TipoRecurso Tipo { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        [MaxLength(45, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string UnidadMedida { get; set; }

        //CLAVE FORANEA
        public int Unidad_Id { get; set; }

        public Unidad Unidad { get; set; }
    }
}

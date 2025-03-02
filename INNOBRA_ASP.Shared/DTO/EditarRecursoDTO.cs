using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class EditarRecursoDTO
    {
        public enum TipoRecursoDTOEditar
        {
            Humano,
            Maquinaria,
            Material
        }

        public TipoRecursoDTOEditar Tipo { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Nombre invalido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un numerica.")]
        public string Cantidad { get; set; }

        //CLAVE FORANEA

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una unidad valida")]
        public int Unidad_Id { get; set; }
    }
}

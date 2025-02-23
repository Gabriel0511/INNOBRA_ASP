using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearRecursoDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Nombre invalido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un numerica.")]
        public string Cantidad { get; set; }

        //CLAVE FORANEA

        //[RegularExpression(@"^(?!-).*$", ErrorMessage = "Seleccione una opcion")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una unidad valida")]
        public int Unidad_Id { get; set; }

        public enum TipoRecursoDTO
        {
            Humano,
            Maquinaria,
            Material
        }

        [Required(ErrorMessage = "El tipo de recurso es obligatorio.")]
        [EnumDataType(typeof(TipoRecursoDTO), ErrorMessage = "Seleccione un tipo válido.")]
        public TipoRecursoDTO? Tipo { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearObraDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFin { get; set; }

        public byte[] Imagen { get; set; }  // Propiedad para la imagen
    }
}

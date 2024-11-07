using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearPresupuestoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de inicio prevista es obligatoria.")]
        public DateTime FechaInicioPrevista { get; set; }

        [Required(ErrorMessage = "La fecha de fin prevista es obligatoria.")]
        public DateTime FechaFinPrevista { get; set; }

        public int Obra_Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

public class EditarPresupuestoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La fecha de inicio prevista es obligatoria.")]
    public DateTime FechaInicioPrevista { get; set; }

    [Required(ErrorMessage = "La fecha de fin prevista es obligatoria.")]
    public DateTime FechaFinPrevista { get; set; }
}


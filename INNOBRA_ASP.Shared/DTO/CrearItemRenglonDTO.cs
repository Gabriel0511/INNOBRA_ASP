using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearItemRenglonDTO
    {
        [Required(ErrorMessage = "El material previsto es obligatorio.")]
        public string MaterialPrevisto { get; set; }

        [Required(ErrorMessage = "la cantidad es obligatoria.")]
        public string Cantidad { get; set; }

        //Clave Foranea

        public int Item_Id { get; set; }

        public int Recursos_Id { get; set; }
    }
}

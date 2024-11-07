using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace INNOBRA_ASP.DB.Data.Entity
{
    public class ItemRenglon : EntityBase
    {
        [Required(ErrorMessage = "El MaterialPrevisto es obligatorio.")]
        public string MaterialPrevisto { get; set; }

        [Required(ErrorMessage = "El MaterialPrevisto es obligatorio.")]
        public string Cantidad { get; set; }

        //Clave Foranea

        public int Items_idItems { get; set; }

        public Item Item { get; set; }

        public int Recursos_Id { get; set; }

        public Recurso Recurso { get; set; }

    }
}
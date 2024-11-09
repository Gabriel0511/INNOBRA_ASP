using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Item : EntityBase
    {

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        public int Tiempo_estimado { get; set; }


        [Required(ErrorMessage = "La unidad de tiempo es obligatoria.")]
        public string Unidad_Tiempo { get; set; }


        [Required(ErrorMessage = "El material estimado es obligatorio.")]
        public int Material_estimado { get; set; }

        // Clave Foranea

        public int Item_Tipos_Id { get; set; }

        public ItemTipo ItemTipo { get; set; }

        public int Presupuesto_Id { get; set; }

        public Presupuesto Presupuesto { get; set; }

        public ICollection<ItemRenglon> ItemRenglons { get; set; }
        public ICollection<Avance> Avances { get; set; }
    }
}
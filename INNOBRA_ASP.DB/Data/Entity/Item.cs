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

        [Required(ErrorMessage = "El Tiempo_estimado es obligatorio.")]
        public DateTime Tiempo_estimado { get; set; }

        [Required(ErrorMessage = "El Material_estimado es obligatorio.")]
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
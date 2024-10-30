using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearItemDTO
    {
        public DateTime Tiempo_estimado { get; set; }
        public int Material_estimado { get; set; }

        // clave foranea

        public int ItemTipos_idItemTipos { get; set; }

        public ItemTipo ItemTipo { get; set; }

        public int Presupuesto_id { get; set; }

        public Presupuesto Presupuesto { get; set; }
    }
}

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
        public string MaterialPrevisto { get; set; }

        public string Cantidad { get; set; }

        //Clave Foranea

        public int Items_idItems { get; set; }

        public Item Item { get; set; }

        public int Recursos_idRecursos { get; set; }

        public Recurso Recurso { get; set; }
    }
}

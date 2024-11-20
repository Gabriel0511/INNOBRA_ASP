using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class EditarAvanceDTO
    {
        public int Id { get; set; }

        //PRUEBA PARA PABLO
        public DateTime Fecha { get; set; }

        public string MaterialEjecutado { get; set; }

        public DateTime FechaFinalizacionReal { get; set; }

        //CLAVES FORANEAS
        public int Item_Id { get; set; }

        //public Item Item { get; set; }

        public int Recurso_Id { get; set; }

        //public Recurso Recurso { get; set; }
    }
}

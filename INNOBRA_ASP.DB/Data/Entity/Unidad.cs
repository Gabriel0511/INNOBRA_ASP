using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class Unidad : EntityBase // Asegúrate de que herede de EntityBase
    {

        public string Nombre { get; set; }

        public ICollection<Recurso> Recursos { get; set; }
        public ICollection<ItemTipo> ItemTipos { get; set; }
    }
}
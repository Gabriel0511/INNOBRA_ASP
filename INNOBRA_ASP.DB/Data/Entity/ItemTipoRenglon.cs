using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INNOBRA_ASP.DB.Data.Entity
{
    public class ItemTipoRenglon : EntityBase
    {
        public int Item_Tipos_Id { get; set; }

        public ItemTipo ItemTipo { get; set; }

        public int Recurso_Id { get; set; }

        public Recurso Recurso { get; set; }

    }
}
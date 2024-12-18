﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace INNOBRA_ASP.DB.Data.Entity
{
    public class ItemRenglon : EntityBase
    {
        [Required(ErrorMessage = "El material previsto es obligatorio.")]
        public string MaterialPrevisto { get; set; }

        [Required(ErrorMessage = "la cantidad es obligatoria.")]
        public string Cantidad { get; set; }

        //Clave Foranea

        public int Item_Id { get; set; }

        public Item Item { get; set; }

        public int Recursos_Id { get; set; }

        public Recurso Recurso { get; set; }

    }
}
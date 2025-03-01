﻿using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
	public class EditarItemRenglonDTO
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "El material previsto es obligatorio.")]
		public string MaterialPrevisto { get; set; }

		[Required(ErrorMessage = "La cantidad es obligatorio.")]
		public string Cantidad { get; set; }
	}
}

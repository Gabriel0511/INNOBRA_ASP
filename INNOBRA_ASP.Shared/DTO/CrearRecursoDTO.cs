using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class CrearRecursoDTO
    {
        public enum TipoRecursoDTO
        {
            Humano,
            Maquinaria,
            Material
        }

        public TipoRecursoDTO Tipo { get; set; }

        public string Nombre { get; set; }

        public string Cantidad { get; set; }

        //CLAVE FORANEA
        public int Unidad_Id { get; set; }

    }
}

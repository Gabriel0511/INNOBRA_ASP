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
        public enum TipoRecurso
        {
            Humano,
            Maquinaria,
            Material
        }

        public string Nombre { get; set; }

        public string Cantidad { get; set; }

        public string UnidadMedida { get; set; }

        //CLAVE FORANEA
        public int Unidad_Id { get; set; }

        public Unidad Unidad { get; set; }

        public TipoRecurso Tipo { get; set; }
    }
}

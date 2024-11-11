using INNOBRA_ASP.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNOBRA_ASP.Shared.DTO
{
    public class EditarRecursoDTO
    {
        public enum TipoRecursoDTOEditar
        {
            Humano,
            Maquinaria,
            Material
        }

        public TipoRecursoDTOEditar Tipo { get; set; }

        public string Nombre { get; set; }

        public string Cantidad { get; set; }

        //CLAVE FORANEA
        public int Unidad_Id { get; set; }
    }
}

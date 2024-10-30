using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class UnidadRepositorio : Repositorio<Unidad>, IUnidadRepositorio
    {
        private readonly Context context;
        public UnidadRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}

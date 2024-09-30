using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class ObraRepositorio : Repositorio<Obra>, IObraRepositorio
    {
        private readonly Context context;

        public ObraRepositorio(Context context) : base(context) 
        {
            this.context = context;
        }
    }
}

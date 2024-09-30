using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class RecursoRepositorio : Repositorio<Recurso>, IRecursoRepositorio
    {
        private readonly Context context;

        public RecursoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}

using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class AvanceRepositorio : Repositorio<Avance>, IAvanceRepositorio
    {
        private readonly Context context;

        public AvanceRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}

using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class PresupuestoRepositorio : Repositorio<Presupuesto>, IPresupuestoRepositorio
    {
        private readonly Context context;
        
        public PresupuestoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}

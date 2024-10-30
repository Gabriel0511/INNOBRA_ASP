using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class ItemTipoRepositorio : Repositorio<ItemTipo>, IItemTipoRepositorio
    {
        private readonly Context context;

        public ItemTipoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }   
    }
}

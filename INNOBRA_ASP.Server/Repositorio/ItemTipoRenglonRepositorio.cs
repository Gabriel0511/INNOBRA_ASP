using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Repositorio
  
{
    public class ItemTipoRenglonRepositorio : Repositorio<ItemTipoRenglon>, IItemTipoRenglonRepositorio
    {
        private readonly Context context;
        public ItemTipoRenglonRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
          
    }
}

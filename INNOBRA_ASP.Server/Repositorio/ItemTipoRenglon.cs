using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Repositorio
  
{
    public class ItemTipoRenglon : Repositorio<ItemTipoRenglon>, IItemTipoRenglonRepositorio
    {
        private readonly Context context;
        public ItemTipoRenglon(Context context) : base(context)
        {
            this.context = context;
        }
            
        
    }
}

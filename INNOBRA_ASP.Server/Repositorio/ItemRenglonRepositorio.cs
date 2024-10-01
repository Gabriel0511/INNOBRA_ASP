using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class ItemRenglonRepositorio : Repositorio<ItemRenglon>, IItemRenglonRepositorio
    {
        private readonly Context context;

        public ItemRenglonRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}

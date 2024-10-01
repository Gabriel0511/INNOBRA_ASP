using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{
    public class ItemRepositorio : Repositorio<Item>, IItemRepositorio
    {
        private readonly Context context;

        public ItemRepositorio (Context context) : base(context) 
        {
            this.context = context;
        }
    }
}

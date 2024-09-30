using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;


namespace INNOBRA_ASP.Server.Repositorio
{
    public class ItemTipoRepositorio : Repositorio<ItemTipo>,IItemTipoRepositorio
    {
        private readonly Context context;

        public ItemTipoRepositorio(Context context) : base(context)
        {
            this.context = context;

        }

    }
}

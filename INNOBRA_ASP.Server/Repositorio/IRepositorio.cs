using System.Collections.Generic;
using System.Threading.Tasks;
using INNOBRA_ASP.DB.Data;  

namespace INNOBRA_ASP.Server.Repositorio
{
    
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Delete(int id);
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E> SelectById(int id);
        Task<bool> Update(int id, E entidad);
    }
}

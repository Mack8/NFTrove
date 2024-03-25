using NFTrove.Infraestructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryPais
    {
        Task<int> AddAsync(Pais entity);
        Task DeleteAsync(int id);
        Task<ICollection<Pais>> ListAsync();
        Task<Pais> FindByIdAsync(int id);
        Task UpdateAsync(int id, Pais entity);
    }
}

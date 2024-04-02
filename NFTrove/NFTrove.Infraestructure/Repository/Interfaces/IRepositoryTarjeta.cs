using NFTrove.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryTarjeta
    {
        Task<int> AddAsync(Tarjeta entity);
        Task DeleteAsync(int id);
        Task<ICollection<Tarjeta>> ListAsync();
        Task<Tarjeta> FindByIdAsync(int id);
        Task UpdateAsync(int id, Tarjeta entity);
    }
}

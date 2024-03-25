using NFTrove.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCliente
    {

        Task<ICollection<Cliente>> FindByDescriptionAsync(string description);
        Task<ICollection<Cliente>> ListAsync();
        Task<Cliente> FindByIdAsync(string identificacion);
        Task<Guid> AddAsync(Cliente entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, Cliente entity);

    }
}

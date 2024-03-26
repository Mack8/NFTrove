using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Infraestructure.Repository.Interfaces;

public interface IRepositoryNft
{
    Task<ICollection<Nft>> FindByDescriptionAsync(string description);
    Task<ICollection<Nft>> ListAsync();
    Task<Nft> FindByIdAsync(int id);
    Task<Guid> AddAsync(Nft entity);
    Task DeleteAsync(int id);
    Task UpdateAsync();
}

using NFTrove.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Interfaces
{
    public interface IServicePais
    {
        Task<int> AddAsync(PaisDTO dto);
        Task DeleteAsync(int id);
        Task<ICollection<PaisDTO>> ListAsync();
        Task<PaisDTO> FindByIdAsync(int id);
        Task UpdateAsync(int id, PaisDTO dto);
    }
}

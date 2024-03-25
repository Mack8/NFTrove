using NFTrove.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Interfaces
{
    public interface IServiceTarjeta
    {
        Task<ICollection<TarjetaDTO>> FindByTypeAsync(string type);
        Task<ICollection<TarjetaDTO>> ListAsync();
        Task<TarjetaDTO> FindByIdAsync(int id);
        Task<int> AddAsync(TarjetaDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, TarjetaDTO dto);
    }
}

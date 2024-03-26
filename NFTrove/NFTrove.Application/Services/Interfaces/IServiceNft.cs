using NFTrove.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Interfaces;

public interface IServiceNft
{
    Task<ICollection<NftDTO>> FindByDescriptionAsync(string description);
    Task<ICollection<NftDTO>> ListAsync();
    Task<NftDTO> FindByIdAsync(int id);
    Task<Guid> AddAsync(NftDTO dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, NftDTO dto);

}

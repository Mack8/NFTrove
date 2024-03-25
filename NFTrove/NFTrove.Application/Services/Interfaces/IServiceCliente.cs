using NFTrove.Application.DTOs;
using NFTrove.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Interfaces;

public interface IServiceCliente
{


    Task<ICollection<ClienteDTO>> FindByDescriptionAsync(string description);
    Task<ICollection<ClienteDTO>> ListAsync();
    Task<ClienteDTO> FindByIdAsync(string identificacion);
    Task<Guid> AddAsync(ClienteDTO dto);
    Task DeleteAsync(string id);
    Task UpdateAsync(string id, ClienteDTO dto);
}


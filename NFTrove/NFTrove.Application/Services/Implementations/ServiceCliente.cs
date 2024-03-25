using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Implementations
{
    public class ServiceCliente : IServiceCliente
    {

        private readonly IRepositoryCliente _repository;
        private readonly IMapper _mapper;

        public ServiceCliente(IRepositoryCliente repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(ClienteDTO dto)
        {
            // Map BodegaDTO to Bodega
            var objectMapped = _mapper.Map<Cliente>(dto);

            // Return
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<ClienteDTO>> FindByDescriptionAsync(string description)
        {
            var list = await _repository.FindByDescriptionAsync(description);
            var collection = _mapper.Map<ICollection<ClienteDTO>>(list);
            return collection;

        }

        public async Task<ClienteDTO> FindByIdAsync(string id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ClienteDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<ClienteDTO>> ListAsync()
        {
            // Get data from Repository
            var list = await _repository.ListAsync();
            // Map List<Bodega> to ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<ClienteDTO>>(list);
            // Return Data
            return collection;
        }

        public async Task UpdateAsync(string id, ClienteDTO dto)
        {
            var objectMapped = _mapper.Map<Cliente>(dto);
            await _repository.UpdateAsync(id, objectMapped);
        }


    }
}

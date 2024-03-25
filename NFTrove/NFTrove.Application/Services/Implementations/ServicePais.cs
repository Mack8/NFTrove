using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Implementations
{
    public class ServicePais : IServicePais
    {
        private readonly IRepositoryPais _repository;
        private readonly IMapper _mapper;

        public ServicePais(IRepositoryPais repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PaisDTO dto)
        {
            var objectMapped = _mapper.Map<Pais>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<PaisDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<PaisDTO>>(list);
            return collection;
        }

        public async Task<PaisDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<PaisDTO>(@object);
            return objectMapped;
        }

        public async Task UpdateAsync(int id, PaisDTO dto)
        {
            var objectMapped = _mapper.Map<Pais>(dto);
            await _repository.UpdateAsync(id, objectMapped);
        }
    }
}

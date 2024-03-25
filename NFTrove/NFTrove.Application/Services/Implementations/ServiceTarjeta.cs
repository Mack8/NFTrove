using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTrove.Application.Services.Implementations
{
    public class ServiceTarjeta : IServiceTarjeta
    {
        private readonly IRepositoryTarjeta _repository;
        private readonly IMapper _mapper;

        public ServiceTarjeta(IRepositoryTarjeta repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(TarjetaDTO dto)
        {
            var objectMapped = _mapper.Map<Tarjeta>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<TarjetaDTO>> FindByTypeAsync(string type)
        {
            var list = await _repository.FindByTypeAsync(type);
            var collection = _mapper.Map<ICollection<TarjetaDTO>>(list);
            return collection;
        }

        public async Task<TarjetaDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<TarjetaDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<TarjetaDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<TarjetaDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, TarjetaDTO dto)
        {
            var objectMapped = _mapper.Map<Tarjeta>(dto);
            await _repository.UpdateAsync(id, objectMapped);
        }
    }
}

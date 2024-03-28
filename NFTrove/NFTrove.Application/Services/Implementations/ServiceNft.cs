using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;

namespace NFTrove.Application.Services.Implementations;

public class ServiceNft : IServiceNft
{

    private readonly IRepositoryNft _repository;
    private readonly IMapper _mapper;

    public ServiceNft(IRepositoryNft repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(NftDTO dto)
    {
        // Map BodegaDTO to Bodega
        var objectMapped = _mapper.Map<Nft>(dto);

        // Return
        return await _repository.AddAsync(objectMapped);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<ICollection<NftDTO>> FindByDescriptionAsync(string description)
    {
        var list = await _repository.FindByDescriptionAsync(description);

        var collection = _mapper.Map<ICollection<NftDTO>>(list);

        return collection;

    }

    public async Task<NftDTO> FindByIdAsync(Guid id)
    {
        var @object = await _repository.FindByIdAsync(id);
        var objectMapped = _mapper.Map<NftDTO>(@object);
        return objectMapped;
    }

    public async Task<ICollection<NftDTO>> ListAsync()
    {
        // Get data from Repository
        var list = await _repository.ListAsync();
        // Map List<Bodega> to ICollection<BodegaDTO>
        var collection = _mapper.Map<ICollection<NftDTO>>(list);
        // Return Data
        return collection;
    }

    public async Task UpdateAsync(Guid id, NftDTO dto)
    {
        var @object = await _repository.FindByIdAsync(id);
        //       source, destination
        _mapper.Map(dto, @object!);
        await _repository.UpdateAsync();
    }

}
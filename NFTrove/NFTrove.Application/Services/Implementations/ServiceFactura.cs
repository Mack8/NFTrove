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

public class ServiceFactura : IServiceFactura
{
    private readonly IRepositoryFactura _repositoryFacturaTotal;
    private readonly IMapper _mapper;

    public ServiceFactura(IRepositoryFactura repositoryFactura, IMapper mapper)
    {
        _repositoryFacturaTotal = repositoryFactura;
        _mapper = mapper;
    }


    public Task<int> AddAsync(EncabezadoFacturaDTO dto)
    {
        //Todo: Validate Stock availability
        //throw new BadHttpRequestException("No hay stock");

        var @object = _mapper.Map<EncabezadoFactura>(dto);
        return _repositoryFacturaTotal.AddAsync(@object);
    }

    public async Task<int> GetNextReceiptNumber()
    {
        int nextReceipt = await _repositoryFacturaTotal.GetNextReceiptNumber();
        return nextReceipt + 1;
    }
}

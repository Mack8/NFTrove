using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFTrove.Application.DTOs;


namespace NFTrove.Application.Services.Interfaces;

public interface IServiceFactura
{
    Task<int> AddAsync(EncabezadoFacturaDTO dto);
    Task<int> GetNextReceiptNumber();
}

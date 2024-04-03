using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFTrove.Infraestructure.Models;

namespace NFTrove.Infraestructure.Repository.Interfaces;

public interface IRepositoryFactura
{
    Task<int> AddAsync(EncabezadoFactura entity);
    Task<EncabezadoFactura> FindByIdAsync(int id);
    Task<int> GetNextReceiptNumber();
}

using NFTrove.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFactura
    {
        Task<int> AddAsync(Factura entity);
        Task<Factura> FindByIdAsync(int id);
        Task<int> GetNextReceiptNumber();

    }
}

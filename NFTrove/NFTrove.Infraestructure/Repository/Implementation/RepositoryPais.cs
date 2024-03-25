using Microsoft.EntityFrameworkCore;
using NFTrove.Infraestructure.Data;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Implementation
{
    public class RepositoryPais : IRepositoryPais
    {
        private readonly NFTroveContext _context;

        public RepositoryPais(NFTroveContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Pais entity)
        {
            await _context.Set<Pais>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var pais = await _context.Set<Pais>().FindAsync(id);
            if (pais != null)
            {
                _context.Set<Pais>().Remove(pais);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Pais>> ListAsync()
        {
            var collection = await _context.Set<Pais>().AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task<Pais> FindByIdAsync(int id)
        {
            var pais = await _context.Set<Pais>().FindAsync(id);
            return pais!;
        }

        public async Task UpdateAsync(int id, Pais entity)
        {
            var pais = await FindByIdAsync(id);
            if (pais != null)
            {
                pais.Iso = entity.Iso;
                pais.Descripcion = entity.Descripcion;
                await _context.SaveChangesAsync();
            }
        }
    }
}

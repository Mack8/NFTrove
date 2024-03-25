using Microsoft.EntityFrameworkCore;
using NFTrove.Infraestructure.Data;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Implementation
{
    public class RepositoryTarjeta : IRepositoryTarjeta
    {
        private readonly NFTroveContext _context;

        public RepositoryTarjeta(NFTroveContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Tarjeta entity)
        {
            await _context.Set<Tarjeta>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var tarjeta = await _context.Set<Tarjeta>().FindAsync(id);
            if (tarjeta != null)
            {
                _context.Set<Tarjeta>().Remove(tarjeta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Tarjeta>> FindByTypeAsync(string type)
        {
            var collection = await _context
                .Set<Tarjeta>()
                .Where(t => t.Tipo.Contains(type))
                .ToListAsync();
            return collection;
        }

        public async Task<Tarjeta> FindByIdAsync(int id)
        {
            var tarjeta = await _context.Set<Tarjeta>().FindAsync(id);
            return tarjeta!;
        }

        public async Task<ICollection<Tarjeta>> ListAsync()
        {
            var collection = await _context.Set<Tarjeta>().AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(int id, Tarjeta entity)
        {
            var tarjeta = await FindByIdAsync(id);
            if (tarjeta != null)
            {
                tarjeta.Tipo = entity.Tipo;
                await _context.SaveChangesAsync();
            }
        }
    }
}

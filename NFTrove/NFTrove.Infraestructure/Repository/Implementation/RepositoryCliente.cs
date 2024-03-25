using Microsoft.EntityFrameworkCore;
using NFTrove.Infraestructure.Data;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTrove.Infraestructure.Repository.Implementation
{
    public class RepositoryCliente : IRepositoryCliente
    {

        private readonly NFTroveContext _context;

        public RepositoryCliente(NFTroveContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Cliente entity)
        {
            await _context.Set<Cliente>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(string id)
        {
            // Raw Query
            //https://www.learnentityframeworkcore.com/raw-sql/execute-sql
            int rowAffected = _context.Database.ExecuteSql($"Delete Cliente Where Identificacion = {id}");
            await Task.FromResult(1);
        }

        public async Task<ICollection<Cliente>> FindByDescriptionAsync(string description)
        {
            var collection = await _context
                                         .Set<Cliente>()
                                         .Where(p => p.Nombre.Contains(description))
                                         .ToListAsync();
            return collection;
        }

        public async Task<Cliente> FindByIdAsync(string identificacion)
        {
            var cliente = await _context.Set<Cliente>()
                                         .FirstOrDefaultAsync(c => c.Identificacion == identificacion);
            return cliente!;
        }


        public async Task<ICollection<Cliente>> ListAsync()
        {
            var collection = await _context.Set<Cliente>().AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(string id, Cliente entity)
        {
            var @object = await FindByIdAsync(id);
            @object.Nombre = entity.Nombre;
            @object.CorreoElectronico = entity.CorreoElectronico;
            @object.Apellidos = entity.Apellidos;
            @object.PaisId = entity.PaisId;
            @object.Identificacion = entity.Identificacion;
            await _context.SaveChangesAsync();
        }

    }
}

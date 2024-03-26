using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFTrove.Infraestructure.Data;
using NFTrove.Infraestructure.Models;
using NFTrove.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NFTrove.Infraestructure.Repository.Implementation;

public class RepositoryNft : IRepositoryNft
{

    private readonly NFTroveContext _context;

    public RepositoryNft(NFTroveContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Nft entity)
    {
        await _context.Set<Nft>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        // Raw Query
        //https://www.learnentityframeworkcore.com/raw-sql/execute-sql
        int rowAffected = _context.Database.ExecuteSql($"Delete NFT Where ID = {id}");
        await Task.FromResult(1);
    }

    public async Task<ICollection<Nft>> FindByDescriptionAsync(string description)
    {
        var collection = await _context
                                     .Set<Nft>()
                                     .Where(p => p.Nombre.Contains(description))
                                     .ToListAsync();
        return collection;
    }

    public async Task<Nft> FindByIdAsync(int id)
    {
        var @object = await _context.Set<Nft>().FindAsync(id);
        return @object!;
    }

   public async Task<ICollection<Nft>> ListAsync()
    {
        var collection = await _context.Set<Nft>().AsNoTracking().ToListAsync();
        return collection;
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }


}

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

public class RepositoryFactura : IRepositoryFactura
{

    private readonly NFTroveContext _context;

    public RepositoryFactura(NFTroveContext context)
    {
        _context = context;

    }
    public async Task<int> AddAsync(EncabezadoFactura entity)
    {

        try
        {
            // Get No Receipt
            entity.FacturaId = GetNoReceipt();
            // Reenumerate
            entity.DetalleFactura.ToList().ForEach(p => p.FacturaId = entity.FacturaId);
            // Begin Transaction
            await _context.Database.BeginTransactionAsync();
            await _context.Set<EncabezadoFactura>().AddAsync(entity);

            // Withdraw from inventory
            foreach (var item in entity.DetalleFactura)
            {
                // find the product
                var nft = await _context.Set<Nft>().FindAsync(item.Nftid);
                // update stock
                nft!.CantidadInventario = nft.CantidadInventario - item.Cantidad;
                // update entity product
                _context.Set<Nft>().Update(nft);
            }

            await _context.SaveChangesAsync();
            // Commit
            await _context.Database.CommitTransactionAsync();

            return entity.FacturaId;
        }
        catch (Exception ex)
        {
            Exception exception = ex;
            // Rollback 
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }

    /// <summary>
    /// Get current NoReceipt without increment
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetNextReceiptNumber()
    {

        int current = 0;

        string sql = string.Format("SELECT current_value FROM sys.sequences WHERE name = 'NoFactura'");

        System.Data.DataTable dataTable = new System.Data.DataTable();

        System.Data.Common.DbConnection connection = _context.Database.GetDbConnection();
        System.Data.Common.DbProviderFactory dbFactory = System.Data.Common.DbProviderFactories.GetFactory(connection!)!;
        using (var cmd = dbFactory!.CreateCommand())
        {
            cmd!.Connection = connection;
            cmd.CommandText = sql;
            using (System.Data.Common.DbDataAdapter adapter = dbFactory.CreateDataAdapter()!)
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
        }


        current = Convert.ToInt32(dataTable.Rows[0][0].ToString());
        return await Task.FromResult(current);
        
    }




    /// <summary>
    /// Get sequence in order to assign Receipt number.   
    /// Automaticaly INCREMENT ++
    /// http://technet.microsoft.com/es-es/library/ff878091.aspx
    /// CREATE SEQUENCE  ReceiptNumber  START WITH 1 INCREMENT BY 1 ;
    /// </summary>
    /// <returns>Num. de factura</returns>
    private int GetNoReceipt()
    {
        int siguiente = 0;

        string sql = string.Format("SELECT NEXT VALUE FOR NoFactura");

        System.Data.DataTable dataTable = new System.Data.DataTable();

        System.Data.Common.DbConnection connection = _context.Database.GetDbConnection();
        System.Data.Common.DbProviderFactory dbFactory = System.Data.Common.DbProviderFactories.GetFactory(connection!)!;
        using (var cmd = dbFactory!.CreateCommand())
        {
            cmd!.Connection = connection;
            cmd.CommandText = sql;
            using (System.Data.Common.DbDataAdapter adapter = dbFactory.CreateDataAdapter()!)
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
        }


        siguiente = Convert.ToInt32(dataTable.Rows[0][0].ToString());
        return siguiente;

    }


    public async Task<EncabezadoFactura> FindByIdAsync(int id)
    {

        var response = await _context.Set<EncabezadoFactura>()
                    .Include(detalle => detalle.DetalleFactura)
                    .ThenInclude(detalle => detalle.IdProductoNavigation)
                    .Include(cliente => cliente.IdClienteNavigation)
                    .Where(p => p.FacturaId == id).FirstOrDefaultAsync();

        return response!;
    }

}

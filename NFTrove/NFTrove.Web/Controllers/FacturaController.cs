using Microsoft.AspNetCore.Mvc;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Application.DTOs;
using System.Text.Json;

namespace NFTrove.Web.Controllers;

public class FacturaController : Controller
{

    private readonly IServiceNft _serviceNft;
    private readonly IServiceTarjeta _serviceTarjeta;
    private readonly IServiceFactura _serviceFactura;
    private readonly IServiceCliente _serviceCliente;


    public FacturaController(IServiceNft servicoNft,
                            IServiceTarjeta servicoTarjeta,
                            IServiceFactura serviceFactura,
                            IServiceCliente serviceCliente)
    {
        _serviceNft = servicoNft;
        _serviceTarjeta = servicoTarjeta;
        _serviceFactura = serviceFactura;
        _serviceCliente = serviceCliente;
    }

    public async Task<IActionResult> Index()
    {

        var nextReceiptNumber = await _serviceFactura.GetNextReceiptNumber();
        ViewBag.CurrentReceipt = nextReceiptNumber;

        // Obtener la lista de tarjetas
        var collectionTarjeta = await _serviceTarjeta.ListAsync();
        ViewBag.ListTarjeta = collectionTarjeta;

        // Obtener la lista de clientes con nombre y apellido concatenados
        var collectionCliente = await _serviceCliente.ListAsync();
        ViewBag.ListCliente = collectionCliente.Select(c => new {
            ID = c.ID,
            NombreCompleto = $"{c.Nombre} {c.Apellidos}"
        }).ToList();

        // Limpiar CarShopping
        TempData["CartShopping"] = null;
        TempData.Keep();

        return View();
    }


    public async Task<IActionResult> AddProduct(Guid id, int cantidad)
    {
        DetalleFacturaDTO detalleFacturaDTO = new DetalleFacturaDTO();
        List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
        string json = "";
        var nft = await _serviceNft.FindByIdAsync(id);

        // Stock ??

        if (cantidad > nft.CantidadInventario)
        {
            return BadRequest("No hay inventario suficiente!");
        }

        
        detalleFacturaDTO.NftId = nft.ID ;
        detalleFacturaDTO.Cantidad = cantidad;
        detalleFacturaDTO.Precio = (decimal)nft.Valor;
        detalleFacturaDTO.TotalLinea= (detalleFacturaDTO.Precio * detalleFacturaDTO.Cantidad);
       
        if (TempData["CartShopping"] == null)
        {
            lista.Add(detalleFacturaDTO);
            // Reenumerate 
            int idx = 1;
            lista.ForEach(p => p.DetalleId = idx++);
            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;
        }
        else
        {
            json = (string)TempData["CartShopping"]!;
            lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
            lista.Add(detalleFacturaDTO);
            // Reenumerate 
            int idx = 1;
            lista.ForEach(p => p.DetalleId = idx++);
            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;
        }

        TempData.Keep();
        return PartialView("_DetailFactura", lista);
    }

    public IActionResult GetDetailFactura()
    {
        List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
        string json = "";
        json = (string)TempData["CartShopping"]!;
        lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
        // Reenumerate 
        int idx = 1;
        lista.ForEach(p => p.DetalleId = idx++);
        json = JsonSerializer.Serialize(lista);
        TempData["CartShopping"] = json;
        TempData.Keep();

        return PartialView("_DetailFactura", lista);
    }

    public IActionResult DeleteProduct(int id)
    {
        DetalleFacturaDTO facturaDetalleDTO = new DetalleFacturaDTO();
        List<DetalleFacturaDTO> lista = new List<DetalleFacturaDTO>();
        string json = "";

        if (TempData["CartShopping"] != null)
        {
            json = (string)TempData["CartShopping"]!;
            lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;
            // Remove from list by Index
            int idx = lista.FindIndex(p => p.DetalleId == id);
            lista.RemoveAt(idx);
            json = JsonSerializer.Serialize(lista);
            TempData["CartShopping"] = json;
        }

        TempData.Keep();

        // return Content("Ok");
        return PartialView("_DetailFactura", lista);

    }


    public async Task<IActionResult> Create(EncabezadoFacturaDTO facturaDTO)
    {
        string json;
        try
        {

            if (!ModelState.IsValid)
            {

            }

            json = (string)TempData["CartShopping"]!;

            if (string.IsNullOrEmpty(json))
            {
                return BadRequest("No hay datos por facturar");
            }

            var lista = JsonSerializer.Deserialize<List<DetalleFacturaDTO>>(json!)!;

            //Mismo numero de factura para el detalle FK
            lista.ForEach(p => p.FacturaId = facturaDTO.FacturaId);
            facturaDTO.ListDetalleFactura = lista;

            await _serviceFactura.AddAsync(facturaDTO);


            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            // Keep Cache data
            TempData.Keep();
            return BadRequest(ex.Message);
        }
    }
}

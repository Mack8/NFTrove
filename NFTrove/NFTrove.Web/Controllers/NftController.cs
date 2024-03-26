using Microsoft.AspNetCore.Mvc;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Implementations;
using NFTrove.Application.Services.Interfaces;
using NFTrove.Infraestructure.Models;
using System.Collections.Generic;

namespace NFTrove.Web.Controllers;

    public class NftController : Controller
    {
    private readonly IServiceNft _serviceNft;
    
    public NftController(IServiceNft servicioNft)
    {
        _serviceNft = servicioNft;
       
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var collection = await _serviceNft.ListAsync();
        return View(collection);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NftDTO dto, IFormFile imageFile)
    {
        MemoryStream target = new MemoryStream();

        // Cuando es Insert Image viene en null porque se pasa diferente
        if (dto.Imagen == null)
        {
            if (imageFile != null)
            {
                imageFile.OpenReadStream().CopyTo(target);

                dto.Imagen = target.ToArray();
                ModelState.Remove("Imagen");
            }
        }

        if (!ModelState.IsValid)
        {
            // Lee del ModelState todos los errores que
            // vienen para el lado del server
            string errors = string.Join("; ", ModelState.Values
                               .SelectMany(x => x.Errors)
                               .Select(x => x.ErrorMessage));
            // Response errores
            return BadRequest(errors);
        }

        await _serviceNft.AddAsync(dto);
        return RedirectToAction("Index");

    }


    // GET: ProductoController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

    // GET: ProductoController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

    // POST: ProductoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, NftDTO dto)
    {
        await _serviceNft.UpdateAsync(id, dto);
        return RedirectToAction("Index");
    }

    // GET: ProductoController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

    // POST: ProductoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, IFormCollection collection)
    {
        await _serviceNft.DeleteAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> GetProductoByName(string filtro)
    {

        var collection = await _serviceNft.FindByDescriptionAsync(filtro);
        return Json(collection);

    }
}


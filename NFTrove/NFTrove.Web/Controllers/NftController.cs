﻿using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Create()

    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NftDTO dto, IFormFile imageFile)
    {
        MemoryStream target = new MemoryStream();

       
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
           
            string errors = string.Join("; ", ModelState.Values
                               .SelectMany(x => x.Errors)
                               .Select(x => x.ErrorMessage));
            
            return BadRequest(errors);
        }

        await _serviceNft.AddAsync(dto);
        return RedirectToAction("Index");

    }

     public async Task<IActionResult> Edit(Guid id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, NftDTO dto, IFormFile imageFile)
    {
        MemoryStream target = new MemoryStream();

       
        if (dto.Imagen == null)
        {
            if (imageFile != null)
            {
                imageFile.OpenReadStream().CopyTo(target);

                dto.Imagen = target.ToArray();
                ModelState.Remove("Imagen");
            }
        }

        await _serviceNft.UpdateAsync(id, dto);
        return RedirectToAction("Index");
    }
 
    public async Task<IActionResult> Details(Guid id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

   
    public async Task<IActionResult> Delete(Guid id)
    {
        var @object = await _serviceNft.FindByIdAsync(id);
        return View(@object);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, IFormCollection collection)
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


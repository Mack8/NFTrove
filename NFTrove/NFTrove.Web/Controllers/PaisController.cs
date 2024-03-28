using Microsoft.AspNetCore.Mvc;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;

namespace NFTrove.Web.Controllers
{
    public class PaisController : Controller
    {
        
        private readonly IServicePais _servicePais;

        public PaisController(IServicePais servicePais)
        {
            
            _servicePais = servicePais;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _servicePais.ListAsync();
            return View(collection);
        }

        public IActionResult Create()

        {
            var paises = _servicePais.ListAsync().Result;
            ViewBag.Paises = paises;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaisDTO dto)
        {

            if (!ModelState.IsValid)
            {

                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            await _servicePais.AddAsync(dto);


            return RedirectToAction("Index");

        }




        public async Task<IActionResult> Details(int id)
        {
            var @object = await _servicePais.FindByIdAsync(id);
            var paises = await _servicePais.ListAsync();
            ViewBag.Paises = paises;
            return PartialView("_Details", @object);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var @object = await _servicePais.FindByIdAsync(id);
            if (@object == null)
            {
                return NotFound();
            }
            return View(@object);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaisDTO dto)
        {
            if (id != dto.ID)
            {
                return BadRequest();
            }

            await _servicePais.UpdateAsync(id, dto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var @object = await _servicePais.FindByIdAsync(id);
            if (@object == null)
            {
                return NotFound();
            }

            return View(@object);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            await _servicePais.DeleteAsync(id);

            return RedirectToAction("Index");
        }




    }
}

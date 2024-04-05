using Microsoft.AspNetCore.Mvc;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Implementations;
using NFTrove.Application.Services.Interfaces;

namespace NFTrove.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IServicePais _servicePais;

        public ClienteController(IServiceCliente serviceCliente, IServicePais servicePais)
        {
            _serviceCliente = serviceCliente;
            _servicePais = servicePais;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceCliente.ListAsync();
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
        public async Task<IActionResult> Create(ClienteDTO dto)
        {

            if (!ModelState.IsValid)
            {

                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            await _serviceCliente.AddAsync(dto);


            return RedirectToAction("Index");

        }



       
        public async Task<IActionResult> Details(string id)
        {
            var @object = await _serviceCliente.FindByIdAsync(id);
            var paises = await  _servicePais.ListAsync();
            ViewBag.Paises = paises;
            return PartialView("_Details", @object);
        }




        public async Task<IActionResult> Edit(string id)
        {
            var paises = _servicePais.ListAsync().Result;
            ViewBag.Paises = paises;
            var @object = await _serviceCliente.FindByIdAsync(id);

            return View(@object);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ClienteDTO dto)
        {

            await _serviceCliente.UpdateAsync(id, dto);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(string id)
        {
            var @object = await _serviceCliente.FindByIdAsync(id);

            return View(@object);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            await _serviceCliente.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult GetClienteByName(string filtro)
        {

            var collections = _serviceCliente.FindByDescriptionAsync(filtro).GetAwaiter().GetResult();

            return Json(collections);
        }


    }
}

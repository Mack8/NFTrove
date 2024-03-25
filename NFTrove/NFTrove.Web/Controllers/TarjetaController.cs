using Microsoft.AspNetCore.Mvc;
using NFTrove.Application.DTOs;
using NFTrove.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace NFTrove.Web.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly IServiceTarjeta _serviceTarjeta;

        public TarjetaController(IServiceTarjeta serviceTarjeta)
        {
            _serviceTarjeta = serviceTarjeta;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceTarjeta.ListAsync();
            return View(collection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TarjetaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }

            await _serviceTarjeta.AddAsync(dto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var @object = await _serviceTarjeta.FindByIdAsync(id);
            return View(@object);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var @object = await _serviceTarjeta.FindByIdAsync(id);
            return View(@object);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TarjetaDTO dto)
        {
            await _serviceTarjeta.UpdateAsync(id, dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var @object = await _serviceTarjeta.FindByIdAsync(id);
            return View(@object);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceTarjeta.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

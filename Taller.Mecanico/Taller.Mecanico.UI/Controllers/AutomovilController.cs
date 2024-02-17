using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Implementacion;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.UI.Auxiliar;

namespace Taller.Mecanico.UI.Controllers
{
    public class AutomovilController : Controller
    {
        private readonly IAutomovilService automovilService;

        public AutomovilController(IAutomovilService automovilService)
        {
            this.automovilService = automovilService;
        }

        // GET: AutomovilController
        public ActionResult Index()
        {
            var model = HttpContext.Session.GetObjectFromJson<VehiculoDTO>("vehiculo");
            if (model == null) return View();

            var auto = new AutomovilDTO
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                CantidadPuertas = model.CantidadPuertas,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Patente = model.Patente,
                Tipo = model.Tipo
            };
            return View(auto);
        }

        // GET: AutomovilController/Details/5
        public ActionResult ShowVehiculo()
        {
            return View();
        }

        // GET: AutomovilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutomovilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutomovilController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutomovilController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutomovilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutomovilController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

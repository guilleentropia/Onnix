using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaAppService _marcaAppService;

        public MarcaController(IMarcaAppService marcaAppService)
        {
            _marcaAppService = marcaAppService;
        }


        // GET: Marca
        public ActionResult Index()
        {
            var marcaViewModel = Mapper.Map<IEnumerable<Marca>,
                IEnumerable<MarcaViewModel>>(_marcaAppService.ObtenerTodo());
            return View(marcaViewModel);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            var marca = _marcaAppService.BuscarporId(id);
            var marcaviewmodel = Mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaviewmodel);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDominio = Mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaAppService.Agregar(marcaDominio);

                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            var marca = _marcaAppService.BuscarporId(id);
            var marcaviewmodel = Mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaviewmodel);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDominio = Mapper.Map<MarcaViewModel, Marca>(marca);
                _marcaAppService.Actualizar(marcaDominio);

                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            var marca = _marcaAppService.BuscarporId(id);
            var marcaviewmodel = Mapper.Map<Marca, MarcaViewModel>(marca);

            return View(marcaviewmodel);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var marca = _marcaAppService.BuscarporId(id);
            _marcaAppService.Eliminar(marca);

            return RedirectToAction("Index");
        }
    }
}

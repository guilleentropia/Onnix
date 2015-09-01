using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class TipoTerceroController : Controller
    {
        private readonly ITipoTerceroAppService _tipoterceroAppService;

        public TipoTerceroController(ITipoTerceroAppService tipoterceroAppService)
        {
            _tipoterceroAppService = tipoterceroAppService;
        }


        // GET: TipoTercero
        public ActionResult Index()
        {
            var tipoterceroViewModel = Mapper.Map<IEnumerable<TipoTercero>,
                IEnumerable<TipoTerceroViewModel>>(_tipoterceroAppService.ObtenerTodo());
            return View(tipoterceroViewModel);
        }

        // GET: TipoTercero/Details/5
        public ActionResult Details(int id)
        {
            var tipotercero = _tipoterceroAppService.BuscarporId(id);
            var tipoterceroviewmodel = Mapper.Map<TipoTercero, TipoTerceroViewModel>(tipotercero);

            return View(tipoterceroviewmodel);
        }

        // GET: TipoTercero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTercero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoTerceroViewModel tipotercero)
        {
            if (ModelState.IsValid)
            {
                var tipoterceroDominio = Mapper.Map<TipoTerceroViewModel, TipoTercero>(tipotercero);
                _tipoterceroAppService.Agregar(tipoterceroDominio);

                return RedirectToAction("Index");
            }

            return View(tipotercero);
        }

        // GET: TipoTercero/Edit/5
        public ActionResult Edit(int id)
        {
            var tipotercero = _tipoterceroAppService.BuscarporId(id);
            var tipoterceroviewmodel = Mapper.Map<TipoTercero, TipoTerceroViewModel>(tipotercero);

            return View(tipoterceroviewmodel);
        }

        // POST: TipoTercero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoTerceroViewModel tipotercero)
        {
            if (ModelState.IsValid)
            {
                var tipoterceroDominio = Mapper.Map<TipoTerceroViewModel, TipoTercero>(tipotercero);
                _tipoterceroAppService.Actualizar(tipoterceroDominio);

                return RedirectToAction("Index");
            }

            return View(tipotercero);
        }

        // GET: TipoTercero/Delete/5
        public ActionResult Delete(int id)
        {
            var tipotercero = _tipoterceroAppService.BuscarporId(id);
            var tipoterceroviewmodel = Mapper.Map<TipoTercero, TipoTerceroViewModel>(tipotercero);

            return View(tipoterceroviewmodel);
        }

        // POST: TipoTercero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var tipotercero = _tipoterceroAppService.BuscarporId(id);
            _tipoterceroAppService.Eliminar(tipotercero);

            return RedirectToAction("Index");
        }
    }
}

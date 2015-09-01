using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class TipoTransaccionController : Controller
    {
        private readonly ITipoTransaccionAppService _tipoTransaccionAppService;

        public TipoTransaccionController(ITipoTransaccionAppService tipoTransaccionAppService)
        {
            _tipoTransaccionAppService = tipoTransaccionAppService;
        }


        // GET: TipoTransaccion
        public ActionResult Index()
        {
            var tipotransaccionViewModel = Mapper.Map<IEnumerable<TipoTransaccion>,
               IEnumerable<TipoTransaccionViewModel>>(_tipoTransaccionAppService.ObtenerTodo());
            return View(tipotransaccionViewModel);
        }

        // GET: TipoTransaccion/Details/5
        public ActionResult Details(int id)
        {
            var tipotransaccion = _tipoTransaccionAppService.BuscarporId(id);
            var tipotransaccionviewmodel = Mapper.Map<TipoTransaccion, TipoTransaccionViewModel>(tipotransaccion);

            return View(tipotransaccionviewmodel);
        }

        // GET: TipoTransaccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTransaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoTransaccionViewModel tipotransaccion)
        {
            if (ModelState.IsValid)
            {
                var tipotransaccionDominio = Mapper.Map<TipoTransaccionViewModel, TipoTransaccion>(tipotransaccion);
                _tipoTransaccionAppService.Agregar(tipotransaccionDominio);

                return RedirectToAction("Index");
            }

            return View(tipotransaccion);
        }

        // GET: TipoTransaccion/Edit/5
        public ActionResult Edit(int id)
        {
            var tipotransaccion = _tipoTransaccionAppService.BuscarporId(id);
            var tipotransaccionviewmodel = Mapper.Map<TipoTransaccion, TipoTransaccionViewModel>(tipotransaccion);

            return View(tipotransaccionviewmodel);
        }

        // POST: TipoTransaccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoTransaccionViewModel tipotransaccion)
        {
            if (ModelState.IsValid)
            {
                var tipotransaccionDominio = Mapper.Map<TipoTransaccionViewModel, TipoTransaccion>(tipotransaccion);
                _tipoTransaccionAppService.Actualizar(tipotransaccionDominio);

                return RedirectToAction("Index");
            }

            return View(tipotransaccion);
        }

        // GET: TipoTransaccion/Delete/5
        public ActionResult Delete(int id)
        {
            var tipotransaccion = _tipoTransaccionAppService.BuscarporId(id);
            var tipotransaccionviewmodel = Mapper.Map<TipoTransaccion, TipoTransaccionViewModel>(tipotransaccion);

            return View(tipotransaccionviewmodel);
        }

        // POST: TipoTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var tipotransaccion = _tipoTransaccionAppService.BuscarporId(id);
            _tipoTransaccionAppService.Eliminar(tipotransaccion);

            return RedirectToAction("Index");
        }
    }
}

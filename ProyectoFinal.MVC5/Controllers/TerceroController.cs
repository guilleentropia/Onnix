using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class TerceroController : Controller
    {
        private readonly ITerceroAppService _terceroAppService;
        private readonly ITipoTerceroAppService _tipoterceroAppService;

        public TerceroController(ITerceroAppService terceroAppService, ITipoTerceroAppService tipoTerceroAppService)
        {
            _terceroAppService = terceroAppService;
            _tipoterceroAppService = tipoTerceroAppService;
        }


        // GET: /Tercero/
        public ActionResult Index()
        {
            
            var terceroViewModel = Mapper.Map<IEnumerable<Tercero>,
                IEnumerable<TerceroViewModel>>(_terceroAppService.ObtenerTodo());
            return View(terceroViewModel);
            
            
            
        }

        //
        // GET: /Tercero/Details/5
        public ActionResult Details(int id)
        {
            var tercero = _terceroAppService.BuscarporId(id);
            var terceroviewmodel = Mapper.Map<Tercero, TerceroViewModel>(tercero);

            return View(terceroviewmodel);
        }

        //
        // GET: /Tercero/Create
        public ActionResult Create()
        {
            ViewBag.TipoTerceroId = new SelectList(_tipoterceroAppService.ObtenerTodo(),"Id","Descripcion");
            return View();
        }

        //
        // POST: /Tercero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TerceroViewModel tercero)
        {
            if (ModelState.IsValid)
            {
                var terceroDominio = Mapper.Map<TerceroViewModel, Tercero>(tercero);
                _terceroAppService.Agregar(terceroDominio);

                return RedirectToAction("Index");
            }

         
            ViewBag.TipoTerceroId = new SelectList(_tipoterceroAppService.ObtenerTodo(),"Id","Descripcion",tercero.TipoTerceroId);
            return View(tercero);
        }

        //
        // GET: /Tercero/Edit/5
        public ActionResult Edit(int id)
        {
            var tercero = _terceroAppService.BuscarporId(id);
            var terceroviewmodel = Mapper.Map<Tercero, TerceroViewModel>(tercero);

            ViewBag.TipoTerceroId = new SelectList(_tipoterceroAppService.ObtenerTodo(), "Id", "Descripcion", terceroviewmodel.TipoTerceroId);

            return View(terceroviewmodel);
        }

        //
        // POST: /Tercero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TerceroViewModel tercero)
        {
            if (ModelState.IsValid)
            {
                var terceroDominio = Mapper.Map<TerceroViewModel, Tercero>(tercero);
                _terceroAppService.Actualizar(terceroDominio);

                return RedirectToAction("Index");
            }
            ViewBag.TipoTerceroId = new SelectList(_tipoterceroAppService.ObtenerTodo(), "Id", "Descripcion", tercero.TipoTerceroId);
            return View(tercero);
        }

        //
        // GET: /Tercero/Delete/5
        public ActionResult Delete(int id)
        {
            var tercero = _terceroAppService.BuscarporId(id);
            var terceroviewmodel = Mapper.Map<Tercero, TerceroViewModel>(tercero);

            return View(terceroviewmodel);
        }

        //
        // POST: /Tercero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var tercero = _terceroAppService.BuscarporId(id);
            _terceroAppService.Eliminar(tercero);

            return RedirectToAction("Index");
        }



        public JsonResult ObtenerTipoTercero()
        {

            return Json(_tipoterceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;
using System;

namespace ProyectoFinal.MVC5.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaAppService _facturaAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITerceroAppService _terceroAppService;

        public FacturaController(IFacturaAppService facturaAppService, IUsuarioAppService usuarioAppService,
            ITerceroAppService terceroAppService)
        {
            _facturaAppService = facturaAppService;
            _usuarioAppService = usuarioAppService;
            _terceroAppService = terceroAppService;
        }


        // GET: Factura
        public ActionResult Index()
        {
            var facturaViewModel = Mapper.Map<IEnumerable<Factura>,
                IEnumerable<FacturaViewModel>>(_facturaAppService.ObtenerTodo());
            return View(facturaViewModel);
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            var factura = _facturaAppService.BuscarporId(id);
            var facturaviewmodel = Mapper.Map<Factura, FacturaViewModel>(factura);

            return View(facturaviewmodel);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario");
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido");
            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel factura)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    var facturaDominio = Mapper.Map<FacturaViewModel, Factura>(factura);
                    _facturaAppService.Agregar(facturaDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }


            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", factura.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", factura.TerceroId);

            return View(factura);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            var factura = _facturaAppService.BuscarporId(id);
            var facturaviewmodel = Mapper.Map<Factura, FacturaViewModel>(factura);

            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", facturaviewmodel.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", facturaviewmodel.TerceroId);

            return View(facturaviewmodel);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel factura)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var facturaDominio = Mapper.Map<FacturaViewModel, Factura>(factura);
                    _facturaAppService.Actualizar(facturaDominio);

                    return RedirectToAction("Index");
                }

                catch (Exception ex)
                {
                    return View(ex.Message);
                }
                
                
            }
            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", factura.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", factura.TerceroId);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            var factura = _facturaAppService.BuscarporId(id);
            var facturaviewmodel = Mapper.Map<Factura, FacturaViewModel>(factura);

            return View(facturaviewmodel);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var factura = _facturaAppService.BuscarporId(id);
            _facturaAppService.Eliminar(factura);

            return RedirectToAction("Index");
        }



        public JsonResult ObtenerUsuario()
        {

            return Json(_usuarioAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult ObtenerTercero()
        {

            return Json(_terceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}

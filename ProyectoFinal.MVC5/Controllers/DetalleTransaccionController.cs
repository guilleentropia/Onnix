using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;
using System;

namespace ProyectoFinal.MVC5.Controllers
{
    public class DetalleTransaccionController : Controller
    {

        private readonly IDetalleTransaccionAppService _detalleTransaccionAppService;
        private readonly ITransaccionAppService _transaccionAppService;
        private readonly IProductoAppService _productoAppService;

        public DetalleTransaccionController(IDetalleTransaccionAppService detalleTransaccionAppService,
            ITransaccionAppService transaccionAppService, IProductoAppService productoAppService)
        {
            _detalleTransaccionAppService = detalleTransaccionAppService;
            _transaccionAppService = transaccionAppService;
            _productoAppService = productoAppService;
        }


        // GET: DetalleTransaccion
        public ActionResult Index()
        {
            var detalletransaccionViewModel = Mapper.Map<IEnumerable<DetalleTransaccion>,
                IEnumerable<DetalleTransaccionViewModel>>(_detalleTransaccionAppService.ObtenerTodo());
            return View(detalletransaccionViewModel);
        }

        // GET: DetalleTransaccion/Details/5
        public ActionResult Details(int id)
        {
            var detalletransaccion = _detalleTransaccionAppService.BuscarporId(id);
            var detalletransaccionviewmodel = Mapper.Map<DetalleTransaccion, DetalleTransaccionViewModel>(detalletransaccion);

            return View(detalletransaccionviewmodel);
        }

        // GET: DetalleTransaccion/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.TransaccionId = new SelectList(_transaccionAppService.ObtenerTodo(), "Id", "Fecha");
            return View();
        }

        // POST: DetalleTransaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleTransaccionViewModel detalletransaccion)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var detalletransaccionDominio = Mapper.Map<DetalleTransaccionViewModel, DetalleTransaccion>(detalletransaccion);
                    _detalleTransaccionAppService.Agregar(detalletransaccionDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            }    

            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detalletransaccion.ProductoId);
            ViewBag.TransaccionId = new SelectList(_transaccionAppService.ObtenerTodo(), "Id", "Fecha", detalletransaccion.TransaccionId);
            return View(detalletransaccion);
        }

        // GET: DetalleTransaccion/Edit/5
        public ActionResult Edit(int id)
        {
            var detalletransaccion = _detalleTransaccionAppService.BuscarporId(id);
            var detalletransaccionviewmodel = Mapper.Map<DetalleTransaccion, DetalleTransaccionViewModel>(detalletransaccion);


            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detalletransaccionviewmodel.ProductoId);
            ViewBag.TransaccionId = new SelectList(_transaccionAppService.ObtenerTodo(), "Id", "Fecha", detalletransaccionviewmodel.TransaccionId);

            return View(detalletransaccionviewmodel);
        }

        // POST: DetalleTransaccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleTransaccionViewModel detalletransaccion)
        {
            if (ModelState.IsValid)
            {
                
                try
                { 
                    var detalletransaccionDominio =
                    Mapper.Map<DetalleTransaccionViewModel, DetalleTransaccion>(detalletransaccion);
                _detalleTransaccionAppService.Actualizar(detalletransaccionDominio);

                return RedirectToAction("Index");

                }

                catch(Exception ex)
                {
                    return View(ex.Message);
                }
                
               
            }
            
            
            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detalletransaccion.ProductoId);
            ViewBag.TransaccionId = new SelectList(_transaccionAppService.ObtenerTodo(), "Id", "Fecha", detalletransaccion.TransaccionId);


           return View(detalletransaccion);
            
        }

        // GET: DetalleTransaccion/Delete/5
        public ActionResult Delete(int id)
        {
            var detalletransaccion = _detalleTransaccionAppService.BuscarporId(id);
            var detalletransaccionviewmodel = Mapper.Map<DetalleTransaccion, DetalleTransaccionViewModel>(detalletransaccion);

            return View(detalletransaccionviewmodel);
        }

        // POST: DetalleTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var detalletransaccion = _detalleTransaccionAppService.BuscarporId(id);
            _detalleTransaccionAppService.Eliminar(detalletransaccion);

            return RedirectToAction("Index");
        }


        public JsonResult ObtenerTransaccion()
        {

            return Json(_transaccionAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerProducto()
        {

            return Json(_productoAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;
using System;

namespace ProyectoFinal.MVC5.Controllers
{
    public class TransaccionController : Controller
    {
        private readonly ITransaccionAppService _transaccionAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITerceroAppService _terceroAppService;
        private readonly IFacturaAppService _facturaAppService;
        private readonly ITipoTransaccionAppService _tipoTransaccionAppService;
        private readonly IFormaPagoAppService _formaPagoAppService;

        public TransaccionController(ITransaccionAppService transaccionAppService, IUsuarioAppService usuarioAppService,
            ITerceroAppService terceroAppService, IFacturaAppService facturaAppService, ITipoTransaccionAppService tipoTransaccionAppService,
            IFormaPagoAppService formaPagoAppService)
        {
            _transaccionAppService = transaccionAppService;
            _usuarioAppService = usuarioAppService;
            _terceroAppService = terceroAppService;
            _facturaAppService = facturaAppService;
            _tipoTransaccionAppService = tipoTransaccionAppService;
            _formaPagoAppService = formaPagoAppService;
        }


        // GET: Transaccion
        public ActionResult Index()
        {
            var transaccionViewModel = Mapper.Map<IEnumerable<Transaccion>,
                IEnumerable<TransaccionViewModel>>(_transaccionAppService.ObtenerTodo());
            return View(transaccionViewModel);
        }

        // GET: Transaccion/Details/5
        public ActionResult Details(int id)
        {
            var transaccion = _transaccionAppService.BuscarporId(id);
            var transaccionviewmodel = Mapper.Map<Transaccion, TransaccionViewModel>(transaccion);

            return View(transaccionviewmodel);
        }

        // GET: Transaccion/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario");
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido");
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura");
            ViewBag.TipoTransaccionId = new SelectList(_tipoTransaccionAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.FormaPagoId = new SelectList(_formaPagoAppService.ObtenerTodo(), "Id", "Descripcion");
            return View();
        }

        // POST: Transaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransaccionViewModel transaccion)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var transaccionDominio = Mapper.Map<TransaccionViewModel, Transaccion>(transaccion);
                    _transaccionAppService.Agregar(transaccionDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
                
                
            }


            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", transaccion.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", transaccion.TerceroId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", transaccion.FacturaId);
            ViewBag.TipoTransaccionId = new SelectList(_tipoTransaccionAppService.ObtenerTodo(), "Id", "Descripcion", transaccion.TipoTransaccionId);
            ViewBag.FormaPagoId = new SelectList(_formaPagoAppService.ObtenerTodo(), "Id", "Descripcion", transaccion.FormaPagoId);


            return View(transaccion);
        }

        // GET: Transaccion/Edit/5
        public ActionResult Edit(int id)
        {
            var transaccion = _transaccionAppService.BuscarporId(id);
            var transaccionviewmodel = Mapper.Map<Transaccion, TransaccionViewModel>(transaccion);

            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", transaccionviewmodel.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", transaccionviewmodel.TerceroId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", transaccionviewmodel.FacturaId);
            ViewBag.TipoTransaccionId = new SelectList(_tipoTransaccionAppService.ObtenerTodo(), "Id", "Descripcion", transaccionviewmodel.TipoTransaccionId);
            ViewBag.FormaPagoId = new SelectList(_formaPagoAppService.ObtenerTodo(), "Id", "Descripcion", transaccionviewmodel.FormaPagoId);


            return View(transaccionviewmodel);
        }

        // POST: Transaccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransaccionViewModel transaccion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transaccionDominio = Mapper.Map<TransaccionViewModel, Transaccion>(transaccion);
                    _transaccionAppService.Actualizar(transaccionDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
                
                
               
            }
            ViewBag.UsuarioId = new SelectList(_usuarioAppService.ObtenerTodo(), "Id", "NombreUsuario", transaccion.UsuarioId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", transaccion.TerceroId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", transaccion.FacturaId);
            ViewBag.TipoTransaccionId = new SelectList(_tipoTransaccionAppService.ObtenerTodo(), "Id", "Descripcion", transaccion.TipoTransaccionId);
            ViewBag.FormaPagoId = new SelectList(_formaPagoAppService.ObtenerTodo(), "Id", "Descripcion", transaccion.FormaPagoId);


            return View(transaccion);
        }

        // GET: Transaccion/Delete/5
        public ActionResult Delete(int id)
        {
            var transaccion = _transaccionAppService.BuscarporId(id);
            var transaccionviewmodel = Mapper.Map<Transaccion, TransaccionViewModel>(transaccion);

            return View(transaccionviewmodel);
        }

        // POST: Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var transaccion = _transaccionAppService.BuscarporId(id);
            _transaccionAppService.Eliminar(transaccion);

            return RedirectToAction("Index");
        }


        public JsonResult ObtenerUsuarios()
        {

            return Json(_usuarioAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerTerceros()
        {

            return Json(_terceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerFacturas()
        {

            return Json(_facturaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerTipoTransaccion()
        {

            return Json(_tipoTransaccionAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerFormaPago()
        {

            return Json(_formaPagoAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }

    }
}

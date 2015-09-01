using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class DetalleFacturaController : Controller
    {

        private readonly IDetalleFacturaAppService _detalleFacturaAppService;
        private readonly IFacturaAppService _facturaAppService;
        private readonly IProductoAppService _productoAppService;

        public DetalleFacturaController(IDetalleFacturaAppService detalleFacturaAppService, IFacturaAppService facturaAppService,
            IProductoAppService productoAppService)
        {
            _detalleFacturaAppService = detalleFacturaAppService;
            _facturaAppService = facturaAppService;
            _productoAppService = productoAppService;
        }


        // GET: DetalleFactura
        public ActionResult Index()
        {
            var detallefacturaViewModel = Mapper.Map<IEnumerable<DetalleFactura>,
               IEnumerable<DetalleFacturaViewModel>>(_detalleFacturaAppService.ObtenerTodo());
            return View(detallefacturaViewModel);
        }

        // GET: DetalleFactura/Details/5
        public ActionResult Details(int id)
        {
            var detallefactura = _detalleFacturaAppService.BuscarporId(id);
            var detallefacturaviewmodel = Mapper.Map<DetalleFactura, DetalleFacturaViewModel>(detallefactura);

            return View(detallefacturaviewmodel);
        }

        // GET: DetalleFactura/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura");

            return View();
        }

        // POST: DetalleFactura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleFacturaViewModel detallefactura)
        {
            if (ModelState.IsValid)
            {
                var detallefacturaDominio = Mapper.Map<DetalleFacturaViewModel, DetalleFactura>(detallefactura);
                _detalleFacturaAppService.Agregar(detallefacturaDominio);

                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detallefactura.ProductoId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", detallefactura.FacturaId);
            return View(detallefactura);
        }

        // GET: DetalleFactura/Edit/5
        public ActionResult Edit(int id)
        {
            var detallefactura = _detalleFacturaAppService.BuscarporId(id);
            var detallefacturaviewmodel = Mapper.Map<DetalleFactura, DetalleFacturaViewModel>(detallefactura);


            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detallefacturaviewmodel.ProductoId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", detallefacturaviewmodel.FacturaId);

            return View(detallefacturaviewmodel);
        }

        // POST: DetalleFactura/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleFacturaViewModel detallefactura)
        {
            if (ModelState.IsValid)
            {
                var detallefacturaDominio =
                    Mapper.Map<DetalleFacturaViewModel, DetalleFactura>(detallefactura);
                _detalleFacturaAppService.Actualizar(detallefacturaDominio);

                return RedirectToAction("Index");
            }


            ViewBag.ProductoId = new SelectList(_productoAppService.ObtenerTodo(), "Id", "Descripcion", detallefactura.ProductoId);
            ViewBag.FacturaId = new SelectList(_facturaAppService.ObtenerTodo(), "Id", "NumeroFactura", detallefactura.FacturaId);


            return View(detallefactura);
        }

        // GET: DetalleFactura/Delete/5
        public ActionResult Delete(int id)
        {
            var detallefactura = _detalleFacturaAppService.BuscarporId(id);
            var detallefacturaviewmodel = Mapper.Map<DetalleFactura, DetalleFacturaViewModel>(detallefactura);

            return View(detallefacturaviewmodel);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var detallefactura = _detalleFacturaAppService.BuscarporId(id);
            _detalleFacturaAppService.Eliminar(detallefactura);

            return RedirectToAction("Index");
        }


        public JsonResult ObtenerFactura()
        {

            return Json(_facturaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerProducto()
        {

            return Json(_productoAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}

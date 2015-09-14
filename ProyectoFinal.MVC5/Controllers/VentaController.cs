using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.MVC5.ViewModels;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.Controllers
{
    public class VentaController : Controller
    {
        private readonly ITerceroAppService _terceroAppService;
        private readonly IFormaPagoAppService _formapagoAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IFacturaAppService _facturaAppService;
        private readonly IDetalleFacturaAppService _detallefacturaAppService;
        private readonly ITransaccionAppService _transaccionAppService;
        private readonly IDetalleTransaccionAppService _detalletransaccionAppService;
        private readonly IProductoAppService _productoAppService;

        public VentaController(ITerceroAppService terceroAppService, IFormaPagoAppService formapagoAppService, IUsuarioAppService
            usuarioAppService, IFacturaAppService facturaAppService, IDetalleFacturaAppService detallefacturaAppService,
            ITransaccionAppService transaccionAppService, IDetalleTransaccionAppService detalletransaccionAppService,
            IProductoAppService productoAppService)
        {
            _terceroAppService = terceroAppService;
            _formapagoAppService = formapagoAppService;
            _usuarioAppService = usuarioAppService;
            _facturaAppService = facturaAppService;
            _detallefacturaAppService = detallefacturaAppService;
            _transaccionAppService = transaccionAppService;
            _detalletransaccionAppService = detalletransaccionAppService;
            _productoAppService = productoAppService;
        }

        // GET: Venta
        public ActionResult Index()
        {
            ViewBag.Clientes = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "NombreCompleto");
            ViewBag.FormaPago = new SelectList(_formapagoAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.Productos = (List<Item>)Session["cart"];
            ViewBag.Fecha = DateTime.Now;
            var a = Session["User"];
            return View();
        }

        [HttpPost]
        public ActionResult Venta()
        {
            try { 
                string usuario = Request["nombreuser"].ToString();
            var fechahoy = Convert.ToDateTime(Request["fechahoy"].ToString());
            var total = Convert.ToDecimal(Request["total"].ToString());
            var cliente = Convert.ToInt32(Request["Clientes"].ToString());
            var formapago = Convert.ToInt32(Request["FormaPago"].ToString());

            var usuer = _usuarioAppService.BuscarIdUsuarioporNombre(usuario);
            int idusuario = usuer.Id;

            //Factura
            Factura factura = new Factura();
            factura.NumeroFactura = 456789;
            factura.Fecha = fechahoy;
            factura.Total = total;
            factura.UsuarioId = idusuario;
            factura.TerceroId = cliente;
            _facturaAppService.Agregar(factura);

            // Transaccion
            Transaccion transaccion = new Transaccion();
            transaccion.Fecha = fechahoy;
            transaccion.Total = total;
            transaccion.UsuarioId = idusuario;
            transaccion.TerceroId = cliente;
            Factura obtengo = new Factura();
            obtengo= _facturaAppService.UltimaFactura();
            transaccion.FacturaId = obtengo.Id;
            transaccion.TipoTransaccionId = 2;
            transaccion.FormaPagoId = formapago;
            _transaccionAppService.Agregar(transaccion);


            ViewBag.Productos = (List<Item>)Session["cart"];
            foreach (var item in ViewBag.Productos)
            {
                var cantidad = item.Cantidad;
                var subtotal = item.SubTotal;
                var producto = Convert.ToInt32(item.producto.Id);

                //Actualizacion de Stock
                
                 _productoAppService.BuscarProductoStock(producto);
                

                //Detalle de Factura
                Factura ultima = new Factura();
                ultima = _facturaAppService.UltimaFactura();
                var id = ultima.Id;
                DetalleFactura detalle = new DetalleFactura();
                detalle.Cantidad = cantidad;
                detalle.SubTotal = Convert.ToDecimal(subtotal);
                detalle.FacturaId = id;
                detalle.ProductoId = producto;

                _detallefacturaAppService.Agregar(detalle);

                //Detalle de Transaccion
                Transaccion ultra = new Transaccion();
                ultra = _transaccionAppService.UltimaTransaccion();
                var idultra = ultra.Id;
                DetalleTransaccion detalletran = new DetalleTransaccion();
                detalletran.Cantidad = cantidad;
                detalletran.SubTotal = Convert.ToDecimal(subtotal);
                detalletran.TransaccionId = idultra;
                detalletran.ProductoId = producto;

                _detalletransaccionAppService.Agregar(detalletran);
                
            }
            
         }
         catch (Exception ex)
         {
             return View(ex.Message);  
         }

            Session["cart"] = null;
            return RedirectToAction("Busqueda", "Producto");
        }


        public JsonResult ObtenerCliente()
        {

            return Json(_terceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerFormaPago()
        {

            return Json(_formapagoAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }



    }
}
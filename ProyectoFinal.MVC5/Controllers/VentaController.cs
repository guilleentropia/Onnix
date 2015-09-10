using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.MVC5.ViewModels;
using ProyectoFinal.Aplicacion.Interface;

namespace ProyectoFinal.MVC5.Controllers
{
    public class VentaController : Controller
    {
        private readonly ITerceroAppService _terceroAppService;
        private readonly IFormaPagoAppService _formapagoAppService;

        public VentaController(ITerceroAppService terceroAppService, IFormaPagoAppService formapagoAppService)
        {
            _terceroAppService = terceroAppService;
            _formapagoAppService = formapagoAppService;
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

        
        public ActionResult Venta(string fecha, string usuario, double total, string cli)
        {


            return View();
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
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

        public VentaController(ITerceroAppService terceroAppService)
        {
            _terceroAppService = terceroAppService;
        }

        // GET: Venta
        public ActionResult Index()
        {
            ViewBag.Clientes = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "NombreCompleto");
            ViewBag.Productos = (List<Item>)Session["cart"];
            ViewBag.Fecha = DateTime.Now;
            var a = Session["User"];
            return View();
        }


        public JsonResult ObtenerCliente()
        {

            return Json(_terceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly IEmpleadoAppService _empleadoAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public EmpleadoController(IEmpleadoAppService empleadoAppService, IEmpresaAppService empresaAppService)
        {
            _empleadoAppService = empleadoAppService;
            _empresaAppService = empresaAppService;
        }


        // GET: Empleado
        public ActionResult Index()
        {
            var empleadoViewModel = Mapper.Map<IEnumerable<Empleado>,
                  IEnumerable<EmpleadoViewModel>>(_empleadoAppService.ObtenerTodo());
            return View(empleadoViewModel);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            var empleado = _empleadoAppService.BuscarporId(id);
            var empleadoviewmodel = Mapper.Map<Empleado, EmpleadoViewModel>(empleado);

            return View(empleadoviewmodel);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion");
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoViewModel empleado)
        {
            if (ModelState.IsValid)
            {
                var empleadoDominio = Mapper.Map<EmpleadoViewModel, Empleado>(empleado);
                _empleadoAppService.Agregar(empleadoDominio);

                return RedirectToAction("Index");
            }


            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", empleado.EmpresaId);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            var empleado = _empleadoAppService.BuscarporId(id);
            var empleadoviewmodel = Mapper.Map<Empleado, EmpleadoViewModel>(empleado);

            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", empleadoviewmodel.EmpresaId);

            return View(empleadoviewmodel);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoViewModel empleado)
        {
            if (ModelState.IsValid)
            {
                var empleadoDominio = Mapper.Map<EmpleadoViewModel, Empleado>(empleado);
                _empleadoAppService.Actualizar(empleadoDominio);

                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", empleado.EmpresaId);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            var empleado = _empleadoAppService.BuscarporId(id);
            var empleadoviewmodel = Mapper.Map<Empleado, EmpleadoViewModel>(empleado);

            return View(empleadoviewmodel);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var empleado = _empleadoAppService.BuscarporId(id);
            _empleadoAppService.Eliminar(empleado);

            return RedirectToAction("Index");
        }


        public JsonResult ObtenerEmpresa()
        {

            return Json(_empresaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }

    }
}

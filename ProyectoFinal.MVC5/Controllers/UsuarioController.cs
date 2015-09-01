using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IPerfilAppService _perfilAppService;
        private readonly IEmpleadoAppService _empleadoAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, IPerfilAppService perfilAppService, 
            IEmpleadoAppService empleadoAppService, IEmpresaAppService empresaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _perfilAppService = perfilAppService;
            _empleadoAppService = empleadoAppService;
            _empresaAppService = empresaAppService;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>,
                IEnumerable<UsuarioViewModel>>(_usuarioAppService.ObtenerTodo());
            return View(usuarioViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _usuarioAppService.BuscarporId(id);
            var usuarioviewmodel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioviewmodel);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(_perfilAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.EmpleadoId = new SelectList(_empleadoAppService.ObtenerTodo(), "Id", "Nombre");
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion");

            return View();
           
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _usuarioAppService.Agregar(usuarioDominio);

                return RedirectToAction("Index");
            }


            ViewBag.PerfilId = new SelectList(_perfilAppService.ObtenerTodo(), "Id", "Descripcion", usuario.PerfilId);
            ViewBag.EmpleadoId = new SelectList(_empleadoAppService.ObtenerTodo(), "Id", "Nombre", usuario.EmpleadoId);
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", usuario.EmpresaId);

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _usuarioAppService.BuscarporId(id);
            var usuarioviewmodel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            ViewBag.PerfilId = new SelectList(_perfilAppService.ObtenerTodo(), "Id", "Descripcion", usuarioviewmodel.PerfilId);
            ViewBag.EmpleadoId = new SelectList(_empleadoAppService.ObtenerTodo(), "Id", "Nombre", usuarioviewmodel.EmpleadoId);
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", usuarioviewmodel.EmpresaId);

            return View(usuarioviewmodel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDominio = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _usuarioAppService.Actualizar(usuarioDominio);

                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(_perfilAppService.ObtenerTodo(), "Id", "Descripcion", usuario.PerfilId);
            ViewBag.EmpleadoId = new SelectList(_empleadoAppService.ObtenerTodo(), "Id", "Nombre", usuario.EmpleadoId);
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion", usuario.EmpresaId);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioAppService.BuscarporId(id);
            var usuarioviewmodel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioviewmodel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var usuario = _usuarioAppService.BuscarporId(id);
            _usuarioAppService.Eliminar(usuario);

            return RedirectToAction("Index");
        }

        public JsonResult ObtenerEmpleados()
        {

            return Json(_empleadoAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPerfiles()
        {

            return Json(_perfilAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerEmpresas()
        {
            return Json(_empresaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }
    }
}

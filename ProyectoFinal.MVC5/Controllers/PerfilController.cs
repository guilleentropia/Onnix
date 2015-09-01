using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilAppService _perfilAppService;

        public PerfilController(IPerfilAppService perfilAppService)
        {
            _perfilAppService = perfilAppService;
        }


        // GET: Perfil
        public ActionResult Index()
        {
            var perfilViewModel = Mapper.Map<IEnumerable<Perfil>,
                IEnumerable<PerfilViewModel>>(_perfilAppService.ObtenerTodo());
            return View(perfilViewModel);
        }

        // GET: Perfil/Details/5
        public ActionResult Details(int id)
        {
            var perfil = _perfilAppService.BuscarporId(id);
            var perfilviewmodel = Mapper.Map<Perfil, PerfilViewModel>(perfil);

            return View(perfilviewmodel);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerfilViewModel perfil)
        {
            if (ModelState.IsValid)
            {
                var perfilDominio = Mapper.Map<PerfilViewModel, Perfil>(perfil);
                _perfilAppService.Agregar(perfilDominio);

                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int id)
        {
            var perfil = _perfilAppService.BuscarporId(id);
            var perfilviewmodel = Mapper.Map<Perfil, PerfilViewModel>(perfil);

            return View(perfilviewmodel);
        }

        // POST: Perfil/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PerfilViewModel perfil)
        {
            if (ModelState.IsValid)
            {
                var perfilDominio = Mapper.Map<PerfilViewModel, Perfil>(perfil);
                _perfilAppService.Actualizar(perfilDominio);

                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int id)
        {
            var perfil = _perfilAppService.BuscarporId(id);
            var perfilviewmodel = Mapper.Map<Perfil, PerfilViewModel>(perfil);

            return View(perfilviewmodel);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var perfil = _perfilAppService.BuscarporId(id);
            _perfilAppService.Eliminar(perfil);

            return RedirectToAction("Index");
           
        }
    }
}

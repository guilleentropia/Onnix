using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;
using System;

namespace ProyectoFinal.MVC5.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }


        // GET: Empresa
        [Authorize(Roles="Administrador")]
        public ActionResult Index()
        {
            var empresaViewModel = Mapper.Map<IEnumerable<Empresa>,
                IEnumerable<EmpresaViewModel>>(_empresaAppService.ObtenerTodo());
            return View(empresaViewModel);
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            var empresa = _empresaAppService.BuscarporId(id);
            var empresaviewmodel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(empresaviewmodel);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empresaDominio = Mapper.Map<EmpresaViewModel, Empresa>(empresa);
                    _empresaAppService.Agregar(empresaDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }

            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            var empresa = _empresaAppService.BuscarporId(id);
            var empresaviewmodel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(empresaviewmodel);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    var empresaDominio = Mapper.Map<EmpresaViewModel, Empresa>(empresa);
                    _empresaAppService.Actualizar(empresaDominio);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }

            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            var empresa = _empresaAppService.BuscarporId(id);
            var empresaviewmodel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(empresaviewmodel);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var empresa = _empresaAppService.BuscarporId(id);
            _empresaAppService.Eliminar(empresa);

            return RedirectToAction("Index");
        }
    }
}

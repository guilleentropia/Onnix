using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }


        // GET: Categoria
        public ActionResult Index()
        {
            var categoriaViewModel = Mapper.Map<IEnumerable<Categoria>,
                IEnumerable<CategoriaViewModel>>(_categoriaAppService.ObtenerTodo());
            return View(categoriaViewModel);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            var categoria = _categoriaAppService.BuscarporId(id);
            var categoriaviewmodel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);

            return View(categoriaviewmodel);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaDominio = Mapper.Map<CategoriaViewModel, Categoria>(categoria);
                _categoriaAppService.Agregar(categoriaDominio);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = _categoriaAppService.BuscarporId(id);
            var categoriaviewmodel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);

            return View(categoriaviewmodel);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaDominio = Mapper.Map<CategoriaViewModel, Categoria>(categoria);
                _categoriaAppService.Actualizar(categoriaDominio);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Delete/5
        
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaAppService.BuscarporId(id);
            var categoriaviewmodel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);

            return View(categoriaviewmodel);
        }

        // POST: Categoria/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var categoria = _categoriaAppService.BuscarporId(id);
            _categoriaAppService.Eliminar(categoria);

            return RedirectToAction("Index");
        }
    }
}

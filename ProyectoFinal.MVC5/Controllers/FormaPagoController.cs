using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class FormaPagoController : Controller
    {
        private readonly IFormaPagoAppService _formaPagoAppService;

        public FormaPagoController(IFormaPagoAppService formaPagoAppService)
        {
            _formaPagoAppService = formaPagoAppService;
        }


        // GET: FormaPago
        public ActionResult Index()
        {
            var formapagoViewModel = Mapper.Map<IEnumerable<FormaPago>,
                IEnumerable<FormaPagoViewModel>>(_formaPagoAppService.ObtenerTodo());
            return View(formapagoViewModel);
        }

        // GET: FormaPago/Details/5
        public ActionResult Details(int id)
        {
            var formapago = _formaPagoAppService.BuscarporId(id);
            var formapagoviewmodel = Mapper.Map<FormaPago, FormaPagoViewModel>(formapago);

            return View(formapagoviewmodel);
        }

        // GET: FormaPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaPagoViewModel formapago)
        {
            if (ModelState.IsValid)
            {
                var formapagoDominio = Mapper.Map<FormaPagoViewModel, FormaPago>(formapago);
                _formaPagoAppService.Agregar(formapagoDominio);

                return RedirectToAction("Index");
            }

            return View(formapago);
        }

        // GET: FormaPago/Edit/5
        public ActionResult Edit(int id)
        {
            var formapago= _formaPagoAppService.BuscarporId(id);
            var formapagoviewmodel = Mapper.Map<FormaPago, FormaPagoViewModel>(formapago);

            return View(formapagoviewmodel);
        }

        // POST: FormaPago/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaPagoViewModel formapago)
        {
            if (ModelState.IsValid)
            {
                var formapagoDominio = Mapper.Map<FormaPagoViewModel, FormaPago>(formapago);
                _formaPagoAppService.Actualizar(formapagoDominio);

                return RedirectToAction("Index");
            }

            return View(formapago);
        }

        // GET: FormaPago/Delete/5
        public ActionResult Delete(int id)
        {
            var formapago = _formaPagoAppService.BuscarporId(id);
            var formapagoviewmodel = Mapper.Map<FormaPago, FormaPagoViewModel>(formapago);

            return View(formapagoviewmodel);
        }

        // POST: FormaPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var formapago = _formaPagoAppService.BuscarporId(id);
            _formaPagoAppService.Eliminar(formapago);

            return RedirectToAction("Index");
        }
    }
}

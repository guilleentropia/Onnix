using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using ProyectoFinal.Aplicacion;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioAppService _usuarioAppService;
        private readonly EmpleadoAppService  _empleadoAppService;
        private readonly EmpresaAppService _empresaAppService;

        public HomeController(UsuarioAppService usuarioAppService, EmpleadoAppService empleadoAppService, EmpresaAppService empresaAppService)
        {
            _usuarioAppService = usuarioAppService;
            _empleadoAppService = empleadoAppService;
            _empresaAppService = empresaAppService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanJuan()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Mendoza()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            ViewBag.EmpleadoId = new SelectList(_empleadoAppService.ObtenerTodo(), "Id", "Nombre");
            ViewBag.EmpresaId = new SelectList(_empresaAppService.ObtenerTodo(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nombreusuario, string password, int empresaid)
        {
            if (ModelState.IsValid)
            {
                var user = _usuarioAppService.BuscarUsuario(nombreusuario, password, empresaid);

                if (user != null)
                {

                   return  RedirectToAction("Index");
                }
                else
                {
                    
                     ModelState.AddModelError("", "Usuario o contraseña erroneos");
                    
                }
                return RedirectToAction("Login");
            }

            else
            {
                return RedirectToAction("Login");
            }


        }


        public ActionResult ReportViewer()
        {


            return View("Report");
        }



    }
}
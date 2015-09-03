using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;
using System;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace ProyectoFinal.MVC5.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoAppService _productoAppService;
        private readonly IMarcaAppService _marcaAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ITerceroAppService _terceroAppService;

        public ProductoController(IProductoAppService productoAppService, IMarcaAppService marcaAppService,
            ICategoriaAppService categoriaAppService, ITerceroAppService terceroAppService)
        {
            _productoAppService = productoAppService;
            _marcaAppService = marcaAppService;
            _categoriaAppService = categoriaAppService;
            _terceroAppService = terceroAppService;
        }


        // GET: Producto
        public ActionResult Index()
        {
            var productoViewModel = Mapper.Map<IEnumerable<Producto>,
                IEnumerable<ProductoViewModel>>(_productoAppService.ObtenerTodo());
            return View("Index",null,productoViewModel);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            var producto = _productoAppService.BuscarporId(id);
            var productoviewmodel = Mapper.Map<Producto, ProductoViewModel>(producto);

            return View(productoviewmodel);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido");

            
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {

                            // Guardo la foto en un espacio fisico primero en la carpeta /Images
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images" + fileName));
                            file.SaveAs(path);

                            using (var binaryReader = new BinaryReader(file.InputStream))
                            {
                                byte[] array = binaryReader.ReadBytes(file.ContentLength);

                                var foto = Mapper.Map(array, producto.Imagen);
                                // Aqui mapeo la foto
                                var productoDominio = Mapper.Map<ProductoViewModel, Producto>(producto);
                                productoDominio.Imagen = foto;

                                //Se agrega la foto a la BD
                                _productoAppService.Agregar(productoDominio);
                            }



                            return RedirectToAction("Index");

                        }


                        //Mapeo el viewmodel "productoSinimagen" a una entidad
                        var productoSinimagen = Mapper.Map<ProductoViewModel, Producto>(producto);
                        // Actualizo la entidad 
                        _productoAppService.Agregar(productoSinimagen);

                        return RedirectToAction("Index");

                    }
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
               
                
            }


            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion", producto.MarcaId);
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion", producto.CategoriaId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", producto.TerceroId);
            return View(producto);
        }


        public FileContentResult getImg(int id)
        {
            byte[] byteArray = _productoAppService.BuscarporId(id).Imagen;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpeg")
                : null;
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = _productoAppService.BuscarporId(id);
            var productoviewmodel = Mapper.Map<Producto, ProductoViewModel>(producto);

            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion", productoviewmodel.MarcaId);
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion", productoviewmodel.CategoriaId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", productoviewmodel.TerceroId);

            return View("Edit","_OtroLayout",productoviewmodel);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Verifico si hay algun request
                if (Request.Files.Count > 0)
                {   
                    //obtengo el valor del Input del file de la vista
                    var file = Request.Files[0];
                    //Si esta vacio o es igual a 0 quiere decir que no se paso una imagen
                    if (file != null && file.ContentLength > 0)
                    {

                        // guardo la imagen en un la carpeta "Images" para luego llevarlo a la BD
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images" + fileName));
                        file.SaveAs(path);
                        // Realizo la conversion de datos
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            byte[] array = binaryReader.ReadBytes(file.ContentLength);
                            // mapeo la foto convertida a bytes, hacia el viewmodel
                            var foto = Mapper.Map(array, producto.Imagen);
                            //mapeo el viewmodel como una entidad
                            var productoDominio = Mapper.Map<ProductoViewModel, Producto>(producto);
                            //agrego la foto en bytes a la entidad
                            productoDominio.Imagen = foto;
                            //actualizo la entidad en la BD
                            _productoAppService.Actualizar(productoDominio);
                        }
                    }

                    else
                    {
                        // Obtengo el Id de la imagen que estoy por Actualizar
                        var pasoid = producto.Id;
                        // Obtengo los datos de la imagen que estoy por actualizar con el Id 
                        var pasofoto = _productoAppService.BuscarProductoImagen(pasoid);
                        //Convierto la Entidad a un viewmodel
                        var viewmodel = Mapper.Map<Producto, ProductoViewModel>(pasofoto);
                        //Modifico la propiedad imagen del viewmodel al nuevo viewmodel creado
                        producto.Imagen = viewmodel.Imagen;
                        //Mapeo el viewmodel "producto" a una entidad
                        var productoDominio = Mapper.Map<ProductoViewModel, Producto>(producto);
                        // Actualizo la entidad 
                        _productoAppService.Actualizar(productoDominio);
                    }
                    
                    return RedirectToAction("Index");
                    
                }
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

                
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion", producto.MarcaId);
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion", producto.CategoriaId);
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido", producto.TerceroId);


            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = _productoAppService.BuscarporId(id);
            var productoviewmodel = Mapper.Map<Producto, ProductoViewModel>(producto);

            return View(productoviewmodel);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var producto = _productoAppService.BuscarporId(id);
            _productoAppService.Eliminar(producto);

            return RedirectToAction("Index");
        }


        public JsonResult ObtenerMarca()
        {

            return Json(_marcaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult ObtenerCategoria()
        {

            return Json(_categoriaAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerTercero()
        {

            return Json(_terceroAppService.ObtenerTodo(), JsonRequestBehavior.AllowGet);
        }


        public byte[] ConvertirBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;

        }



        public ActionResult Busqueda()
        {
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion","Seleccione un valor");
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido");
            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion");
            
            return View();
        }

        [HttpGet]
        public ActionResult Lista(int id, string marca, string descripcion, int stock, int precio)
        {
           ProductoViewModel prodview = new ProductoViewModel();
           List<ProductoViewModel> prod = new List<ProductoViewModel>();
           prodview.Id = id;
            prodview.Descripcion= descripcion;
           // rod.MarcaProducto.Descripcion = descripcion;
            prodview.Stock = stock;
            prodview.PrecioVenta = precio;
            prod.Add(prodview);

            return View(prod);
        }
      
        

        [HttpPost]
        public ActionResult Lista()
        {


          

            return View();

    }


        
        public ActionResult Venta()
        {


            return View();

        }




        [HttpPost]
        public ActionResult Busqueda([DataSourceRequest]DataSourceRequest request, string descripcion, int terceroid, int categoriaid, int marcaid)
        {
            ViewBag.CategoriaId = new SelectList(_categoriaAppService.ObtenerTodo(), "Id", "Descripcion");
            ViewBag.TerceroId = new SelectList(_terceroAppService.ObtenerTodo(), "Id", "Apellido");
            ViewBag.MarcaId = new SelectList(_marcaAppService.ObtenerTodo(), "Id", "Descripcion");
            
            try {
                if (descripcion == "")
                {


                    var prodViewModel = Mapper.Map<IEnumerable<Producto>,
                  IEnumerable<ProductoViewModel>>(_productoAppService.BuscarProducto(terceroid, categoriaid, marcaid));

                    DataSourceResult result = prodViewModel.ToDataSourceResult(request, p=> 
                        new ProductoViewModel {
                    Id = p.Id,
                    Descripcion =  p.Descripcion,
                    Stock =  p.Stock
                    }); 

                    return View(prodViewModel);
                }

                else
                {
                    var prodViewModel = Mapper.Map<IEnumerable<Producto>,
                  IEnumerable<ProductoViewModel>>(_productoAppService.BuscarProducto(descripcion, terceroid, categoriaid, marcaid));

                    DataSourceResult result = prodViewModel.ToDataSourceResult(request, p =>
                       new ProductoViewModel
                       {
                           Id = p.Id,
                           Descripcion = p.Descripcion,
                           Stock = p.Stock
                       });

                    return View(prodViewModel);
                }
            
            }

            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.MVC5.ViewModels;
using ProyectoFinal.Aplicacion.Interface;

namespace ProyectoFinal.MVC5.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductoAppService _productoAppService;

        public CartController(IProductoAppService productoAppService)
        {
            _productoAppService= productoAppService;
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            
                if (cart[i].producto.Id.Equals(id))
                    return i;
                return -1;
            
        }


        public ActionResult Carrito()
        {

            ViewBag.Lista = (List<Item>)Session["cart"];
            return View("Lista");
        }


        public ActionResult Buy(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item{producto= _productoAppService.BuscarporId(id), Cantidad=1});
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)

                    cart[index].Cantidad++;
                else
                    cart.Add(new Item { producto = _productoAppService.BuscarporId(id), Cantidad = 1 });
                Session["cart"] = cart;
                
            }

            ViewBag.Lista = (List<Item>)Session["cart"];
            return View("Lista");
        }


        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            ViewBag.Lista = (List<Item>)Session["cart"];
            return View("Lista");

        }

    }
}
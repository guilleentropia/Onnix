using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal.Dominio.Entidades;
namespace ProyectoFinal.MVC5.ViewModels
{
    public class Item
    {
        public Producto producto { get; set; }
        public int Cantidad { get; set; }
    }
}
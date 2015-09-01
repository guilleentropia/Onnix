using System;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class FacturaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un numero de factura")]
        [Display(Name = "Numero de Factura")]
        public int NumeroFactura { get; set; }


        [DataType(DataType.Date,ErrorMessage = "Debe ingresar una fecha valida")]
        [Display(Name = "Fecha de Factura")]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "El campo Total es Obligatorio")]
        [Display(Name = "Total de Factura")]
        [DataType(DataType.Currency, ErrorMessage = "Debe ingresar un monto valido")]
        public decimal Total { get; set; }




        public int UsuarioId { get; set; }
        public virtual Usuario UsuarioFactura { get; set; }

        public int TerceroId { get; set; }
        public virtual Tercero TerceroFactura { get; set; }
    }
}
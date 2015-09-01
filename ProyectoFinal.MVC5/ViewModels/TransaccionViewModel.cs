using System;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class TransaccionViewModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha valida")]
        [Display(Name = "Fecha de Transaccion")]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "El campo Total es Obligatorio")]
        [Display(Name = "Total de Transaccion")]
        [DataType(DataType.Currency, ErrorMessage = "Debe ingresar un monto valido")]
        public decimal Total { get; set; }




        public int UsuarioId { get; set; }
        public virtual Usuario UsuarioTransaccion { get; set; }

        public int TerceroId { get; set; }
        public virtual Tercero TerceroTransaccion { get; set; }

        public int FacturaId { get; set; }
        public virtual Factura FacturaTransaccion { get; set; }

        public int TipoTransaccionId { get; set; }
        public virtual TipoTransaccion TipoTransacciones { get; set; }

        public int FormaPagoId { get; set; }
        public virtual FormaPago FormaPagoTransaccion { get; set; }


    }
}
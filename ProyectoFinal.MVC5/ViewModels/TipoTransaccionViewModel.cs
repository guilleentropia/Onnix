using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class TipoTransaccionViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Transaccion es obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Tipo de Transaccion")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres..."),
        Display(Name = "Tipo de Transaccion")]
        public string Descripcion { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class EmpresaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Empresa es obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para la Empresa")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres..."),
        Display(Name = "Empresa")]
        public string Descripcion { get; set; }
    }
}
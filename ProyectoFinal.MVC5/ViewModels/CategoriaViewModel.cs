using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Categoria es obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para la Categoria")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres..."),
        Display(Name = "Categoria")]
        public string Descripcion { get; set; }
    }
}
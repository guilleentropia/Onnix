using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class PerfilViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Perfil es obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Perfil")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres..."),
        Display(Name = "Perfil")]
        public string Descripcion { get; set; }
    }
}
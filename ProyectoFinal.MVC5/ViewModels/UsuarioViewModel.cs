using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Usuario es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Nombre de Usuario")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres...")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }


        [Required(ErrorMessage = "El campo Contraseña es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para la Contraseña")]
        [MinLength(6, ErrorMessage = "Debe ingresar un valor valido, minimo 6 caracteres...")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }



        
        public int PerfilId { get; set; }
        public virtual Perfil PerfilUsuario { get; set; }

        public int EmpleadoId { get; set; }
        public virtual Empleado EmpleadoUsuario { get; set; }

        public int EmpresaId { get; set; }
        public virtual Empresa EmpresaUsuario { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class EmpleadoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Apellido es Obligatorio")]
        [MaxLength(150, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Apellido")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres...")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
        [MaxLength(150, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Nombre")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres...")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Dni es Obligatorio")]
        [Range(1, 45000000, ErrorMessage = "El Dni ingresado no es valido")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El campo Domicilio es Obligatorio")]
        [MaxLength(150, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Domicilio")]
        [MinLength(5, ErrorMessage = "Debe ingresar un valor valido, minimo 5 caracteres...")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "El campo Celular es Obligatorio")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "El campo mail es Obligatorio")]
        [MaxLength(150, ErrorMessage = "Ha alcanzado el maximo de caracteres para el mail")]
        [EmailAddress(ErrorMessage = " Ingrese una cuenta de mail valida")]
        public string Mail { get; set; }


        public int EmpresaId { get; set; }
        public virtual Empresa EmpresaEmpleado { get; set; }
    }
}
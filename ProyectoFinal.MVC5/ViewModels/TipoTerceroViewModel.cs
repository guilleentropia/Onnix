using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class TipoTerceroViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " El Campo Tipo de Tercero es Obligatorio")]
        [MaxLength(150, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Tipo de Tercero")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres...")]
        [Display(Name="Tipo de Tercero")]
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual IEnumerable<TerceroViewModel> Terceros { get; set; }
    }
}
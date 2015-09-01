using System.Collections.Generic;

namespace ProyectoFinal.Dominio.Entidades
{
    public class TipoTercero
    {
        // Declaracion de la Entidad Tipo de Tercero para separar a un Cliente o Proveedor
        public int Id { get; set; }

        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual IEnumerable<Tercero> Terceros { get; set; }
        
        

        
    }
}

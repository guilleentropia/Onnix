namespace ProyectoFinal.Dominio.Entidades
{
    public class Tercero
    {
        // Declaracion de la Entidad Tercero que se refiere a un Cliente o Proveedor
        public int Id {get;set;}
       
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Domicilio { get; set; }
        public int Celular { get; set; }
        public string Mail { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Apellido + " " + Nombre;
            }
        }
        
        //Propiedades de Navegacion
        public int TipoTerceroId { get; set; }
        public virtual TipoTercero TipoTerceros { get; set; }




    }
}

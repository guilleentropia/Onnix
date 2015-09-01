namespace ProyectoFinal.Dominio.Entidades
{
    public class Empleado
    {
        // Declaracion de la Entidad Empleado 
        public int Id { get; set; }

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
        public int EmpresaId { get; set; }
        public virtual Empresa EmpresaEmpleado { get; set; }
    }
}

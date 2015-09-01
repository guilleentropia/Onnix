namespace ProyectoFinal.Dominio.Entidades
{
    public class Usuario
    {
        // Declaracion de la Entidad Usuario
        public int Id { get; set; }

        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        


        //Propiedades de Navegacion
        public int PerfilId { get; set; }
        public virtual Perfil PerfilUsuario { get; set; }

        public int EmpleadoId { get; set; }
        public virtual Empleado EmpleadoUsuario { get; set;}

        public int EmpresaId { get; set; }
        public virtual Empresa EmpresaUsuario { get; set; }

    }
}

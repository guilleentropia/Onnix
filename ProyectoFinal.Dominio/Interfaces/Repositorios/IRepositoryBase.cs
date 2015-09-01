using System.Collections.Generic;

namespace ProyectoFinal.Dominio.Interfaces.Repositorios
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // En esta interfaz, declaramos los metodos comunes a todas las entidades
        
        //Metodo para Insertar una Entidad
        void Agregar(TEntity obj);
        
        //Metodo para buscar por Id
        TEntity BuscarporId(int id);
        
        //Metodo para Obtener todos por Entidad
        IEnumerable<TEntity> ObtenerTodo();
        
        //Metodo para Actualizar una entidad
        void Actualizar(TEntity obj);
        
        //Metodo para Eliminar una entidad
        void Eliminar(TEntity obj);
        
        //Metodo para cerrar conexiones
        void Dispose();


    }
}

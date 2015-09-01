using System;
using System.Collections.Generic;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class ServiceBase<TEntity>: IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;
        
        // Aqui aplico Inyeccion de Dependencia
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }


        public void Agregar(TEntity obj)
        {
           _repository.Agregar(obj);
        }

        public TEntity BuscarporId(int id)
        {
          return  _repository.BuscarporId(id);
        }

        public IEnumerable<TEntity> ObtenerTodo()
        {
           return _repository.ObtenerTodo();
        }

        public void Actualizar(TEntity obj)
        {
            _repository.Actualizar(obj);
        }

        public void Eliminar(TEntity obj)
        {
            _repository.Eliminar(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}

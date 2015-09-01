using System;
using System.Collections.Generic;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class AppServiceBase<TEntity> : IDisposable,IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        // Nuevamente realizo inyeccion de dependencia
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }


        public void Agregar(TEntity obj)
        {
           _serviceBase.Agregar(obj);
        }

        public TEntity BuscarporId(int id)
        {
            return _serviceBase.BuscarporId(id);
        }

        public IEnumerable<TEntity> ObtenerTodo()
        {
            return _serviceBase.ObtenerTodo();
        }

        public void Actualizar(TEntity obj)
        {
           _serviceBase.Actualizar(obj);
        }

        public void Eliminar(TEntity obj)
        {
            _serviceBase.Eliminar(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}

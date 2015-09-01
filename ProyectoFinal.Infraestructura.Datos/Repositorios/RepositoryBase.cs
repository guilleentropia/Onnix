using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Contexto;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class RepositoryBase<TEntity> : IDisposable , IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProyectoFinalContexto Context = new ProyectoFinalContexto();

        
        public void Agregar(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();

        }

        public TEntity BuscarporId(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObtenerTodo()
        {
            return  Context.Set<TEntity>().ToList();
        }

        public void Actualizar(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Eliminar(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
            Context.SaveChanges();
            
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

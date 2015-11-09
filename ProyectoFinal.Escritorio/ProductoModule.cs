

using Ninject.Modules;
using ProyectoFinal.Aplicacion;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;
using ProyectoFinal.Dominio.Servicios;
using ProyectoFinal.Infraestructura.Datos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoFinal.Escritorio
{
    public class ProductoModule : NinjectModule
    {
        public override void Load()
        {
           Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IProductoAppService>().To<ProductoAppService>();
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
            Bind<IMarcaAppService>().To<MarcaAppService>();
            Bind<ITerceroAppService>().To<TerceroAppService>();
            Bind<IEmpresaAppService>().To<EmpresaAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();


            
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IProductoService>().To<ProductoService>();
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<IMarcaService>().To<MarcaService>();
            Bind<ITerceroService>().To<TerceroService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            
            
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IProductoRepository>().To<ProductoRepository>();
            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind<IMarcaRepository>().To<MarcaRepository>();
            Bind<ITerceroRepository>().To<TerceroRepository>();
            Bind<IEmpresaRepository>().To<EmpresaRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
        }

        
    }
}

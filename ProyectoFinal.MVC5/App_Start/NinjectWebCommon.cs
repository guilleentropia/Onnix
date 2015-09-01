using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ProyectoFinal.Aplicacion;
using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;
using ProyectoFinal.Dominio.Servicios;
using ProyectoFinal.Infraestructura.Datos.Repositorios;
using ProyectoFinal.MVC5.App_Start;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ProyectoFinal.MVC5.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));
            kernel.Bind<ITerceroAppService>().To<TerceroAppService>();
            kernel.Bind<ITipoTerceroAppService>().To<TipoTerceroAppService>();
            kernel.Bind<ICategoriaAppService>().To<CategoriaAppService>();
            kernel.Bind<IMarcaAppService>().To<MarcaAppService>();
            kernel.Bind<IFormaPagoAppService>().To<FormaPagoAppService>();
            kernel.Bind<IEmpresaAppService>().To<EmpresaAppService>();
            kernel.Bind<ITipoTransaccionAppService>().To<TipoTransaccionAppService>();
            kernel.Bind<IPerfilAppService>().To<PerfilAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IEmpleadoAppService>().To<EmpleadoAppService>();
            kernel.Bind<IProductoAppService>().To<ProductoAppService>();
            kernel.Bind<IFacturaAppService>().To<FacturaAppService>();
            kernel.Bind<ITransaccionAppService>().To<TransaccionAppService>();
            kernel.Bind<IDetalleTransaccionAppService>().To<DetalleTransaccionAppService>();
            kernel.Bind<IDetalleFacturaAppService>().To<DetalleFacturaAppService>();






            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ITerceroService>().To<TerceroService>();
            kernel.Bind<ITipoTerceroService>().To<TipoTerceroService>();
            kernel.Bind<ICategoriaService>().To<CategoriaService>();
            kernel.Bind<IMarcaService>().To<MarcaService>();
            kernel.Bind<IFormaPagoService>().To<FormaPagoService>();
            kernel.Bind<IEmpresaService>().To<EmpresaService>();
            kernel.Bind<ITipoTransaccionService>().To<TipoTransaccionService>();
            kernel.Bind<IPerfilService>().To<PerfilService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IEmpleadoService>().To<EmpleadoService>();
            kernel.Bind<IProductoService>().To<ProductoService>();
            kernel.Bind<IFacturaService>().To<FacturaService>();
            kernel.Bind<ITransaccionService>().To<TransaccionService>();
            kernel.Bind<IDetalleTransaccionService>().To<DetalleTransaccionService>();
            kernel.Bind<IDetalleFacturaService>().To<DetalleFacturaService>();




            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ITerceroRepository>().To<TerceroRepository>();
            kernel.Bind<ITipoTerceroRepository>().To<TipoTerceroRepository>();
            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();
            kernel.Bind<IMarcaRepository>().To<MarcaRepository>();
            kernel.Bind<IFormaPagoRepository>().To<FormaPagoRepository>();
            kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>();
            kernel.Bind<ITipoTransaccionRepository>().To<TipoTransaccionRepository>();
            kernel.Bind<IPerfilRepository>().To<PerfilRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<IProductoRepository>().To<ProductoRepository>();
            kernel.Bind<IFacturaRepository>().To<FacturaRepository>();
            kernel.Bind<ITransaccionRepository>().To<TransaccionRepository>();
            kernel.Bind<IDetalleTransaccionRepository>().To<DetalleTransaccionRepository>();
            kernel.Bind<IDetalleFacturaRepository>().To<DetalleFacturaRepository>();

        }        
    }
}

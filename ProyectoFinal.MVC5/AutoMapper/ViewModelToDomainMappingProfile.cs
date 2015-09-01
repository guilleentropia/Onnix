using AutoMapper;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }

        }

        protected override void Configure()
        {
            Mapper.CreateMap<Tercero,TerceroViewModel>();
            Mapper.CreateMap<TipoTercero,TipoTerceroViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<Marca, MarcaViewModel>();
            Mapper.CreateMap<FormaPago, FormaPagoViewModel>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<TipoTransaccion, TipoTransaccionViewModel>();
            Mapper.CreateMap<Perfil, PerfilViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Empleado, EmpleadoViewModel>();
            Mapper.CreateMap<Producto, ProductoViewModel>();
            Mapper.CreateMap<Factura, FacturaViewModel>();
            Mapper.CreateMap<Transaccion, TransaccionViewModel>();
            Mapper.CreateMap<DetalleTransaccion, DetalleTransaccionViewModel>();
            Mapper.CreateMap<DetalleFactura, DetalleFacturaViewModel>();

        }
    }
}
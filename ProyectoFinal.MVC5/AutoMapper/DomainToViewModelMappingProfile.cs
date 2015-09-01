using AutoMapper;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.MVC5.ViewModels;

namespace ProyectoFinal.MVC5.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {

        public override string ProfileName
        {
            get{ return "ViewModelToDomainMappings";}
       
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TerceroViewModel,Tercero>();
            Mapper.CreateMap<TipoTerceroViewModel,TipoTercero>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
            Mapper.CreateMap<MarcaViewModel, Marca>();
            Mapper.CreateMap<FormaPagoViewModel, FormaPago>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<TipoTransaccionViewModel, TipoTransaccion>();
            Mapper.CreateMap<PerfilViewModel, Perfil>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<EmpleadoViewModel, Empleado>();
            Mapper.CreateMap<ProductoViewModel, Producto>();
            Mapper.CreateMap<FacturaViewModel, Factura>();
            Mapper.CreateMap<TransaccionViewModel, Transaccion>();
            Mapper.CreateMap<DetalleTransaccionViewModel, DetalleTransaccion>();
            Mapper.CreateMap<DetalleFacturaViewModel, DetalleFactura>();
        }
    }
}
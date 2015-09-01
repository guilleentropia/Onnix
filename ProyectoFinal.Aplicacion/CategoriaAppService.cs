using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class CategoriaAppService: AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
            :base(categoriaService)
        {
            _categoriaService = categoriaService;
        }
    }
}

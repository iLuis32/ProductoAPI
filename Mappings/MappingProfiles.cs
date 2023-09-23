using AutoMapper;
using ProductoAPI.DTOs;
using ProductoAPI.Entities;

namespace ProductoAPI.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            //Entidad -> DTO
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<Producto, GuardarProducto>();
            CreateMap<Usuario, UsuarioDTO>();

            //DTO -> Entidad
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<GuardarProducto, Producto>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}

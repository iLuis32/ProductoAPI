using ProductoAPI.DTOs;

namespace ProductoAPI.Repositories.Interfaces
{
    public interface IProducto
    {
        Task<int> Crear(GuardarProducto producto);
        Task<ICollection<ProductoDTO>> Productos();
        Task<ProductoDTO> Producto(int id);
        Task<int> Modificar(int id, ProductoDTO producto);
        Task<int> Eliminar(int id);
    }
}

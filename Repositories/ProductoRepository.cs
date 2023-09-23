using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductoAPI.Context;
using ProductoAPI.DTOs;
using ProductoAPI.Entities;
using ProductoAPI.Repositories.Interfaces;

namespace ProductoAPI.Repositories
{
    public class ProductoRepository : IProducto
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Crear(GuardarProducto producto)
        {
            var entidad = _mapper.Map<GuardarProducto, Producto>(producto);
            await _db.Productos.AddAsync(entidad);

            return await _db.SaveChangesAsync();
        }

        public Task<int> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Modificar(int id, ProductoDTO producto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDTO> Producto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductoDTO>> Productos()
        {
            var entidades = await _db.Productos
                .Include(x=>x.Categoria)
                .ToListAsync();
            var productos = _mapper
                .Map<ICollection<Producto>, ICollection<ProductoDTO>>(entidades);
            return productos;
        }
    }
}

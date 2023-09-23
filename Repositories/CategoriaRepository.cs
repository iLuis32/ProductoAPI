using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductoAPI.Context;
using ProductoAPI.DTOs;
using ProductoAPI.Entities;
using ProductoAPI.Repositories.Interfaces;

namespace ProductoAPI.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoriaRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> Categoria(int id)
        {            
            var entidad = await _db.Categorias.FindAsync(id);
            var categoria = _mapper.Map<Categoria, CategoriaDTO>(entidad);

            return categoria;
        }

        public async Task<ICollection<CategoriaDTO>> Categorias()
        {
            var entidades = await _db.Categorias.ToListAsync();
            var categorias = _mapper.Map<ICollection<Categoria>, ICollection<CategoriaDTO>>(entidades);
            return categorias;
        }

        public async Task<int> Crear(CategoriaDTO categoria)
        {
            var xx = _mapper.Map<CategoriaDTO, Categoria>(categoria);
            await _db.Categorias.AddAsync(xx);

            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria == null)
                return 0;

            _db.Categorias.Remove(categoria);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, CategoriaDTO categoria)
        {
            var entidad = await _db.Categorias.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = categoria.Nombre;
            
            _db.Categorias.Update(entidad);
            return await Guardar();
        }
    }
}

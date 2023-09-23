using ProductoAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductoAPI.DTOs
{
    public class ProductoDTO
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; } 
        public int IdCategoria { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }


    public class GuardarProducto
    { 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; } 
    }

}

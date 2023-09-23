using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductoAPI.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        [ForeignKey(nameof(Categoria))]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}

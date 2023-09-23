using System.ComponentModel.DataAnnotations;

namespace ProductoAPI.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}

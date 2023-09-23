namespace ProductoAPI.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
    }
    public class UsuarioLogin
    { 
        public string NombreUsuario { get; set; }
        public string Clave { get; set; } 
    }
}

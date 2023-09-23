using ProductoAPI.DTOs;
using ProductoAPI.Repositories.Interfaces;

namespace ProductoAPI.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void Add(this WebApplication app) { 
            app.MapPost("api/login", async (UsuarioLogin usuario, IUsuario _usuario) => {
                
                var login = await _usuario.Login(usuario);

                if (login is null)
                    return Results.NotFound(new { message = "Usuario o contraseña incorrecto" });
                    // 400 Bad Request - La solicitud no se pudo
                    //procesar, debido a un error de formato
                var token = _usuario.GenerarToken(login);
                if (string.IsNullOrEmpty(token)) {
                    login.Clave = string.Empty;
                    return Results.Ok(token); //200 OK - La solicitud se realizó correctamente
                }
                else
                {
                    return Results.Unauthorized();
                }
            }).WithTags("Usuario");
        }
    }
}

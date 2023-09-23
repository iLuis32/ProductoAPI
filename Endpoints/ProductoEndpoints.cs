using ProductoAPI.DTOs;
using ProductoAPI.Repositories.Interfaces;

namespace ProductoAPI.Endpoints
{
    public static class ProductoEndpoints
    {
        public static void Add(this WebApplication app) {

            app.MapGet("api/productos", async (IProducto _producto) => {
                var productos = await _producto.Productos();
                //200 OK - La solicitud se realizó correctamente
                //y se devuelve una lista
                return Results.Ok(productos);
            });

            app.MapPost("api/producto", async (GuardarProducto producto, IProducto _producto) => {
                if (_producto == null)
                    return Results.BadRequest(); // 400 Bad Request - La solicitud no se pudo
                                                 //procesar, debido a un error de formato
                await _producto.Crear(producto);
                //201 Created - El recurso se creó con éxito, y se devuelve la ubicación del recurso creado
                return Results.Created("api/productos/{producto.Id}", producto);
            });

        }
    }
}

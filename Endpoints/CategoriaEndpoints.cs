using Microsoft.AspNetCore.Authorization;
using ProductoAPI.DTOs;
using ProductoAPI.Entities;
using ProductoAPI.Repositories.Interfaces;

namespace ProductoAPI.Endpoints
{
    public static class CategoriaEndpoints
    {
        public static void Add(this WebApplication app) {
            /// <summary>
            /// Obtiene una lista de todos los productos.
            /// </summary>
            /// <returns>Una lista de productos.</returns>
            app.MapGet("api/categorias", async (ICategoria _categoria) => {
                var categorias = await _categoria.Categorias();
                //200 OK - La solicitud se realizó correctamente
                //y se devuelve una lista
                return Results.Ok(categorias);
            }).WithTags("Categoria").AllowAnonymous();

            app.MapGet("api/categorias/{id}", async (int id, ICategoria _categoria) => {
                var categoria = await _categoria.Categoria(id);
                if(categoria == null)
                    return Results.NotFound(); //404 Not Found - El recurso solicitado no existe
                else
                    return Results.Ok(categoria); //200 OK - La solicitud se realizó correctamente
            }).WithTags("Categoria").AllowAnonymous();

            app.MapPost("api/categoria", [Authorize] async (CategoriaDTO categoria, ICategoria _categoria) => {
                if (categoria == null)
                    return Results.BadRequest(); // 400 Bad Request - La solicitud no se pudo
                                                 //procesar, debido a un error de formato
                await _categoria.Crear(categoria);
                //201 Created - El recurso se creó con éxito, y se devuelve la ubicación del recurso creado
                return Results.Created("api/categorias/{categoria.Id}", categoria);
            }).WithTags("Categoria");

            app.MapPut("api/categoria/{id}", async (int id, CategoriaDTO categoria, ICategoria _categoria) => {
                var resultado = await _categoria.Modificar(id, categoria);
                if(resultado == 0)
                    return Results.NotFound(); // 404 Not Found - El recurso solicitado no existe.
                else
                    return Results.Ok(resultado); //200 OK - La solicitud se realizó correctamente
            }).WithTags("Categoria").RequireAuthorization();

            app.MapDelete("api/categoria/{id}", async (int id, ICategoria _categoria) => {
                var resultado = await _categoria.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not Found - El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 No Content - Recurso eliminado.
            }).WithTags("Categoria").RequireAuthorization();

        }
    }
}

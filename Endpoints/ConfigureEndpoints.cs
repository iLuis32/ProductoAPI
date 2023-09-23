namespace ProductoAPI.Endpoints
{
    public static class ConfigureEndpoints
    {
        public static void UseEndpoints(this WebApplication app) {
            CategoriaEndpoints.Add(app); 
            ProductoEndpoints.Add(app);
            UsuarioEndpoints.Add(app);
        }
    }
}

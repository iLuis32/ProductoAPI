namespace ProductoAPI.Emails
{
    public interface ISender
    {
        string Enviar(string correo);
    }
}

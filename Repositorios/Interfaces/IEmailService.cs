namespace RunGym.Repositorios.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string contenido);
    }
}

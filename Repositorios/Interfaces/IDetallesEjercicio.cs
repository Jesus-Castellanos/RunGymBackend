using RunGym.Models;

namespace RunGym.Repositorios.Interfaces
{
    public interface IDetallesEjercicio
    {
        Task<List<DetallesEjercicio>> GetDetallesEjercicio();
        Task<bool> PostDetallesEjercicio(DetallesEjercicio detallesEjercicio);
        Task<bool> PutDetallesEjercicio(DetallesEjercicio detallesEjercicio);
        Task<bool> DeleteDetallesEjercicio(int id);
    }
}

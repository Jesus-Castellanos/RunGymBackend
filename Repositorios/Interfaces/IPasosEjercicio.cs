using RunGym.Models;

namespace RunGym.Repositorios.Interfaces
{
    public interface IPasosEjercicio
    {
        Task<List<Models.PasosEjercicio>> GetPasosEjercicio();
        Task<bool> PostPasosEjercicio(Models.PasosEjercicio pasosEjercicio);
        Task<bool> PutPasosEjercicio(Models.PasosEjercicio pasosEjercicio);
        Task<bool> DeletePasosEjercicio(int id);
    }
}

using RunGym.Models;
namespace RunGym.Repositorios.Interfaces
{
    public interface IRutinasEjercicios
    {
        Task<List<DetallesEjercicio>> GetRutinasEjercicio();

        Task<DetallesEjercicio> GetRutinasEjercicioById(int id);

        Task<DetallesEjercicio> GetRutinasEjercicioByName(string nombre);

        Task<bool> PostRutinasEjercicio(DetallesEjercicio rutinasEjercicio);

        Task<bool> PutRutinasEjercicio(DetallesEjercicio rutinasEjercicio);

        Task<bool> DeleteRutinasEjercicio(DetallesEjercicio rutinasEjercicio);
    }
}

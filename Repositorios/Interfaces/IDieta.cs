using RunGym.Models;
namespace RunGym.Repositorios.Interfaces
{
    public interface IDieta
    {
        Task<List<Dieta>> GetDieta();

        Task<Dieta> GetDietaById(int id);

        Task<Dieta> GetDietaByName(string nombre);

        Task<bool> PostDieta(Dieta dieta);

        Task<bool> PutDieta(Dieta dieta);

        Task<bool> DeleteDieta(Dieta dieta);
    }
}

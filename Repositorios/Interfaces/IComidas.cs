using RunGym.Models;

namespace RunGym.Repositorios.Interfaces
{
    public interface IComidas
    {
        Task<List<Comidas>> GetComidas();

        Task<Comidas> GetComidasById(int id);

        Task<Comidas> GetComidasByName(string nombre);

        Task<bool> PostComidas(Comidas comidas);

        Task<bool> PutComidas(Comidas comidas);

        Task<bool> DeleteComidas(Comidas comidas);
    }
}

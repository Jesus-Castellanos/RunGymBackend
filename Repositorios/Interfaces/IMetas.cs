using RunGym.Models;
namespace RunGym.Repositorios.Interfaces
{
    public interface IMetas
    {
        Task<List<Metas>> GetMetas();

        Task<Metas> GetMetasById(int id);

        Task<Metas> GetMetasByName(string nombre);

        Task<bool> PostMetas(Metas metas);

        Task<bool> PutMetas(Metas metas);

        Task<bool> DeleteMetas(Metas metas);

    }
}

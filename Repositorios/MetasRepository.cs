using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class MetasRepository : IMetas
    {
        private readonly RunGymContext context;

        public MetasRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Metas>> GetMetas()
        {
            var data = await context.Metas.ToListAsync();
            return data;
        }

        public async Task<Metas> GetMetasById(int id)
        {
            var data = await context.Metas.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Metas> GetMetasByName(string nombre)
        {
            var data = await context.Metas.Where(x => x.MetaPrincipal == nombre).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostMetas(Metas metas)
        {
            await context.Metas.AddAsync(metas);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutMetas(Metas metas)
        {
            context.Update(metas);
            await context.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteMetas(Metas metas)
        {
            context.Metas.Remove(metas);
            await context.SaveAsync();
            return true;
        }
    }
}

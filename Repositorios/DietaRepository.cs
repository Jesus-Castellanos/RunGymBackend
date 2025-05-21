using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class DietaRepository : IDieta
    {
        private readonly RunGymContext context;

        public DietaRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Dieta>> GetDieta()
        {
            var data = await context.Dieta.ToListAsync();
            return data;
        }

        public async Task<Dieta> GetDietaById(int id)
        {
            var data = await context.Dieta.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Dieta> GetDietaByName(string nombre)
        {
            var data = await context.Dieta.Where(x => x.TipoDieta == nombre).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostDieta(Dieta dieta)
        {
            await context.Dieta.AddAsync(dieta);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutDieta(Dieta dieta)
        {
            context.Update(dieta);
            await context.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteDieta(Dieta dieta)
        {
            context.Dieta.Remove(dieta);
            await context.SaveAsync();
            return true;
        }
    }
}

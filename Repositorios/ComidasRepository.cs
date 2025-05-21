using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class ComidasRepository : IComidas
    {
        private readonly RunGymContext context;

        public ComidasRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Comidas>> GetComidas()
        {
            var data = await context.Comidas.ToListAsync();
            return data;
        }

        public async Task<Comidas> GetComidasById(int id)
        {
            var data = await context.Comidas.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Comidas> GetComidasByName(string nombre)
        {
            var data = await context.Comidas.Where(x => x.TipoComida == nombre).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostComidas(Comidas comidas)
        {
            await context.Comidas.AddAsync(comidas);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutComidas(Comidas comidas)
        {
            context.Update(comidas);
            await context.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteComidas(Comidas comidas)
        {
            context.Comidas.Remove(comidas);
            await context.SaveAsync();
            return true;
        }
    }
}

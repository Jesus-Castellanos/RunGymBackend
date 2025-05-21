using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;
namespace RunGym.Repositorios
{
    public class PasosEjercicioRepository : IPasosEjercicio
    {
        public readonly RunGymContext context; // Usar 'context' en lugar de '_context'

        public PasosEjercicioRepository(RunGymContext context)
        {
            this.context = context; // Se inyecta el contexto en el constructor
        }

        public async Task<List<PasosEjercicio>> GetPasosEjercicio()
        {
            var data = await context.PasosEjercicios.ToListAsync(); // Usar 'context'
            return data;
        }

        public async Task<bool> PostPasosEjercicio(PasosEjercicio pasosEjercicio)
        {
            await context.PasosEjercicios.AddAsync(pasosEjercicio); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }

        public async Task<bool> PutPasosEjercicio(PasosEjercicio pasosEjercicio)
        {
            context.PasosEjercicios.Update(pasosEjercicio);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeletePasosEjercicio(int id)
        {
            var pasosEjercicio = await context.PasosEjercicios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (pasosEjercicio == null) return false; // Si no existe, devolver 'false'

            context.PasosEjercicios.Remove(pasosEjercicio); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}

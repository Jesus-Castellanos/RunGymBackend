using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;
namespace RunGym.Repositorios
{
    public class DetallesEjercicioRepository : IDetallesEjercicio
    {
        public readonly RunGymContext context; // Usar 'context' en lugar de '_context'

        public DetallesEjercicioRepository(RunGymContext context)
        {
            this.context = context; // Se inyecta el contexto en el constructor
        }

        public async Task<List<DetallesEjercicio>> GetDetallesEjercicio()
        {
            var data = await context.DetallesEjercicios.ToListAsync(); // Usar 'context'
            return data;
        }

        public async Task<bool> PostDetallesEjercicio(DetallesEjercicio detallesEjercicio)
        {
            await context.DetallesEjercicios.AddAsync(detallesEjercicio); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }

        public async Task<bool> PutDetallesEjercicio(DetallesEjercicio detallesEjercicio)
        {
            context.DetallesEjercicios.Update(detallesEjercicio);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteDetallesEjercicio(int id)
        {
            var detallesEjercicio = await context.DetallesEjercicios.FindAsync(id); // Usar 'context' en lugar de '_context'
            if (detallesEjercicio == null) return false; // Si no existe, devolver 'false'

            context.DetallesEjercicios.Remove(detallesEjercicio); // Usar 'context'
            await context.SaveChangesAsync(); // Corregir 'SaveAsync' por 'SaveChangesAsync'
            return true;
        }
    }
}

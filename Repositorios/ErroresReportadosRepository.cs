using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class ErroresReportadosRepository : IErroresReportados
    {
        private readonly RunGymContext context;

        public ErroresReportadosRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<ErroresReportados>> GetErroresReportados()
        {
            var data = await context.ErroresReportados.ToListAsync();
            return data;
        }
        public async Task<bool> PostErroresReportados(ErroresReportados erroresreportados)
        {
            await context.ErroresReportados.AddAsync(erroresreportados);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutErroresReportados(ErroresReportados erroresreportados)
        {
            context.ErroresReportados.Update(erroresreportados);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteErroresReportados(int id)
        {
            var ErroresReportados = await context.ErroresReportados.FindAsync(id);
            if (ErroresReportados == null)
            {
                return false;
            }

            context.ErroresReportados.Remove(ErroresReportados);
            await context.SaveChangesAsync();
            return true;
        }


    }
}

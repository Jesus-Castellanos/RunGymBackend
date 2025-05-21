using RunGym.Models;

namespace RunGym.Repositorios.Interfaces
{
    public interface IErroresReportados
    {
        Task<List<ErroresReportados>> GetErroresReportados();
        Task<bool> PostErroresReportados(ErroresReportados erroresreportados);
        Task<bool> PutErroresReportados(ErroresReportados erroresreportados);
        Task<bool> DeleteErroresReportados(int id);
    }
}

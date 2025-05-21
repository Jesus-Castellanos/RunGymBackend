using RunGym.Models;
using RunGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using RunGym.Run;

namespace RunGym.Repositorios
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly RunGymContext context;

        public UsuariosRepository(RunGymContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            var data = await context.Usuarios.ToListAsync();
            return data;
        }
        public async Task<bool> PostUsuarios(Usuarios usuarios)
        {
            await context.Usuarios.AddAsync(usuarios);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutUsuarios(Usuarios usuarios)
        {
            context.Usuarios.Update(usuarios);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUsuarios(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }
        // Obtener un usuario por correo
        public async Task<Usuarios> GetUsuarioByCorreoAsync(string correo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }

        // Obtener un usuario por el Codigo de Verificacion recuperación
        public async Task<Usuarios> GetUsuarioByCodigoAsync(string codigo)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.CodigoVerificacion == codigo);
        }

        // Actualizar un usuario
        public async Task<bool> UpdateUsuarioAsync(Usuarios usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RunGym.Models;

namespace RunGym.Repositorios
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions options) : base(options)
        {}
            public DbSet<Usuarios> Usuarios { get; set; }
            public DbSet<DetallesEjercicio> DetallesEjercicios { get; set; }
            public DbSet<Metas> metas { get; set; }
            public DbSet<Ejercicios> ejercicios { get; set; }
            public DbSet<Dieta> dieta { get; set; }
            public DbSet<Comidas> comidas { get; set; }
            public DbSet<ErroresReportados> ErroresReportados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuarios>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Usuarios>().Property(u => u.Apellido).HasColumnName("Apellido");
            modelBuilder.Entity<Usuarios>().Property(u => u.TipoDocumento).HasColumnName("TipoDocumento");
            modelBuilder.Entity<Usuarios>().Property(u => u.Documento).HasColumnName("Documento");
            modelBuilder.Entity<Usuarios>().Property(u => u.Correo).HasColumnName("Correo");
            modelBuilder.Entity<Usuarios>().Property(u => u.Contraseña).HasColumnName("Contraseña");
            modelBuilder.Entity<Usuarios>().Property(u => u.Celular).HasColumnName("Celular");
            modelBuilder.Entity<Usuarios>().Property(u => u.Genero).HasColumnName("Genero");
            modelBuilder.Entity<Usuarios>().Property(u => u.FechaNacimiento).HasColumnName("FechaNacimiento");
            modelBuilder.Entity<Usuarios>().Property(u => u.Peso).HasColumnName("Peso");
            modelBuilder.Entity<Usuarios>().Property(u => u.Altura).HasColumnName("Altura");
            modelBuilder.Entity<Usuarios>().Property(u => u.HorasSueno).HasColumnName("HorasSueno");
            modelBuilder.Entity<Usuarios>().Property(u => u.ConsumoAgua).HasColumnName("ConsumoAgua");

            modelBuilder.Entity<Usuarios>().Property(u => u.CodigoVerificacion).HasColumnName("CodigoVerificacion");
            modelBuilder.Entity<Usuarios>().Property(u => u.CodigoExpira).HasColumnName("CodigoExpira");

            modelBuilder.Entity<Metas>().ToTable("Metas");
            modelBuilder.Entity<Metas>().HasKey(u => u.Id);
            modelBuilder.Entity<Metas>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<Metas>().Property(u => u.MetaPrincipal).HasColumnName("MetaPrincipal");
            modelBuilder.Entity<Metas>().Property(u => u.CuerpoActual).HasColumnName("CuerpoActual");
            modelBuilder.Entity<Metas>().Property(u => u.CuerpoDeseado).HasColumnName("CuerpoDeseado");
            modelBuilder.Entity<Metas>().Property(u => u.Descripción).HasColumnName("Descripción");
            modelBuilder.Entity<Metas>().Property(u => u.FechaObjetivo).HasColumnName("FechaObjetivo");

            modelBuilder.Entity<DetallesEjercicio>().ToTable("DetallesEjercicio");
            modelBuilder.Entity<DetallesEjercicio>().HasKey(u => u.Id);
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.EjercicioId).HasColumnName("EjercicioId");
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.Repeticiones).HasColumnName("Repeticiones");
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.Descanso).HasColumnName("Descanso");
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.Cuidados).HasColumnName("Cuidados");
            modelBuilder.Entity<DetallesEjercicio>().Property(u => u.URLVideo).HasColumnName("URLVideo");

            modelBuilder.Entity<Ejercicios>().ToTable("Ejercicios");
            modelBuilder.Entity<Ejercicios>().HasKey(u => u.Id);
            modelBuilder.Entity<Ejercicios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Ejercicios>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Ejercicios>().Property(u => u.Categoria).HasColumnName("Categoria");
            modelBuilder.Entity<Ejercicios>().Property(u => u.ImagenURL).HasColumnName("ImagenURL");

            modelBuilder.Entity<PasosEjercicio>().ToTable("PasosEjercicio");
            modelBuilder.Entity<PasosEjercicio>().HasKey(u => u.Id);
            modelBuilder.Entity<PasosEjercicio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<PasosEjercicio>().Property(u => u.EjercicioId).HasColumnName("EjercicioId");
            modelBuilder.Entity<PasosEjercicio>().Property(u => u.NumeroPaso).HasColumnName("NumeroPaso");
            modelBuilder.Entity<PasosEjercicio>().Property(u => u.DescripcionPaso).HasColumnName("DescripcionPaso");

            modelBuilder.Entity<Dieta>().ToTable("Dieta");
            modelBuilder.Entity<Dieta>().HasKey(u => u.Id);
            modelBuilder.Entity<Dieta>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<Dieta>().Property(u => u.TipoDieta).HasColumnName("TipoDieta");
            modelBuilder.Entity<Dieta>().Property(u => u.FechaInicio).HasColumnName("FechaInicio");
            modelBuilder.Entity<Dieta>().Property(u => u.FechaFin).HasColumnName("FechaFin");
            modelBuilder.Entity<Dieta>().Property(u => u.CaloriasDiarias).HasColumnName("CaloriasDiarias");
            modelBuilder.Entity<Dieta>().Property(u => u.Micronutrientes).HasColumnName("Macronutrientes");
            modelBuilder.Entity<Dieta>().Property(u => u.Descripcion).HasColumnName("Descripcion");

            modelBuilder.Entity<Comidas>().ToTable("Comidas");
            modelBuilder.Entity<Comidas>().HasKey(u => u.Id);
            modelBuilder.Entity<Comidas>().Property(u => u.IdDieta).HasColumnName("IdDieta");
            modelBuilder.Entity<Comidas>().Property(u => u.TipoComida).HasColumnName("TipoComida");
            modelBuilder.Entity<Comidas>().Property(u => u.HoraComida).HasColumnName("HoraComida");
            modelBuilder.Entity<Comidas>().Property(u => u.Descripcion).HasColumnName("Descripcion");

            modelBuilder.Entity<ErroresReportados>().ToTable("ErroresReportados");
            modelBuilder.Entity<ErroresReportados>().HasKey(u => u.Id);
            modelBuilder.Entity<ErroresReportados>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<ErroresReportados>().Property(u => u.Correo).HasColumnName("Correo");
            modelBuilder.Entity<ErroresReportados>().Property(u => u.Celular).HasColumnName("Celular");
            modelBuilder.Entity<ErroresReportados>().Property(u => u.Asunto).HasColumnName("Asunto");
            modelBuilder.Entity<ErroresReportados>().Property(u => u.Mensaje).HasColumnName("Mensaje");
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}

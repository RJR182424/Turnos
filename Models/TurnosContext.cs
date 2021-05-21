using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {

        public TurnosContext(DbContextOptions<TurnosContext> opciones)
        : base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");

                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(p => p.IdPaciente);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellidos)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");
                entidad.HasKey(m => m.IdMedico);

                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                
                entidad.Property(p => p.Apellidos)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entidad.Property(p => p.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(p => p.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);

            });
        }
    }
}
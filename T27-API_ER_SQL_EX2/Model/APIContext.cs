using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX2.Model
{
    public class APIContext : DbContext
    {
        // IMPORTAMOS LAS OPCIONES DE DbContext
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // ATRIBUTOS, GETTERS Y SETTERS
        public virtual DbSet<Cientifico> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Asignado_A> Asignado_As { get; set; }

        //DEFINIMOS LOS MODELOS DE LA BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientifico>(cientifico =>
            {
                // NOMBRE TABLA
                cientifico.ToTable("Cientificos");

                // PROPIEDADES DE COLUMNAS
                cientifico.Property(e => e.DNI)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                cientifico.HasKey(e => e.DNI);

                cientifico.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(proyecto =>
            {
                // NOMBRE TABLA
                proyecto.ToTable("Proyecto");

                // PROPIEDADES DE COLUMNAS
                proyecto.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                proyecto.HasKey(e => e.Id);

                proyecto.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                proyecto.Property(e => e.Horas)
                    .HasColumnName("Horas");
            });

            modelBuilder.Entity<Asignado_A>(asignado_a =>
            {
                // NOMBRE TABLA
                asignado_a.ToTable("Asignado_a");

                // PROPIEDADES DE COLUMNAS
                asignado_a.Property(e => e.Cientifico)
                    .HasColumnName("Cientifico")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                asignado_a.HasKey(e => e.Cientifico);

                asignado_a.Property(e => e.Proyecto)
                    .HasColumnName("Proyecto")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                asignado_a.HasKey(e => e.Proyecto);

                // RELACIONES

                asignado_a.HasOne(k => k.Cientificos)
                    .WithMany(m => m.Asignado_As)
                    .HasForeignKey(f => f.Cientifico)
                    .HasConstraintName("Cientifico_fk");

                asignado_a.HasOne(k => k.Proyectos)
                    .WithMany(m => m.Asignado_As)
                    .HasForeignKey(f => f.Proyecto)
                    .HasConstraintName("Proyecto_fk");
            });
        }
    }
}

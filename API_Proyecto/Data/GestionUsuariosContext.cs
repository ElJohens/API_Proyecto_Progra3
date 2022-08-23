using System;
using System.Collections.Generic;
using API_Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Proyecto.Data
{
    public partial class GestionUsuariosContext : DbContext
    {
        public GestionUsuariosContext()
        {
        }

        public GestionUsuariosContext(DbContextOptions<GestionUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("GestionUsuariosContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("Password");

                entity.HasIndex(e => e.UserdId, "IX_Password_UserdId");

                entity.HasOne(d => d.Userd)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.UserdId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioAlias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioApellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCorreo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdentificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioRole>(entity =>
            {
                entity.ToTable("Usuario_Role");

                entity.Property(e => e.UsuarioRoleId).HasColumnName("Usuario_Role_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Role_Role");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Role_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

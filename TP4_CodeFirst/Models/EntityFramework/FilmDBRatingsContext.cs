using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

namespace TP4_CodeFirst.Models.EntityFramework
{
    public partial class FilmRatingsDBContext : DbContext
    {
        protected FilmRatingsDBContext()
        {
        }

        protected FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options) : base(options)
        {
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        builder.AddConsole());

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Notation> Notation { get; set; }

        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(MyLoggerFactory)
     .EnableSensitiveDataLogging()
     .UseNpgsql("Server=localhost;port=5432;Database=tp4; uid = postgres; password = postgres; ");

                //optionsBuilder.UseLazyLoadingProxies();
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => new { e.FilmId }).HasName("pk_flm");

                entity.HasOne(d => d.NotesFilm)
                    .WithMany(p => p.FilmNote)
                    .HasForeignKey(c => c.FilmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_flm_not");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.UtilisateurId).HasName("pk_utl");

                entity.HasOne(d => d.NotesUtilisateur)
                    .WithMany(p => p.UtilisateurNotant)
                    .HasForeignKey(c => c.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_utl_not");

                entity.Property(c => c.DateCreation).IsRequired(true);



            });

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => e.UtilisateurId).HasName("pk_notation_utilisateur");
                entity.HasKey(e => e.FilmId).HasName("pk_notation_film");


            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

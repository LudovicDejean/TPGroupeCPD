using Microsoft.EntityFrameworkCore;
using LibTP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibTP
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Etagere> Etageres { get; set; }
        public DbSet<PositionMagasin> positionMagasins { get; set; }
        public DbSet<Secteur> Secteurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ArticleEntity = modelBuilder.Entity<Article>();
            ArticleEntity.HasKey(a => a.Id);
            ArticleEntity.Property(a => a.Libelle).HasMaxLength(255).IsRequired();
            ArticleEntity.Property(a => a.SKU).HasMaxLength(255).IsRequired();
            ArticleEntity.Property(a => a.DateSortie).IsRequired();
            ArticleEntity.Property(a => a.PrixInitial).IsRequired();
            ArticleEntity.Property(a => a.Poids).IsRequired();

            ArticleEntity
                .HasMany(a => a.PositionMagasins)
                .WithOne(a => a.Article)
                .HasForeignKey(a => a.IdArticle);

            var EtagereEntity = modelBuilder.Entity<Etagere>();
            EtagereEntity.HasKey(e => e.Id);
            EtagereEntity.Property(e => e.PoidsMaximum).IsRequired();

            EtagereEntity
                .HasMany(e => e.PositionMagasins)
                .WithOne(e => e.Etagere)
                .HasForeignKey(e => e.IdEtagere);

            var PositionMagasinEntity = modelBuilder.Entity<PositionMagasin>();

            PositionMagasinEntity.HasKey(s => new { s.IdEtagere, s.IdArticle });

            var SecteurEntity = modelBuilder.Entity<Secteur>();
            SecteurEntity.HasKey(s => s.Id);

            SecteurEntity
                .HasMany(s => s.Etageres)
                .WithOne(e => e.Secteur)
                .HasForeignKey(e => e.IdSecteur);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // définition de la base de données à utiliser ainsi que de la chaine de connexion
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS01; Database = libTest; Trusted_Connection = True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
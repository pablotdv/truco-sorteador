﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrucoData
{
    public class TrucoContext : DbContext
    {
        public TrucoContext(DbContextOptions<TrucoContext> options) : base(options)
        {
            
        }

        public DbSet<Trio> Trios { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Jogo>()
                .HasIndex(j => new { j.TrioAId, j.TrioBId });
        }
    }

    [Table("Trios")]
    public class Trio
    {
        [Key]
        public Guid TrioId { get; set; }
        public int Ordem { get; set; }
        public string Nome { get; set; }
        public string Entidade { get; set; }
        public bool Sortear { get; set; }
    }

    [Table("Jogos")]
    public class Jogo
    {
        [Key]
        public Guid JogoId { get; set; }
        public int Etapa { get; set; }
        public int Numero { get; set; }
        public int Rodada { get; set; }
        public Guid TrioAId { get; set; }
        public Trio TrioA { get; set; }        
        public Guid? TrioBId { get; set; }
        public Trio TrioB { get; set; }
    }


}

﻿using EscarGoLibrary.Models;
using System.Data.Entity;

namespace EscarGoLibrary.Repositories
{
    public sealed class EscarGoContext : DbContext
    {
        public EscarGoContext() :base("name=DefaultConnection") 
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Concurrent> Concurrents { get; set; }
        public DbSet<Pari> Paris { get; set; }
        public DbSet<Entraineur> Entraineurs { get; set; }
        public DbSet<Visiteur> Visiteurs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
               .HasMany(s => s.Concurrents)
               .WithMany(c => c.Courses);

            modelBuilder.Entity<Concurrent>()
         .HasMany(s => s.Courses)
         .WithMany(c => c.Concurrents);

        }
    }
}

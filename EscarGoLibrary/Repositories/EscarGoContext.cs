﻿using EscarGo.Models;
using System.Data.Entity;

namespace EscarGo.Repositories
{
    public sealed class EscarGoContext : DbContext
    {
        //public EscarGoContext()
        //    : base("DefaultConnection")
        //{
        //}

        public EscarGoContext()
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Concurrent> Concurrents { get; set; }
        public DbSet<Pari> Paris { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
               .HasMany(s => s.Concurrents)
               .WithMany(c => c.Courses);

            modelBuilder.Entity<Concurrent>()
         .HasMany(s => s.Courses)
         .WithMany(c => c.Concurrents);




//            modelBuilder.Entity<Pari>()
//              .HasMany(s => s.Courses)
//              .WithMany(c => c.Paris);

//            modelBuilder.Entity<Course>()
//.HasMany(s => s.Paris)
//.WithMany(c => c.Courses);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using AutoTrainerDB.Models;

namespace AutoTrainerDB
{

    public class ContextDB : DbContext
    {
        public DbSet<Client> Clients { get; set; }        
        public DbSet<Trainer> Trainers { get; set; }        
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<PersonCharacteristic> PersonCharacteristics { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public ContextDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();                      // если базы нет, то она создастся
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Routine>()
                .HasMany(e => e.RoutineExercises)
                .WithOne(e => e.Routine)
                .HasForeignKey(у => у.RoutineID)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}




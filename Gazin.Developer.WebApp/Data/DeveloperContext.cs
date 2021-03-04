using Microsoft.EntityFrameworkCore;
using System;

namespace Gazin.Developer.WebApp.Data
{
    public class DeveloperContext : DbContext
    {
        public DeveloperContext(DbContextOptions<DeveloperContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Developer> Developer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Developer>().HasData(
                new Models.Developer
                {
                    Id = 1,
                    Nome = "Marcelo Henrique de Melo",
                    Sexo = 'M',
                    Idade = 29,
                    Hobby = "Jogar futebol",
                    DataNascimento = DateTime.Parse("1991-4-09")
                },

                new Models.Developer
                {
                    Id = 2,
                    Nome = "João Lucas Miranda",
                    Sexo = 'M',
                    Idade = 18,
                    Hobby = "Jogar videogame",
                    DataNascimento = DateTime.Parse("2003-5-09")
                },

                new Models.Developer
                {
                    Id = 3,
                    Nome = "Laiza Maciel",
                    Sexo = 'F',
                    Idade = 22,
                    Hobby = "Assistir Netflix",
                    DataNascimento = DateTime.Parse("1998-4-08")
                },

                new Models.Developer
                {
                    Id = 4,
                    Nome = "Leonardo Silva",
                    Sexo = 'M',
                    Idade = 20,
                    Hobby = "Cozinhar",
                    DataNascimento = DateTime.Parse("2001-10-23")
                },

                new Models.Developer
                {
                    Id = 5,
                    Nome = "Fellipe de Melo Guardivir",
                    Sexo = 'M',
                    Idade = 16,
                    Hobby = "Jogar",
                    DataNascimento = DateTime.Parse("2004-04-19")
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
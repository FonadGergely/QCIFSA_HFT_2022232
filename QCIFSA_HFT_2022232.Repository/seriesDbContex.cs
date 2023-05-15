using QCIFSA_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCIFSA_HFT_2022232.Repository
{
        public class videogamesDbContex : DbContext
        {
            public DbSet<Series> Games { get; set; }
            public DbSet<Actors> Publisher { get; set; }
            public DbSet<Platform> Styles { get; set; }
            public videogamesDbContex()
            {
                this.Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                
                builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Games.mdf;Integrated Security=True");

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Series>()
                .HasOne(t => t.platform)
                .WithMany(t => t.series)
                .HasForeignKey(t => t.title);
                modelBuilder.Entity<Series>().HasData(new Series[]
                {
                    new Series("Last of us", 10)
                
                });
                modelBuilder.Entity<Platform>().HasData(new Platform[]
                {
                    new Platform("Netflix"),
                    new Platform("Max"),
                });
                modelBuilder.Entity<Actors>().HasData(new Actors[]
                {
                    new Actors("DeNiro",10000),
                    new Actors("Willis",100000)
                });
                ;

            }
        }
    }


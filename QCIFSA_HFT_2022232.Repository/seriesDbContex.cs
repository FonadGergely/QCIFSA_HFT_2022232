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
                    .HasOne(t => t.platform
                    .WithMany(t => t.Games)
                    .HasForeignKey(t => t.PublisherID);
                //modelBuilder.Entity<Series>()
                //     .HasOne(t => t.Style)
                //     .WithMany(t => Games)
                //     .HasForeignKey(t => t.TypeID);


                modelBuilder.Entity<Series>().HasData(new Series[]
                {
                new Series("1#Doom#2016#1#1"),
                new Series("2#Wolfenstein#2015#1#1"),
                new Series("3#StarCraft#2013#2#2"),
                new Series("4#BattleFront SW#2015#1#1"),
                new Series("5#Overwatch#2016#1#2"),
                new Series("6#Warcraft3#1998#2#2"),
                new Series("7#Warhammer#2013#2#2"),
                });
                modelBuilder.Entity<Publisher>().HasData(new Publisher[]
                {
                new Publisher("1#Bethesda"),
                new Publisher("2#Activision Blizzard"),
                });
                modelBuilder.Entity<Style>().HasData(new Style[]
                {
                new Style("1#FPS"),
                new Style("2#RTS")
                });
                ;

            }
        }
    }


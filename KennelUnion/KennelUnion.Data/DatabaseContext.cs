﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KennelUnion.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private readonly IConfigurationRoot _config;

        public DatabaseContext(IConfigurationRoot config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<News> NewsSet { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breeder> Breeders { get; set; }
        public DbSet<DogRegistry> DogRegistries { get; set; }
    }
}
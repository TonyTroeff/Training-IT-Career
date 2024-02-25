﻿using Microsoft.EntityFrameworkCore;
using SampleApp1.Data.Models;

namespace SampleApp1.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}

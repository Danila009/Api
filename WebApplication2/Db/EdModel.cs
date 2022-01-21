using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Db
{
    public class EdModel:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
        }
        public EdModel(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> users { get; set; }
    }
}

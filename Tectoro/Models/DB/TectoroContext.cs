using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tectoro.Models.DB
{
    public partial class TectoroContext : DbContext
    {
        public TectoroContext()
        {
        }

        public TectoroContext(DbContextOptions<TectoroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.Level);
                entity.Property(e => e.ManagerId);
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.ManagerId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.Position);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Alias);
                entity.Property(e => e.Email);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.UserName);
            });

        }

    }
}

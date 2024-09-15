using Microsoft.EntityFrameworkCore;
using go_funding_server.Data.Entities;

namespace go_funding_server.Data
{
    public class GoFundingPortalDbContext : DbContext
    {
        public GoFundingPortalDbContext(DbContextOptions<GoFundingPortalDbContext> context):base(context) { 
        }

        // register the classes
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }


    }
}

/*
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Address>()
               .HasOne(_ => _.Student)
               .WithMany(_ => _.Address)
               .HasForeignKey(_ =>_.StudentId);
       }
       */

using CRUD_using_One_to_One_Relationship.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_using_One_to_One_Relationship.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(val => val.mark)
                .WithOne(val => val.Student)
                .HasForeignKey<Mark>(val => val.StudentId);
        }

        public DbSet<Student> Students { get; set; }    
        public DbSet<Mark> Marks { get; set; }
    }
}

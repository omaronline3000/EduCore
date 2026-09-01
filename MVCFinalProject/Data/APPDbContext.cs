using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Models;
namespace MVCFinalProject.Data
{
    public class APPDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connections.SQLConStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Restrict Delete-Behavior
            foreach (var builder in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                builder.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Relations

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.department)
                .WithMany(d => d.instructors)
                .HasForeignKey(i => i.deptId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.course)
                .WithMany(c => c.instructors)
                .HasForeignKey(i => i.crsId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.department)
                .WithMany(d => d.courses)
                .HasForeignKey(c => c.deptId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasQueryFilter(i => !i.IsDeleted);
            modelBuilder.Entity<Course>()
                .HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Department>()
                .HasQueryFilter(d => !d.IsDeleted);
            modelBuilder.Entity<Trainee>()
                .HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<CrsResult>()
                .HasQueryFilter(cr => !cr.IsDeleted);

        }



        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }


    }
}

using AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Context {
    public class AppDbContext:DbContext {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels; Database=JobOrderAndTaskMonitoringSystem; Integrated Security=True; TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobOrder> JobOrders { get; set; }  
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany()
                .HasForeignKey(u => u.DepartmentId);

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.JobOrder)
                .WithMany()
                .HasForeignKey(ut => ut.JobOrderId);

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.AssignedUser)
                .WithMany()
                .HasForeignKey(ut => ut.AssignedTo);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.UserTask)
                .WithMany()
                .HasForeignKey(n => n.UserTaskId);

        }
    }
}

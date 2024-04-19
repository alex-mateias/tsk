using Microsoft.EntityFrameworkCore;
using tsk.Domain.Models;

namespace tsk.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
    }

}
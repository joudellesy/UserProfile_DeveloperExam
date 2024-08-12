using Microsoft.EntityFrameworkCore;
using static UserProfile_DeveloperExam.Models.UserModel;

namespace UserProfile_DeveloperExam.DBContext
{
    public class UserProfileDBContext : DbContext
    {
        public UserProfileDBContext(DbContextOptions<UserProfileDBContext> options) : base(options) { }

        public DbSet<User_Profile> UserProfiles { get; set; }
        public DbSet<Running_Activities> RunningActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Profile>().ToTable("User_Profile");
            modelBuilder.Entity<Running_Activities>().ToTable("Running_Activities");
        }
    }
}

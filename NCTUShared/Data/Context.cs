using Microsoft.AspNet.Identity.EntityFramework;
using NCTUShared.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NCTUShared.Data
{
    /// <summary>
    /// Entity Framework context class.
    /// </summary>
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Role> TeamRoles { get; set; }
        public DbSet<TeamTeamMember> TeamTeamMembers { get; set;}

        public Context()
            : base("Context")
        {
            //// This call to the SetInitializer method is used 
            //// to configure EF to use our custom database initializer class
            //// which contains our app's database seed data.
            ////Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Removing the pluralizing table name convention 
            // so our table names will use our entity class singular names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Using the fluent API to configure the precision and scale
            // for the Team.AverageRating property.
            //modelBuilder.Entity<Team>()
            //    .Property(cb => cb.AverageRating)
            //    .HasPrecision(5, 2);
        }
    }
}

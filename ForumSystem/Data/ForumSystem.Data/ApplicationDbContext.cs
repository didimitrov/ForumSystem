using System.Data.Entity;
using ForumSystem.Data.Migrations;
using ForumSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Tag> Tags { get; set; }
    }
}

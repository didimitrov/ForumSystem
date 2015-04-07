using System.Data.Entity;
using ForumSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Tag> Tags { get; set; }
    }
}

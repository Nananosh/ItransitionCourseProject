using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionElement> CollectionElements { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CustomFields> CustomFields { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
    }
}
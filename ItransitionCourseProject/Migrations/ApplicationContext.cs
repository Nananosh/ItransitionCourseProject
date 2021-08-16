using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionElement> CollectionElements { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CustomFieldsTemplate> CustomFieldsTemplates { get; set; }
        public DbSet<CollectionTheme> CollectionThemes { get; set; }
    }
}
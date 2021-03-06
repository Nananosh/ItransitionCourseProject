using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public CollectionTheme CollectionTheme { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; } = new();
        public List<CustomFieldsTemplate> CustomFieldsTemplates { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}
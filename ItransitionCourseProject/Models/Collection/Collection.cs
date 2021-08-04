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
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
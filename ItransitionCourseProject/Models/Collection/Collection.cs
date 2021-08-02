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
        public List<Likes> Likes { get; set; } = new List<Likes>();
        public List<Comments> Comments { get; set; } = new List<Comments>();
        public List<CustomFields> CustomFields { get; set; } = new List<CustomFields>();
        public List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
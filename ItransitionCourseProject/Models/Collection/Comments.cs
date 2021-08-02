using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public List<Collection> Collection { get; set; } = new List<Collection>();
    }
}
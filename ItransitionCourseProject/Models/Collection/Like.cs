using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public List<Collection> Collection { get; set; } = new List<Collection>();
        public User User { get; set; }
    }
}
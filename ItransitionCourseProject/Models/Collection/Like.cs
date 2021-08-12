using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Like
    {
        public int Id { get; set; }
        public Collection Collection { get; set; }
        public User User { get; set; }
    }
}
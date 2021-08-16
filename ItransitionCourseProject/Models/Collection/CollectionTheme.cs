using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class CollectionTheme
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public List<Collection> Collection { get; set; }
    }
}
using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int TagName { get; set; }
        public List<Collection> Collection { get; set; } = new List<Collection>();
        public List<CollectionElement> CollectionElements { get; set; } = new List<CollectionElement>();
    }
}
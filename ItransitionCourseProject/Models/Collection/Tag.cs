using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<Collection> Collection { get; set; } = new();
        public List<CollectionElement> CollectionElements { get; set; } = new();
    }
}
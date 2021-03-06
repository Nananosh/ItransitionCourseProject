using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class CollectionElement
    {
        public int Id { get; set; }
        public Collection Collection { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public List<CustomField> CustomFields { get; set; } = new();
    }
}
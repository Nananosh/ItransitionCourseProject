namespace ItransitionCourseProject.Models
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public CollectionElement CollectionElement { get; set; }
        public CustomFieldsTemplate CustomFieldsTemplates { get; set; }
    }
}
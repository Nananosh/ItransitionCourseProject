using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionCourseProject.Models
{
    public class CustomFieldsTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Collection Collection { get; set; }
    }
}
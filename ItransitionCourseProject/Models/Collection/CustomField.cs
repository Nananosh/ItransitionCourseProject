﻿using System.Collections.Generic;

namespace ItransitionCourseProject.Models
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<Collection> Collection { get; set; } = new();
    }
}
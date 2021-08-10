using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionCourseProject.ViewModels
{
    public class CollectionElementViewModel
    {
        [Required] public int CollectionId { get; set; }
        [Required] [Display(Name = "Title")] public string Title { get; set; }

        [Required] [Display(Name = "Image")] public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Tags { get; set; }

        [Display(Name = "CustomFields")] public List<CustomField> CustomFields { get; set; } = new();
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionCourseProject.ViewModels
{
    public class CreateCollectionViewModel
    {
        [Required] public string UserId { get; set; }
        [Required] [Display(Name = "Title")] public string Title { get; set; }

        [Required] [Display(Name = "Image")] public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Tags { get; set; }

        [Display(Name = "CustomFields")] public List<CustomFieldsTemplate> CustomFields { get; set; } = new();
    }
}
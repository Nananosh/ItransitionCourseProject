using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ItransitionCourseProject.Models;

namespace ItransitionCourseProject.ViewModels.Collection
{
    public class CreateCollectionElementViewModel
    {
        [Required] public int CollectionId { get; set; }
        [Required] [Display(Name = "Title")] public string Title { get; set; }

        [Required] [Display(Name = "Image")] public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        [Required][Display(Name = "CustomFields")] public List<CustomField> CustomFields { get; set; } = new();
    }
}
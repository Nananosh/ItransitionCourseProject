using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionCourseProject.ViewModels
{
    public class CollectionViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required] 
        [Display(Name = "Image")] 
        public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Tags { get; set; }
    }
}
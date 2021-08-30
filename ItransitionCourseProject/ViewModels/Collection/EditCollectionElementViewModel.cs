using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels.Collection
{
    public class EditCollectionElementViewModel
    {
        [Required] public int Id { get; set; }
        [Required] [Display(Name = "Title")] public string Title { get; set; }

        [Required] [Display(Name = "Image")] public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
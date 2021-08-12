using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels
{
    public class CommentViewModel
    {
        [Required] public string UserId { get; set; }
        [Required] public int CollectionId { get; set; }
        [Required] [Display(Name = "Text")] public string Text { get; set; }
    }
}
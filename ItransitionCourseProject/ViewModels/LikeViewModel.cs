using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels
{
    public class LikeViewModel
    {
        [Required] public string UserId { get; set; }
        [Required] public int CollectionId { get; set; }
    }
}
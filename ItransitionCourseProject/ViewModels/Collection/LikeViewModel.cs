using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels.Collection
{
    public class LikeViewModel
    {
        [Required] public string UserId { get; set; }
        [Required] public int CollectionId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels.Account
{
    public class EditProfileViewModel
    {
        [Required] public string Id { get; set; }
        [Required] [Display(Name = "Image")] public string Image { get; set; }
    }
}
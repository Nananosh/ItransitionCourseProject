using System.ComponentModel.DataAnnotations;

namespace ItransitionCourseProject.ViewModels.Search
{
    public class SearchViewModel
    {
        [Display(Name = "Enter text")] public string Query { get; set; }
    }
}
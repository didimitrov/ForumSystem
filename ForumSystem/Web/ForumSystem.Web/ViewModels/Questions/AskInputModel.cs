using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Web.ViewModels.Questions
{
    public class AskInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}

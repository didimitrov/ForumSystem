using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using ForumSystem.Models;

namespace ForumSystem.Web.ViewModels.Questions
{
    public class AskInputModel
    {
       

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Content { get; set; }

        public int TagId { get; set; }

       // public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

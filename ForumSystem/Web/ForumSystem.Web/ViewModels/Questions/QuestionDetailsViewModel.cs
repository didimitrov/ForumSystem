using System.ComponentModel.DataAnnotations;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Questions
{
    public class QuestionDetailsViewModel :IMapFrom<Post>
    {
        
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }

        public string AuthorId { get; set; }
        //public ApplicationUser Author { get; set; }
    }
}
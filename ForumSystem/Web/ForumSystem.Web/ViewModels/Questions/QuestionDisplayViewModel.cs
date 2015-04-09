using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Questions
{
    public class QuestionDisplayViewModel :IMapFrom<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.PostModels
{
    public class CommentViewModel :IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string AuthorUsername { get; set; }

        public string Content { get; set; }
    }
}
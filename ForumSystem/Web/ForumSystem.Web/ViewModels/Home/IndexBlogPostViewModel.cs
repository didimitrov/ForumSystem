using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexBlogPostViewModel:IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
    }
}
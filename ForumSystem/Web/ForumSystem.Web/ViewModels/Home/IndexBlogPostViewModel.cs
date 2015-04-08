using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexBlogPostViewModel:IMapFrom<Post>
    {
        public string Title { get; set; }
        
    }
}
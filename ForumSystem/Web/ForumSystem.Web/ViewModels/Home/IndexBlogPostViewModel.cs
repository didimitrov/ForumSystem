using System.Collections.Generic;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexBlogPostViewModel:IMapFrom<Post>
    {
        public IndexBlogPostViewModel()
        {
            this.Comments=new List<CommentViewModel>();
            this.CountComm = Comments.Count;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public int CountComm { get; set; }
        

        public List<CommentViewModel> Comments { get; set; }
        
    }
}
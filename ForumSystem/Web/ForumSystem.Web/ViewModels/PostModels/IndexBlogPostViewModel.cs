using System;
using System.Collections.Generic;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;

namespace ForumSystem.Web.ViewModels.PostModels
{
    public class IndexBlogPostViewModel:IMapFrom<Post>
    {
        public IndexBlogPostViewModel()
        {
           }
        public int Id { get; set; }

        public string Title { get; set; }
        
        public int CountComm { get; set; }

        public int CountVotes { get; set; }

        public DateTime PostedAgo { get; set; }

        public string Tag { get; set; }

       // public ICollection<Vote> Votes { get; set; }
       // public List<CommentViewModel> Comments { get; set; }
        
    }
}
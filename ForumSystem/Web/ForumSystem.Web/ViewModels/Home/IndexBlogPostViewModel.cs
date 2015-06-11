using System;
using System.Collections.Generic;
using ForumSystem.Models;
using ForumSystem.Web.Infrastructure.Mapping;
using Microsoft.Ajax.Utilities;

namespace ForumSystem.Web.ViewModels.Home
{
    public class IndexBlogPostViewModel:IMapFrom<Post>
    {
        public IndexBlogPostViewModel()
        {
            //this.Comments=new List<CommentViewModel>();
            //this.CountComm = Comments.Count;
            //this.Votes= new HashSet<Vote>();
            //this.CountVotes = Votes.Count;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public int CountComm { get; set; }

        public int CountVotes { get; set; }

        public DateTime PostedAgo { get; set; }

       // public ICollection<Vote> Votes { get; set; }
       // public List<CommentViewModel> Comments { get; set; }
        
    }
}
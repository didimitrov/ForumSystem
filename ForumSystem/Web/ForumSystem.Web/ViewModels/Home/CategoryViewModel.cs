using System.Collections.Generic;
using ForumSystem.Models;

namespace ForumSystem.Web.ViewModels.Home
{
    public class CategoryViewModel
    {
        
        public string CategoryTitle { get; set; }

        public int TagsCount { get; set; }

        public int  PostCount { get; set; }
        public virtual ICollection<Post> Posts { get; set; } 


        public virtual ICollection<Tag> Tags { get; set; }  //use List
    }
}
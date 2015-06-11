using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.Home;

namespace ForumSystem.Web.ViewModels.SideBar
{
    public class SideBarViewModel
    {
        public IQueryable<IndexBlogPostViewModel> Posts { get; set; }
        public IQueryable<TagViewModel> Tags { get; set; }
    }
}

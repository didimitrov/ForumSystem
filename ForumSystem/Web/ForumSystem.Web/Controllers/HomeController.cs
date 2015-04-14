using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Common.Repository;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.Home;
using ForumSystem.Web.ViewModels.Questions;
using Microsoft.AspNet.Identity;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> _posts;
        private readonly IRepository<Comment> _comments;


        

        public HomeController(IRepository<Post> posts, IRepository<Comment> comments)
        {
            _posts = posts;
            this._comments = comments;
        }

        public ActionResult Index()
        {
            var posts = _posts.All().Project().To<IndexBlogPostViewModel>();
            return View(posts);
        }

        public ActionResult Details(int id)
        {
            //var postDetailModel = _posts.All()
            //    .Where(post => post.Id == id)
            //    .Project()
            //    .To<QuestionDetailsViewModel>().FirstOrDefault();

            var detailsModel = _posts.All().Where(post => post.Id == id).Select(x => new QuestionDetailsViewModel()
            {
                AuthorId = User.Identity.Name,
                Content = x.Content,
                Title = x.Title
            }).FirstOrDefault();

            return View(detailsModel);
        }

        public ActionResult PostComment(SubmitCommentModel commentModel)
        {


            if (ModelState.IsValid)
            {
                var userName = User.Identity.GetUserName();
                var userId = User.Identity.GetUserId();

                _comments.Add(new Comment
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    PostId = commentModel.PostId
                });
                _comments.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = userName, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}
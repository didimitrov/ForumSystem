using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.PostModels;
using ForumSystem.Web.ViewModels.Questions;
using Microsoft.AspNet.Identity;

namespace ForumSystem.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _posts;
        private readonly IRepository<Comment> _comments;
        private readonly IRepository<Vote> _votes;

        public PostController(IRepository<Post> posts, IRepository<Comment> comments, IRepository<Vote> votes)
        {
            _posts = posts;
            this._comments = comments;
            _votes = votes;
        }
         
        public ActionResult Index(int id)
        {

            //var posts = _posts.All().OrderByDescending(x => x.Id).Select(x => new IndexBlogPostViewModel()
            //{
            //    Title = x.Title,
            //    CountComm = x.Comments.Count,
            //    CountVotes = x.Votes.Count,
            //    Id = x.Id,
            //    PostedAgo = x.AskedOn,
            //    Tag = x.Tag.Name
            //});

            //return View(posts);


            var posts = _posts.All().Where(ft => ft.TagId == id).Select(x => new IndexBlogPostViewModel()
            {
                Title = x.Title,
                CountComm = x.Comments.Count,
                CountVotes = x.Votes.Count,
                Id = x.Id,
                PostedAgo = x.AskedOn,
                Tag = x.Tag.Name
            }).OrderByDescending(x=>x.CountVotes);
            TempData["TagId"] = id;

           // ViewBag.MsgCount = _db.Messages.Count(m => m.ForumThread.ForumThreadId == id);


            return View(posts);

        }

        public ActionResult Details(int id)
        {
            //var postDetailModel = _posts.All()
            //    .Where(post => post.Id == id)
            //    .Project()
            //    .To<QuestionDetailsViewModel>().FirstOrDefault();

            var currentUserId = User.Identity.GetUserId();

            var detailsModel = _posts.All().Where(post => post.Id == id).Select(x => new QuestionDetailsViewModel()
            {
                Comments = x.Comments.Select(y => new CommentViewModel
                {
                    AuthorUsername = y.Author.UserName,
                    Content = y.Content
                }).ToList(),
                Id = x.Id,
                AuthorId = x.Author.UserName,
                Content = x.Content,
                Title = x.Title,
                Date = x.AskedOn,
                UserCanVote = x.Votes.All(pesho => pesho.VotedById != currentUserId),
                Votes = x.Votes.Count,
                CountComm = x.Comments.Count
            }).FirstOrDefault();

            return View(detailsModel);
        }

        [HttpPost]
        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();
            var canVote = !_votes.All().Any(x => x.PostId == id && x.VotedById == userId);

            if (canVote)
            {
                var singleOrDefault = _posts.All().SingleOrDefault(x => x.Id == id);
                if (singleOrDefault != null)
                    singleOrDefault.Votes.Add(new Vote
                    {
                        PostId = id,
                        VotedById = userId
                    });
                _posts.SaveChanges();
            }

            var votes = _posts.GetById(id).Votes.Count();

            if (votes != 0)
            {
                return Content(votes.ToString(CultureInfo.InvariantCulture));
            }
            return Content("0");
        }

        [HttpPost]
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
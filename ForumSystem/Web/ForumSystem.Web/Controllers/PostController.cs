using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.PostModels;
using ForumSystem.Web.ViewModels.Questions;
using Microsoft.AspNet.Identity;
using PagedList;

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

        public ActionResult Index(int? page, int id)  
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
            }).OrderByDescending(x=>x.PostedAgo);

            TempData["TagId"] = id;

            return View(posts.ToPagedList(page ?? 1, 3));
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
                    Id = y.Id,
                    AuthorUsername = y.Author.UserName,
                    Content = y.Content,
                    Votes = y.Votes.Count()
                }).ToList(),
                Id = x.Id,
                TagId = x.TagId,
                AuthorId = x.Author.UserName,
                Content = x.Content,
                Title = x.Title,
                Date = x.AskedOn,
                UserCanVote = x.Votes.All(pesho => pesho.VotedById != currentUserId),
                Votes = x.Votes.Count,
                CountComm = x.Comments.Count,
               
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
            if (ModelState.IsValid && commentModel.Comment!=null)
            {
                var userName = User.Identity.GetUserName();
                var userId = User.Identity.GetUserId();

                _comments.Add(new Comment
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    PostId = commentModel.PostId,
                    DateTime = DateTime.Now
                });
                _comments.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = userName, Content = commentModel.Comment ,DateTime = DateTime.Now};
                return PartialView("_CommentPartial", viewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        public ActionResult CommentVoteUp(int commentId)
        {
             var userId = User.Identity.GetUserId();
          //   var canVote = !_votes.All().Any(x => x.CommentId == commentId && x.VotedById == userId);
           
                var comm = _comments.All().SingleOrDefault(x => x.Id == commentId);
                if (comm != null)
                    comm.Votes.Add(new Vote
                    {
                        CommentId = commentId,
                        VotedById = userId,
                    });
                _comments.SaveChanges();
            

            var CommVoteCount = _comments.GetById(commentId).Votes.Count();
            if (CommVoteCount != 0)
            {
                return Content(CommVoteCount.ToString(CultureInfo.InvariantCulture));
            }
            return Content("10");
        }

          

        public ActionResult Search(string search, string searchBy, string sortBy, int? page)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";

            var searchResults = new List<Post>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                foreach (var thread in _posts.All())
                {
                    searchResults.Add(thread);
                }

                if (!string.IsNullOrWhiteSpace(search))
                    searchResults = searchResults.Where(m => m.Title.ToLower().Contains(search)).ToList();

                switch (sortBy)
                {
                    case "Name desc":
                        searchResults = searchResults.OrderByDescending(a => a.Id).ToList();
                        break;
                    default:
                        searchResults = searchResults.OrderBy(a => a.Id).ToList();
                        break;
                }
            }


            return View(searchResults.ToPagedList(page ?? 1, 3));
        }








       // [HttpGet]
       // public ActionResult CreateComments()
       // {
       //     return PartialView("_CreateCommentPartial");
       // }


       //[HttpPost]
       // public ActionResult CreateComments(SubmitCommentModel commentModel)
       // {
       //     var userName = User.Identity.GetUserName();
       //     var userId = User.Identity.GetUserId();

       //     if (ModelState.IsValid && commentModel.Comment != null)
       //     {
       //         if (commentModel.ParentId == null)
       //         {
       //             _comments.Add(new Comment
       //             {
       //                 AuthorId = userId,
       //                 Content = commentModel.Comment,
       //                 PostId = commentModel.PostId,
                       
       //             });
       //             _comments.SaveChanges();

       //             var viewModel = new CommentViewModel {AuthorUsername = userName, Content = commentModel.Comment};
       //             return PartialView("_CommentPartial", viewModel);
       //         }
       //         else
       //         {
       //             _comments.Add(new Comment
       //             {
       //                 PostId = commentModel.Id,
       //                 AuthorId = userId,
       //                 Content = commentModel.Comment,
       //                 ParentId = commentModel.Id
       //             });
       //             _comments.SaveChanges();
       //             var viewModel = new CommentViewModel()
       //             {
       //                 AuthorUsername = userName,
       //                 Content = commentModel.Comment
       //             };
       //             return PartialView("_CreateCommentPartial", viewModel);
       //         }

       //     }

       //     return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
       // }
    }
}
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.Questions;
using Microsoft.AspNet.Identity;

namespace ForumSystem.Web.Controllers
{

    public class QuestionsController : Controller
    {
       // private readonly IDeletableEntityRepository<Post> _posts;
        private readonly IRepository<Vote> _votes;
        private readonly IRepository<Post> _posts;


        public QuestionsController(IRepository<Post> posts, IRepository<Vote> votes)
        {
            this._posts = posts;
            _votes = votes;
        }

        // GET: Questions
        public ActionResult Display(int id, string url)
        {
            var viewPostModel = _posts.All().Where(post => post.Id == id)
                .Project()
                .To<QuestionDisplayViewModel>()
                .FirstOrDefault();


            return View(viewPostModel);
        }
      


        public ActionResult GetByTag(string tag)
        {
            return Content(tag);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Ask()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Ask(AskInputModel input)
        {
           if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var post = new Post
                {
                    Content = input.Content,
                    Title = input.Title,
                    AuthorId = userId,
                    //todo: Tags
                }; 
             _posts.Add(post);
             _posts.SaveChanges();
              //  return RedirectToAction("Display", new {id = post.Id, Url = "new"});  //todo: fix this 
                return RedirectToAction("Index", "Post");
            }
            return View(input);
        }

       
    }
}
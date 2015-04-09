using System.Web.Mvc;
using ForumSystem.Web.ViewModels.Questions;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Display(int id, string url)
        {
            return Content(id + " " + url);
        }

        public ActionResult GetByTag(string tag)
        {
            return Content(tag);
        }

        [HttpGet]
        public ActionResult Ask()
        {
            return Content("Get");
        }

        [HttpPost]
        public ActionResult Ask(AskInputModel input)
        {
            return Content("Post");
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using ForumSystem.Common.Repository;
using ForumSystem.Models;
using ForumSystem.Web.ViewModels.Home;

namespace ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category> _category;

        public HomeController(IRepository<Category> category)
        {
            _category = category;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _category.All().Select(x => new CategoryViewModel()
            {
                CategoryTitle = x.Title ,
                Tags = x.Tags,
                TagsCount = x.Tags.Count
            }).ToList();

            return View(categories);
        }
    }
}
using It4SolutionCodeFirst.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace It4SolutionCodeFirst.Controllers
{
    public class CategoryController : Controller
    {
        StoreContext context;

        public CategoryController()
        {
            context = new StoreContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = context.Category.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View(new Category { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View("Create", category);
            if (category.Id > 0)
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            else
                context.Category.Add(category);

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = context.Category.SingleOrDefault(p => p.Id == id);

            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            context.Category.Remove(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = context.Category.Find(id);

            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View("Create", category);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
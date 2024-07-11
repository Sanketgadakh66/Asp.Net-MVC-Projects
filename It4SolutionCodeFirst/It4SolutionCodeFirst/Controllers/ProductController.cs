using It4SolutionCodeFirst.Models;
using It4SolutionCodeFirst.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace It4SolutionCodeFirst.Controllers
{
    public class ProductController : Controller
    {

        StoreContext context;

        public ProductController()
        {
            context = new StoreContext();
        }


        // GET: Product
        public ActionResult Create()
        {
            var _categories = context.Category.ToList();
            var viewModel = new ProductViewModel()
            {
                Product = new Product() { Id = 0 },
                Categories = _categories
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = context.Category.ToList();
                return View(viewModel);
            }

            if (viewModel.Product.Id > 0)
            {
                // Editing an existing product
                context.Entry(viewModel.Product).State = EntityState.Modified;
            }
            else
            {
                // Creating a new product
                context.Product.Add(viewModel.Product);
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var products = context.Product.Include(c => c.Category).ToList();

            return View(products);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var _product = context.Product.SingleOrDefault(p => p.Id == id);

            if (_product == null)
                return HttpNotFound();

            var viewModel = new ProductViewModel()
            {
                Product = _product,
                Categories = context.Category.ToList()
            };
            return View("Create", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var _product = context.Product.SingleOrDefault(p => p.Id == id);

            if (_product == null)
                return HttpNotFound();

            context.Product.Remove(_product);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
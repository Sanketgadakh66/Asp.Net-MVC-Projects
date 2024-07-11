using It4SolutionCodeFirst.Models;
using It4SolutionCodeFirst.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace It4SolutionCodeFirst.Controllers
{
    public class AccountController : Controller
    {

        private StoreContext _context;

        public AccountController()
        {
            _context = new StoreContext();
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View("Register", user);
            if (_context.users.Where(u => u.Email == user.Email || u.Username == user.Username).Any())
            {
                ModelState.AddModelError("Email", " email or Username already exist");
                return View("Register", user);
            }
            _context.users.Add(user);
            _context.SaveChanges();
            return Content(" User registerd successfully");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var LoginUser = _context.users.Where(u => u.Username == user.Username || u.Password == user.Password).FirstOrDefault();
            if (LoginUser == null)
            {
                ModelState.AddModelError("UserName", "Username or Password is incorrect, please try again");
                return View("Login", user);
            }
            else
            {
                Session["UserName"] = LoginUser.Username;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
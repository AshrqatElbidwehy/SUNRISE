using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUNRISE.Models;

namespace SUNRISE.Controllers
{
    [Authorize]
    [Route("[action]")]
    public class HomeController : Controller
    {
        protected ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [Route("/")]
        [Route("/index")]
        public IActionResult Index()
        {
            ViewData["page"] = "Index";
            return View();
        }

        [HttpGet]
        public IActionResult CreateChef()
        {
            ViewData["page"] = "CreateChef";
            ViewData["RemoveHeader"] = true;
            return View(new Chef());
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            ViewData["page"] = "CreateChef";
            ViewData["RemoveHeader"] = true;
            try
            {
                if(chef is not null && ModelState.IsValid)
                {
                    _context.Add(chef);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(chef);
            }
            catch
            {
                return View(chef);
            }
        }

        [AllowAnonymous]
        public IActionResult ShowHowItWorks()
        {
            ViewData["page"] = "HowItWorks";
            return View();
        }


        public IActionResult GetReviews()
        {
            ViewData["page"] = "Review";
            return View();
        }

        public IActionResult GetMenu()
        {
            ViewData["page"] = "Menu";
            return View();
        }

        [AllowAnonymous]
        public IActionResult ShowOurStory()
        {
            ViewData["page"] = "OurStory";
            return View();
        }

        [AllowAnonymous]
        public IActionResult ContactUs()
        {
            ViewData["page"] = "ContactUS";
            ViewData["RemoveHeader"] = true;
            return View();
        }

        [AllowAnonymous]
        public IActionResult WlcomeHome()
        {
            ViewData["page"] = "WlcomeHome";
            ViewData["RemoveHeader"] = true;
            return View();
        }
    }
}
